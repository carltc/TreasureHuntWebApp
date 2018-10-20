DECLARE @Something table  (      Type INT      , Score INT  );    
DECLARE @cnt INT = 0;  
DECLARE @max INT = (SELECT COUNT (DISTINCT Name) FROM DBO.Winner);    
WHILE @cnt <= @max  
BEGIN   IF @cnt = 0    INSERT @Something VALUES (0, 0);   
ELSE IF @cnt = 1    INSERT @Something VALUES (1, 100);   
ELSE IF @cnt = 2    INSERT @Something VALUES (2, 50);   
ELSE IF @cnt = 3    INSERT @Something VALUES (3, 25);   
ELSE IF @cnt = 4    INSERT @Something VALUES (4, 12);   
ELSE    INSERT @Something VALUES (@cnt, 10);   
SET @cnt = @cnt + 1;  END;    
WITH SortedValues AS  
(   
SELECT *    , RowNum = ROW_NUMBER() OVER (PARTITION BY HuntID ORDER BY WinTime ASC)   
FROM    
(    
SELECT Name, HuntID, min(WinTime) AS WinTime    
FROM dbo.Winner    
GROUP BY dbo.Winner.Name, HuntID   
) x  
),  
fullTable AS  
(  
SELECT    Name   ,
Type1 = max(CASE WHEN HuntID = 1 THEN RowNum ELSE 0 END),
Type2 = max(CASE WHEN HuntID = 2 THEN RowNum ELSE 0 END),
Type3 = max(CASE WHEN HuntID = 3 THEN RowNum ELSE 0 END),
Type4 = max(CASE WHEN HuntID = 4 THEN RowNum ELSE 0 END)  
FROM SortedValues  
GROUP BY SortedValues.Name  
)  
SELECT ID = CAST(ROW_NUMBER() OVER (ORDER BY x.Score + xx.Score + xxx.Score + xxxx.Score DESC) AS BIGINT),fullTable.Name,CAST(x.Score + xx.Score + xxx.Score + xxxx.Score AS BIGINT) as Score 
FROM fullTable  
join @Something AS x ON x.Type = fullTable.Type1   
join @Something AS xx ON xx.Type = fullTable.Type2   
join @Something AS xxx ON xxx.Type = fullTable.Type3   
join @Something AS xxxx ON xxxx.Type = fullTable.Type4   
ORDER BY Score DESC
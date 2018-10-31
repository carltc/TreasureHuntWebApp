using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.EntityClient;
using System.Data.Objects;
using TreasureHuntWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TreasureHuntWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public IndexModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public string hiddenLink = "/WordsHurt/Index";

        public string PadNumber(int input, int padCount)
        {
            string inputString = input.ToString();
            string outputString = inputString;
            while (outputString.Length < padCount)
            {
                outputString = "0" + outputString;
            }
            return outputString;
        }

        public IList<Scoreboard> ScoreboardResults { get; set; }

        public IList<Winner> Hunt1Winners { get; set; }
        public IList<Winner> Hunt2Winners { get; set; }
        public IList<Winner> Hunt3Winners { get; set; }
        public IList<Winner> Hunt4Winners { get; set; }

        public IActionResult OnPost(string button)
        {
            if (button == "Hunt4")
            {
                DateTime releaseTime = new DateTime(2018, 11, 2, 3, 0, 0);
                DateTime timeNow = DateTime.Now;

                if (timeNow > releaseTime)
                {
                    return RedirectToPage(hiddenLink);
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }
            return RedirectToPage("/Index");
        }

        public void OnGet()
        {
            Hunt1Winners = _context.Winner.Where(field => field.HuntID == 2)
                .GroupBy(item => item.Name)
                .Select(grouping => grouping.FirstOrDefault())
                .OrderBy(item => item.WinTime)
                .ToList();

            Hunt2Winners = _context.Winner.Where(field => field.HuntID == 1)
                .GroupBy(item => item.Name)
                .Select(grouping => grouping.FirstOrDefault())
                .OrderBy(item => item.WinTime)
                .ToList();

            Hunt3Winners = _context.Winner.Where(field => field.HuntID == 3)
                .GroupBy(item => item.Name)
                .Select(grouping => grouping.FirstOrDefault())
                .OrderBy(item => item.WinTime)
                .ToList();

            Hunt4Winners = _context.Winner.Where(field => field.HuntID == 4)
                .GroupBy(item => item.Name)
                .Select(grouping => grouping.FirstOrDefault())
                .OrderBy(item => item.WinTime)
                .ToList();

            string sqlQuery = ""
                + "DECLARE @tableName VARCHAR(MAX) = 'x'; "
                + "DECLARE @type INT = 0; "
                + "DECLARE @typeCount INT = (SELECT COUNT(DISTINCT HuntID) FROM dbo.Winner); "
                + "DECLARE @fullSQLstatement VARCHAR(MAX) = ''; "
                + "DECLARE @firstPortion VARCHAR(MAX) = ' "
                + "    DECLARE @Something table(Type INT, Score INT); "
                + "    DECLARE @cnt INT = 0; "
                + "    DECLARE @max INT = (SELECT COUNT(DISTINCT Name) FROM DBO.Winner); "
                + "    WHILE @cnt <= @max "
                + "    BEGIN "
                + "        IF @cnt = 0 INSERT @Something VALUES(0, 0); "
                + "        ELSE IF @cnt = 1 INSERT @Something VALUES(1, 100); "
                + "        ELSE IF @cnt = 2 INSERT @Something VALUES(2, 50); "
                + "        ELSE IF @cnt = 3 INSERT @Something VALUES(3, 25); "
                + "        ELSE IF @cnt = 4 INSERT @Something VALUES(4, 12); "
                + "        ELSE INSERT @Something VALUES(@cnt, 10); "
                + "        SET @cnt = @cnt + 1; "
                + "    END; "
                + "    WITH SortedValues AS "
                + "    ( "
                + "        SELECT *, RowNum = ROW_NUMBER() OVER(PARTITION BY HuntID ORDER BY WinTime ASC) "
                + "        FROM "
                + "        ( "
                + "            SELECT Name, HuntID, min(WinTime) AS WinTime "
                + "            FROM dbo.Winner "
                + "            GROUP BY dbo.Winner.Name, HuntID "
                + "        ) x "
                + "    ), "
                + "    fullTable AS "
                + "    ( "
                + "    SELECT "
                + "        Name "
                + "        ' "
                + "SET @fullSQLstatement = @firstPortion; "
                + "SET @type = 1; "
                + "WHILE @type <= @typeCount "
                + "BEGIN "
                + "    SET @fullSQLstatement = @fullSQLstatement + ',Type' + CONVERT(varchar(10), @type) + ' = max(CASE WHEN HuntID = ' + CONVERT(varchar(10), @type) + ' THEN RowNum ELSE 0 END)' "
                + "    SET @type = @type + 1; "
                + "END; "
                + "DECLARE @secondPortion NVARCHAR(MAX) = ' "
                + "FROM SortedValues "
                + "GROUP BY SortedValues.Name "
                + ") "
                + "SELECT ID = CAST(ROW_NUMBER() OVER (ORDER BY ' "
                + " "
                + "SET @fullSQLstatement = @fullSQLstatement + @secondPortion; "
                + "	"
                + "SET @type = 1; "
                + "SET @tableName = 'x'; "
                + "SET @fullSQLstatement = @fullSQLstatement + @tableName + '.Score'; "
                + "WHILE @type < @typeCount "
                + "BEGIN "
                + "	SET @tableName = @tableName + 'x'; "
                + "	SET @fullSQLstatement = @fullSQLstatement + ' + ' + @tableName + '.Score'; "
                + "SET @type = @type + 1; "
                + "END; "
                + "DECLARE @secondMidPortion NVARCHAR(MAX) =' DESC) AS BIGINT),fullTable.Name,CAST(' "
                + "SET @fullSQLstatement = @fullSQLstatement + @secondMidPortion; "
                + "SET @type = 1; "
                + "SET @tableName = 'x'; "
                + "SET @fullSQLstatement = @fullSQLstatement + @tableName + '.Score'; "
                + "WHILE @type < @typeCount "
                + "BEGIN "
                + "    SET @tableName = @tableName + 'x'; "
                + "    SET @fullSQLstatement = @fullSQLstatement + ' + ' + @tableName + '.Score'; "
                + "    SET @type = @type + 1; "
                + "END; "
                + "DECLARE @thirdPortion NVARCHAR(MAX) = ' AS BIGINT) AS Score FROM fullTable "
                + "'; "
                + "SET @fullSQLstatement = @fullSQLstatement + @thirdPortion; "
                + "SET @type = 1; "
                + "SET @tableName = 'x'; "
                + "WHILE @type <= @typeCount "
                + "BEGIN "
                + "    SET @fullSQLstatement = @fullSQLstatement + 'join @Something AS ' + @tableName + ' ON ' + @tableName + '.Type = fullTable.Type' + CONVERT(varchar(10), @type) + ' "
                + "    '; "
                + "SET @type = @type + 1; "
                + "SET @tableName = @tableName + 'x'; "
                + "END; "
                + "DECLARE @fourthPortion NVARCHAR(MAX) = 'ORDER BY Score DESC' "
                + "SET @fullSQLstatement = @fullSQLstatement + @fourthPortion; "
                + "EXEC(@fullSQLstatement)";
            
            var scoreBoardResults = _context.Scoreboard.FromSql(sqlQuery);
            ScoreboardResults = scoreBoardResults.ToList();
        }
    }
}

// See https://aka.ms/new-console-template for more information
using ClassLibrary1;
using ConsoleApp1;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;

Console.WriteLine($"Launched from {Environment.CurrentDirectory}");

IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var connString = configuration.GetConnectionString(nameof(MonsterContext));

Console.WriteLine($"Connection String is: {connString}");

const string sqlTextSelectAllTables = "select * from sys.tables";
const string sqlTextSelectAllColumns = @"
SELECT c.name 'ColumnName'
	,t.name 'DataType'
	,c.max_length 'MaxLength'
	,c.precision 'Precision'
	,c.scale 'Scale'
	,c.is_nullable 'IsNullable'
	,ISNULL(i.is_primary_key, 0) 'PrimaryKey'
FROM sys.columns c
INNER JOIN sys.types t
	ON c.user_type_id = t.user_type_id
LEFT OUTER JOIN sys.index_columns ic
	ON ic.object_id = c.object_id
		AND ic.column_id = c.column_id
LEFT OUTER JOIN sys.indexes i
	ON ic.object_id = i.object_id
		AND ic.index_id = i.index_id
WHERE c.object_id = OBJECT_ID('{0}')
";
string[] sqlTypes = new string[] {
 "int"
,"bigint"
,"tinyint"
,"nvarchar"
,"uniqueidentifier"
,"datetime"
,"bit"
,"smallint"
,"varchar"
,"date"
,"time"
,"datetimeoffset"
,"datetime2"
,"decimal"
,"varbinary"
,"xml"
};

// Sql Table Meta Data
// https://stackoverflow.com/questions/59082755/accessing-table-comments-in-sql-server
// https://stackoverflow.com/questions/887370/sql-server-extract-table-meta-data-description-fields-and-their-data-types

StringBuilder sb = new StringBuilder();
IList<SysTable> sysTables = new List<SysTable>();
IList<SysColumn> sysColumns = new List<SysColumn>();

HashSet<string> columnNames = new HashSet<string>();
HashSet<string> dataTypes = new HashSet<string>();

sb.Length = 0; // Reset String Builder
using (SqlConnection conn = new SqlConnection(connString))
{
    conn.Open();
    sysTables = conn.Query<SysTable>(sql: sqlTextSelectAllTables).ToList();
    for (int i = 0; i < sysTables.Count; i++)
    { 
        SysTable sysTable = sysTables[i];    
        string tableName = sysTable.name;
        sb.AppendLine("------------------------------");
        sb.AppendLine($"Table: {tableName}");
        sb.Append($"Columns: {tableName}");
        string sql = string.Format(sqlTextSelectAllColumns, tableName);
        sysColumns = conn.Query<SysColumn>(sql: sql).ToList();
        for (int j = 0; j < sysColumns.Count; j++)
        {
            SysColumn sysColumn = sysColumns[j];
            if (j < sysColumns.Count - 1)
            {
                sb.Append($"{sysColumn.ColumnName} as {sysColumn.DataType} ({sysColumn.Precision}),");
            }
            else
            {
                sb.AppendLine($"{sysColumn.ColumnName} as {sysColumn.DataType} ({sysColumn.Precision})");
            }
            columnNames.Add(sysColumn.ColumnName);
            dataTypes.Add(sysColumn.DataType);
        }
    }
}
string strFilePathTableNames = $"{Environment.CurrentDirectory}\\TablesNames.txt";
File.WriteAllText(strFilePathTableNames, sb.ToString(), Encoding.UTF8);
Process.Start("notepad.exe", strFilePathTableNames);

sb.Length = 0; // Reset String Builder
foreach (string columnName in columnNames)
{
    sb.AppendLine(columnName);
    Console.WriteLine(columnName);
}
string strFilePathColumnNames = $"{Environment.CurrentDirectory}\\ColumnNames.txt";
File.WriteAllText(strFilePathColumnNames, sb.ToString(), Encoding.UTF8);
Process.Start("notepad.exe", strFilePathColumnNames);

sb.Length = 0; // Reset String Builder

foreach (string dataType in dataTypes)
{
    sb.AppendLine(dataType);
    Console.WriteLine(dataType);
}
string strFilePathDataTypes = $"{Environment.CurrentDirectory}\\DataTypes.txt";
File.WriteAllText(strFilePathDataTypes, sb.ToString(), Encoding.UTF8);
Process.Start("notepad.exe", strFilePathDataTypes);

// How to get values from appsettings.json in a console application using .NET Core?
// https://stackoverflow.com/questions/65110479/how-to-get-values-from-appsettings-json-in-a-console-application-using-net-core

var monsterContextOptionsBuilder = new DbContextOptionsBuilder<MonsterContext>()
    .UseSqlServer(connString)
    .Options;

using (var monsterContext = new MonsterContext(monsterContextOptionsBuilder))
{
    monsterContext.Monsters.Add(new Monster()
    {
        Name = "Test Monster",
        Colour = "Red",
        IsScary = true
    });
    monsterContext.SaveChanges();

    var monsters = monsterContext.Monsters.ToList();
    foreach (var monster in monsters)
    {
        Console.WriteLine($"Hello {monster.Name}");
    }
}

Console.WriteLine("DONE");
Console.ReadKey();
using System.Data.Entity;
using SQLite.CodeFirst;

namespace Bible2PPT.Data
{
    class BibleContextDbConfiguration : DbConfiguration
    {
        public BibleContextDbConfiguration()
        {
            SetMigrationSqlGenerator("System.Data.SQLite", () => new SqliteMigrationSqlGenerator());
        }
    }
}

using ConnectDatabaseDbms.Models.DatabaseAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.BusinessModels
{
    public static class DatabaseAccessor
    {
        public static DatabaseConnection Instance { get; private set; }

        public static void InitDatabase(string connectionString)
        {
            Instance = new DatabaseConnection(connectionString);
        }
    }
}
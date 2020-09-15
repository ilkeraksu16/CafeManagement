using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Connection
{
    internal static class ConnectionFactory
    {
        public static DbConnection CreateDbConnection(string connectionIdentifier)
        {
            DbConnection dbConnection;

            var providerName = ConfigurationManager.ConnectionStrings[connectionIdentifier].ProviderName;

            var connectionString = ConfigurationManager.ConnectionStrings[connectionIdentifier].ConnectionString;

            if (connectionString == null) return null;

            try
            {
                var factory = DbProviderFactories.GetFactory(providerName);
                dbConnection = factory.CreateConnection();
                if (dbConnection != null)
                    dbConnection.ConnectionString = connectionString;
            }
            catch (Exception)
            {

                dbConnection = null;
            }
            return dbConnection;
        }
    }
}

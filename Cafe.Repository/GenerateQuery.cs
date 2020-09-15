using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    internal static class GenerateQuery<T> where T : class
    {
        private static IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        private static string tableName => typeof(T).Name;
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        public static string GenerateInsertQuery(bool getId)
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            if (getId)
            {
                insertQuery.Append(" SELECT CAST(SCOPE_IDENTITY() as int)");
            }

            return insertQuery.ToString();
        }
        public static string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);
            string whereState = "";
            properties.ForEach(property =>
            {
                if (!property.Equals("Id") && !property.Equals("id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
                else
                {
                    whereState = $" WHERE {property}=@{property}";
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }
    }
}

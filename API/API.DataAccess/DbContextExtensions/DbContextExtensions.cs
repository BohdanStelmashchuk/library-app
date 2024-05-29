using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.DbContextExtensions
{
    public static class DbContextExtensions
    {
        public static void ExecuteNonQuery(this DbContext context,
                                           string storedProcedureName,
                                           params object[] parameterValues)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (string.IsNullOrEmpty(storedProcedureName))
                throw new ArgumentNullException(nameof(storedProcedureName));
            if (storedProcedureName.ContainsWhiteSpace())
                throw new InvalidOperationException("Spaces are not allowed as store procedure name");

            using (DbCommand command = context.Database.GetDbConnection().CreateCommand())
            {
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;
                foreach (object parameterValue in parameterValues)
                    command.Parameters.Add(parameterValue);
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        private static bool ContainsWhiteSpace(this string value) => value.IndexOf(' ') != -1;

    }
}

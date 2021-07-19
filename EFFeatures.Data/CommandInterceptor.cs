using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Text;

namespace EFFeatures.Data
{
    public static class CommandInterceptor
    {
        private static Interceptor _interceptor;
        private static StringBuilder _log = new StringBuilder();

        public static void Run()
        {
            if (_interceptor == null)
            {
                _interceptor = new Interceptor();

                DbInterception.Add(_interceptor);
            }
        }

        public static string GetLog()
        {
            return _log.ToString();
        }

        class Interceptor : IDbCommandInterceptor
        {
            public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }

            public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }

            public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }

            public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }

            public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }

            public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                _log.AppendLine(command.CommandText);
            }
        }
    }
}

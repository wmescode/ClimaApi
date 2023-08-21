using Microsoft.Data.SqlClient;

namespace Clima.Infra.Data.Repositories
{
    public abstract class Repository
    {
        protected readonly SqlConnection _connection;
        //private readonly ILogger<Repository> _logger;

        protected Repository(SqlConnection connection)
        {
            _connection = connection;
        }
    }
}

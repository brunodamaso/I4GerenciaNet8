using Microsoft.Data.SqlClient;

namespace I4Gerencia.Services.RepositorySQL;
public interface IRepositorySQL : ISQLService
{
    SqlConnection GetConexion();
    Task<List<T>> ExecuteList<T>(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new();
    Task<T> Execute<T>(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new();
    Task<List<object>> ExecuteDataReader(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null);
    Task<List<dynamic>> ExecuteListDynamic(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null);
    Task<bool> ExecuteNonQuery(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null);
    Task<T> Get<T>(object key, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new();

}

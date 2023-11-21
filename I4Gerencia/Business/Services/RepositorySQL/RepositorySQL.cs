using I4Gerencia.Services.Settings;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace I4Gerencia.Services.RepositorySQL;
public class RepositorySQL : SQLService, IRepositorySQL
{
    private ISettingsService SettingsService;
    private ISQLService SQLService;

    public RepositorySQL(ISQLService _SQLService, ISettingsService _settingsService)
    {
        this.SettingsService = _settingsService;
        this.SQLService = _SQLService;
    }
    public SqlConnection GetConexion()
    {
        SqlConnection Connection = this.SQLService.GetConexion(this.SettingsService.ConnectionString);

        try
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message.ToString());
            Connection = null;
        }
        return Connection;
    }

    //public SqlTransaction BeginTransaction(SqlConnection sourceConnection)
    //{
    //    return this.SQLService.BeginTransaction(sourceConnection);
    //}

    //public bool EndTransaction(SqlTransaction sqlTransaction)
    //{
    //    return this.SQLService.EndTransaction(sqlTransaction);
    //}
    //public void Rollback(SqlTransaction sqlTransaction)
    //{
    //    this.SQLService.Rollback(sqlTransaction);
    //}


    public Task<List<T>> ExecuteList<T>(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new()
    {
        SqlConnection sourceConnection = GetConexion();
        return this.SQLService.ExecuteList<T>(stringCommand, sourceConnection, sqlTransaction, Parametros);
    }

    public Task<T> Execute<T>(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new()
    {
        SqlConnection sourceConnection = GetConexion();
        return this.SQLService.Execute<T>(stringCommand, sourceConnection, sqlTransaction, Parametros);
    }

    public async Task<List<object>> ExecuteDataReader(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null)
    {
        SqlConnection sourceConnection = GetConexion();
        return await this.SQLService.ExecuteDataReader(stringCommand, sourceConnection, sqlTransaction, Parametros);
    }
    public async Task<List<dynamic>> ExecuteListDynamic(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null)
    {
        SqlConnection sourceConnection = GetConexion();
        return await this.SQLService.ExecuteListDynamic(stringCommand, sourceConnection, sqlTransaction, Parametros);
    }
    public async Task<bool> ExecuteNonQuery(string stringCommand, SqlTransaction sqlTransaction = null, List<KeyValuePair<string, object>> Parametros = null)
    {
        SqlConnection sourceConnection = GetConexion();
        return await this.SQLService.ExecuteNonQuery(stringCommand, sourceConnection, sqlTransaction, Parametros);
    }
    public async Task<T> Get<T>(object key, List<KeyValuePair<string, object>> Parametros = null) where T : BaseModel, new()
    {
        SqlConnection sourceConnection = GetConexion();
        return await this.SQLService.Get<T>(key, sourceConnection, Parametros);
    }
}

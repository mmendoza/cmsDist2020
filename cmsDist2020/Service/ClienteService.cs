using cmsDist2020.Models;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Service
{
    public class ClienteService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ClientesEditModel> GetCliente(int Id)
        {
            ClientesEditModel clientes_model;
            var parameters = new DynamicParameters();
            parameters.Add("id_cliente", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    clientes_model = await conn.QueryFirstAsync<ClientesEditModel>("PA_CMS_GET_CLIENTE", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return clientes_model;
        }

        public async Task<IEnumerable<ColaboradorModel>> GetColaborador(int Id)
        {
            IEnumerable<ColaboradorModel> colaboradorModel;
            var parameters = new DynamicParameters();
            parameters.Add("IdColaborador", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    colaboradorModel = await conn.QueryAsync<ColaboradorModel>("PA_CMS_GET_COLABORADOR_ID", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return colaboradorModel;
        }
    }
}

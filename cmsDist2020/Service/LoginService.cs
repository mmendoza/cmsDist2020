using cmsDist2020.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Service
{
    public class LoginService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public LoginService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<LoginModel> Login_Access(string cod, string pass)
        {
            LoginModel login_model = new LoginModel();
            var parameters = new DynamicParameters();
            parameters.Add("RUC_DNI", cod, DbType.String);
            parameters.Add("CLAVE", pass, DbType.String);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                login_model = await conn.QueryFirstOrDefaultAsync<LoginModel>("PA_CMS_LOGIN_DISTRIBUIDORES", parameters, commandType: CommandType.StoredProcedure);
            }
            return login_model;
        }
    }
}

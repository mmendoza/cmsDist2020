using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using cmsDist2020.Models;

namespace cmsDist2020.Service
{
    public class ProductService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ProductService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<ProductModel>> Get_Products(int Id)
        {
            IEnumerable<ProductModel> product_model;
            var parameters = new DynamicParameters();
            parameters.Add("ID_DISTRIBUIDOR", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    product_model = await conn.QueryAsync<ProductModel>("PA_CMS_PRODUCTOS_DISPONIBLES", parameters, commandType: CommandType.StoredProcedure);
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
            return product_model;
        }

    }
}

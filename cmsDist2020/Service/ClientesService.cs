﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsDist2020.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace cmsDist2020.Service
{
    public class ClientesService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ClientesService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ClientesModel>> Get_Clientes(int Id)
        {
            IEnumerable<ClientesModel> clientes_model;
            var parameters = new DynamicParameters();
            parameters.Add("ID_DISTRIBUIDOR", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    clientes_model = await conn.QueryAsync<ClientesModel>("PA_CMS_LISTA_CLIENTES", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<ColaboradorModel>> GetColaboradores(int Id)
        {
            IEnumerable<ColaboradorModel> colaboradores;
            var parameters = new DynamicParameters();
            parameters.Add("id_distribuiudor", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    colaboradores = await conn.QueryAsync<ColaboradorModel>("PA_CMS_COLABORADORES", parameters, commandType: CommandType.StoredProcedure);
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
            return colaboradores;
        }

            public async Task<List<ProductosModel>> GetProductos(int IdProducto, int IdDistribuidor)
        {
            List<ProductosModel> productosModels;
            var parameters = new DynamicParameters();
            parameters.Add("id_distribuidor", IdDistribuidor, DbType.Int32);
            parameters.Add("id_producto", IdProducto, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var _result = await conn.QueryAsync<ProductosModel>("PA_CMS_LISTA_CONTRATOS", parameters, commandType: CommandType.StoredProcedure);
                    productosModels = _result.ToList();
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
            return productosModels;
        }

        public async Task<ProductosModel> GetProductoId(double IdProducto, int IdDistribuidor, double IdContrato)
        {
            ProductosModel productosModels = new ProductosModel();
            var parameters = new DynamicParameters();
            parameters.Add("id_distribuidor", IdDistribuidor, DbType.Int32);
            parameters.Add("id_producto", IdProducto, DbType.Double);
            parameters.Add("IdContrato", IdContrato, DbType.Double);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    productosModels = await conn.QueryFirstOrDefaultAsync<ProductosModel>("PA_CMS_LISTA_CONTRATO_ID", parameters, commandType: CommandType.StoredProcedure);
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
            return productosModels;
        }

        public String _Numero_pin(string _producto)
        {
            string _existe_pin_ = "";
            string _data_ = "";
            Int32 _LARGO_NUMERO_PIN_ = 8;
            //se adiciona alguna información y la fecha
            do
            {
                _data_ = Numero_aleatorio(_LARGO_NUMERO_PIN_);
                _existe_pin_ = pa_existe_nro_pin(_producto, _data_);
            } while (_existe_pin_ != "NO");
            return _data_;
        }

        public String pa_creacion_pines(string TipoUsuario, string PassTipoUsuario, string TipoUsuarioWeb, string PassTipoUsuarioWeb,
  string TipoUsuarioApp, string PassTipoUsuarioApp, string usrInfocontable, string passInfocontable,
string usrebookweb, string passebookweb, string nro_pin, string DET_SUSC, DateTime fechA_baja,
double idProducto, string nro_contrato, double id_suscripcion, double idContrato, double IdDistribuidor)
        {
            SqlConnection dataConnection = new SqlConnection(_configuration.Value);
            SqlCommand dataCommand = new SqlCommand("PA_CMS_CREA_PINES", dataConnection);
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
            dataCommand.Parameters.AddWithValue("@PassTipoUsuario", PassTipoUsuario);
            dataCommand.Parameters.AddWithValue("@TipoUsuarioWeb", TipoUsuarioWeb);
            dataCommand.Parameters.AddWithValue("@PassTipoUsuarioWeb", PassTipoUsuarioWeb);
            dataCommand.Parameters.AddWithValue("@TipoUsuarioApp", TipoUsuarioApp);
            dataCommand.Parameters.AddWithValue("@PassTipoUsuarioApp", PassTipoUsuarioApp);
            dataCommand.Parameters.AddWithValue("@usrInfocontable", usrInfocontable);
            dataCommand.Parameters.AddWithValue("@passInfocontable", passInfocontable);
            dataCommand.Parameters.AddWithValue("@usrebookweb", usrebookweb);
            dataCommand.Parameters.AddWithValue("@passebookweb", passebookweb);
            dataCommand.Parameters.AddWithValue("@nro_pin", nro_pin);
            dataCommand.Parameters.AddWithValue("@DET_SUSC", DET_SUSC);
            dataCommand.Parameters.AddWithValue("@fechA_baja", fechA_baja);
            dataCommand.Parameters.AddWithValue("@idProducto", idProducto);
            dataCommand.Parameters.AddWithValue("@nro_contrato", nro_contrato);
            dataCommand.Parameters.AddWithValue("@id_suscripcion", id_suscripcion);
            dataCommand.Parameters.AddWithValue("@idContrato", idContrato);
            dataCommand.Parameters.AddWithValue("@Id_Distribuidor", IdDistribuidor);
            SqlParameter ParamError = new SqlParameter("@error", SqlDbType.VarChar, 200);
            ParamError.Direction = ParameterDirection.Output;
            dataCommand.Parameters.Add(ParamError);
            dataConnection.Open();
            dataCommand.ExecuteScalar();
            dataConnection.Close();
            string err = ParamError.Value.ToString();
            return err;

        }

        public String pa_habilita_desabilita_pines(string TipoUsuario, string nro_pin, 
            string nro_contrato, double id_suscripcion, double idContrato, string _hab_des)
        {
            SqlConnection dataConnection = new SqlConnection(_configuration.Value);
            SqlCommand dataCommand = new SqlCommand("PA_CMS_HABILITA_DESABILITA_PINES", dataConnection);
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
            dataCommand.Parameters.AddWithValue("@nro_pin", nro_pin);
            dataCommand.Parameters.AddWithValue("@nro_contrato", nro_contrato);
            dataCommand.Parameters.AddWithValue("@id_suscripcion", id_suscripcion);
            dataCommand.Parameters.AddWithValue("@idContrato", idContrato);
            dataCommand.Parameters.AddWithValue("@hab_des", _hab_des);
            SqlParameter ParamError = new SqlParameter("@error", SqlDbType.VarChar, 200);
            ParamError.Direction = ParameterDirection.Output;
            dataCommand.Parameters.Add(ParamError);
            dataConnection.Open();
            dataCommand.ExecuteScalar();
            dataConnection.Close();
            string err = ParamError.Value.ToString();
            return err;

        }



        public string pa_existe_nro_pin(string _producto, string _NROPIN)
        {

            SqlConnection dataConnection = new SqlConnection(_configuration.Value);
            SqlCommand dataCommand = new SqlCommand("all_process.dbo.pa_existe_nro_pin", dataConnection);
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.Parameters.AddWithValue("@producto", _producto);
            dataCommand.Parameters.AddWithValue("@nro_pin", _NROPIN);
            SqlParameter ParamError = new SqlParameter("@EXISTE", SqlDbType.VarChar, 200);
            ParamError.Direction = ParameterDirection.Output;
            dataCommand.Parameters.Add(ParamError);
            dataConnection.Open();
            dataCommand.ExecuteScalar();
            dataConnection.Close();
            string err = ParamError.Value.ToString();
            return err;
        }

        public DataSet paLeeTipoProducto(double IdProducto)
        {
            SqlConnection dataConnection = new SqlConnection(_configuration.Value);
            SqlCommand dataCommand = new SqlCommand("PA_CMS_LEE_TIPO_PRODUCTO", dataConnection);
            dataCommand.CommandTimeout = 220;
            dataCommand.CommandType = CommandType.StoredProcedure;
            dataCommand.Parameters.AddWithValue("@idSuscripcion", IdProducto);
            SqlDataAdapter adp = new SqlDataAdapter(dataCommand);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
            //Conexion.GDatos.TraerDataSet("PA_CLIENTES_ESTADOS_CUENTA");
        }


        private string Numero_aleatorio(int _lenght_)
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            if (justNumbers.Length < _lenght_)
            {
                justNumbers = justNumbers + ("0000000000").Substring(0, _lenght_ - justNumbers.Length);
            }
            var seed = justNumbers.Substring(0, _lenght_);
            return seed.ToString();
        }

    }
}

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
    public class ClientesAddService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ClientesAddService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SaveColaboradores(int id, ColaboradorModel colaboradorModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Nombre", colaboradorModel.Nombre, DbType.String);
            parameters.Add("Direccion", colaboradorModel.Direccion, DbType.String);
            parameters.Add("Correo", colaboradorModel.Correo, DbType.String);
            parameters.Add("Telefono", colaboradorModel.Telefono, DbType.String);
            parameters.Add("IdDistribuidor", colaboradorModel.IdDistribuidor, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync("paSaveColaboradores", parameters, commandType: CommandType.StoredProcedure);
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
            return true;
        }

        public async Task<bool> EditClientes(int id, ClientesEditModel clientesEditModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("RucDni", clientesEditModel.RucDni, DbType.String);
            parameters.Add("Nombre", clientesEditModel.Nombre, DbType.String);
            parameters.Add("ApePat", clientesEditModel.ApePat, DbType.String);
            parameters.Add("Apemat", clientesEditModel.Apemat, DbType.String);
            parameters.Add("Direccion", clientesEditModel.Direccion, DbType.String);
            parameters.Add("IdDist", clientesEditModel.IdDist, DbType.String);
            parameters.Add("Telefonos", clientesEditModel.Telefonos, DbType.String);
            parameters.Add("Email01", clientesEditModel.Email01, DbType.String);
            parameters.Add("Email02", clientesEditModel.Email02, DbType.String);
            parameters.Add("Email03", clientesEditModel.Email03, DbType.String);
            parameters.Add("IdEstado", clientesEditModel.IdEstado, DbType.Int32);
            parameters.Add("IdDistribuidor", clientesEditModel.IdDistribuidor, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync("pa_save_clientes", parameters, commandType: CommandType.StoredProcedure);
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
            return true;
        }

        public async Task<bool> SaveContratos(int id, ContratoModel contratoModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("IdCliente", contratoModel.IdCliente, DbType.String);
            parameters.Add("IdProducto", contratoModel.IdProducto, DbType.String);
            parameters.Add("NroContrato", contratoModel.NroContrato, DbType.String);
            parameters.Add("NroCuotas", contratoModel.NroCuotas, DbType.String);
            parameters.Add("IdEstadoContrato", "1", DbType.String);
            parameters.Add("IdColaborador", contratoModel.IdColaborador, DbType.String);
            parameters.Add("idDistribuidor", contratoModel.IdDistribuidor, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync("PA_SAVE_CONTRATOS", parameters, commandType: CommandType.StoredProcedure);
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
            return true;
        }

        public async Task<ColaboradorModel> GetColaboradorId(int Id)
        {
            ColaboradorModel colaboradorModels = new ColaboradorModel();
            var parameters = new DynamicParameters();
            parameters.Add("IdColaborador", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    colaboradorModels = await conn.QueryFirstAsync<ColaboradorModel>("pa_colaborador", parameters, commandType: CommandType.StoredProcedure);
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
            return colaboradorModels;
        }

        public async Task<ContratoModel> GetContratoId(int Id)
        {
            ContratoModel contratoModel = new ContratoModel();
            var parameters = new DynamicParameters();
            parameters.Add("id", Id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    contratoModel = await conn.QueryFirstAsync<ContratoModel>("pa_Contrato_id", parameters, commandType: CommandType.StoredProcedure);
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
            return contratoModel;
        }


        public async Task<List<DptoModel>> ReadDptos()
        {
            //DptoModel dptoModels = new DptoModel();
            List<DptoModel> dptoModel;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var Resultados = await conn.QueryAsync<DptoModel>("pa_departamentos", commandType: CommandType.StoredProcedure);
                    dptoModel = Resultados.ToList();
                    //dptoModels = dptoModel;
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
            return dptoModel;
        }

        public async Task<IEnumerable<CiudadModel>> ReadCiudades()
        {
            IEnumerable<CiudadModel> ciudadModels;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    ciudadModels = await conn.QueryAsync<CiudadModel>("pa_ciudades", commandType: CommandType.StoredProcedure);
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
            return ciudadModels;
        }

        public async Task<List<ProvModel>> ReadProvs(string IdDpdto)
        {
            List<ProvModel> provModels = new List<ProvModel>();
            var parameters = new DynamicParameters();
            parameters.Add("IdDpto", IdDpdto, DbType.String);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var provModel = await conn.QueryAsync<ProvModel>("pa_provincias", parameters, commandType: CommandType.StoredProcedure);
                    provModels = provModel.ToList();
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
            return provModels;
        }

        public async Task<List<DistModel>> ReadDists(string IdProv)
        {
            List<DistModel> distModels = new List<DistModel>();
            var parameters = new DynamicParameters();
            parameters.Add("IdProv", IdProv, DbType.String);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var distModel = await conn.QueryAsync<DistModel>("pa_distritos", parameters, commandType: CommandType.StoredProcedure);
                    distModels = distModel.ToList();
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
            return distModels;
        }

        public async Task<List<EstadoModel>> ReadEstados()
        {
            List<EstadoModel> estadoModels = new List<EstadoModel>();
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var estadoModel = await conn.QueryAsync<EstadoModel>("pa_estado_clientes", commandType: CommandType.StoredProcedure);
                    estadoModels = estadoModel.ToList();
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
            return estadoModels;
        }

        public async Task<List<ClienteSelectModel>> ReadClientes(int IdDistribuidor)
        {
            List<ClienteSelectModel> clienteSelectModel = new List<ClienteSelectModel>();
            var parameters = new DynamicParameters();
            parameters.Add("id_distribuidor", IdDistribuidor, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var estado = await conn.QueryAsync<ClienteSelectModel>("pa_Lista_Clientes", parameters, commandType: CommandType.StoredProcedure);
                    clienteSelectModel = estado.ToList();
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
            return clienteSelectModel;
        }

        public async Task<List<ColaboradorSelectModel>> ReadColaboradores(int IdDistribuidor)
        {
            List<ColaboradorSelectModel> colaboradorSelectModels = new List<ColaboradorSelectModel>();
            var parameters = new DynamicParameters();
            parameters.Add("id_distribuidor", IdDistribuidor, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var colaborador = await conn.QueryAsync<ColaboradorSelectModel>("pa_lista_Colaboradores", parameters, commandType: CommandType.StoredProcedure);
                    colaboradorSelectModels = colaborador.ToList();
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
            return colaboradorSelectModels;
        }

    }
}

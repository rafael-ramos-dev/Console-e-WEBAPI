using Cadastro.Model;
using Cadastro.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Data.Cliente
{
    public class ClienteData
    {

        object _Locker = new object();
        //IMPLEMENTAR AQUI A CAMADA DE DADOS ADO
        public ClienteModel GetByCodigo(int codigo)
        {
            lock (_Locker)
            {
                lock (_Locker)
                {
                    string SQL = $"SELECT * FROM CLIENTE WHERE CODIGO = {codigo}";

                    var database = Factory.DatabaseFactory.BuildDatabase();
                    var currentConnection = database.GetCurrentConnection();
                    ClienteModel result = new ClienteModel();
                    try
                    {
                        var command = currentConnection.CreateCommand();
                        command.CommandText = SQL;
                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            result.Codigo = reader.GetInt32(0);
                            result.CNPJ = reader.GetString(1);
                            result.Nome = reader.GetString(2);
                        }

                        currentConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (currentConnection.State == System.Data.ConnectionState.Open)
                            currentConnection.Close();
                    }

                    return null;
                }
            }
            
        }

        public ClienteModel GetByCNPJ(string cnpj)
        {
            lock (_Locker)
            {
                string SQL = $"SELECT * FROM CLIENTE WHERE CNPJ = '{cnpj}'";

                var database = Factory.DatabaseFactory.BuildDatabase();
                var currentConnection = database.GetCurrentConnection();
                ClienteModel result = new ClienteModel();
                try
                {
                    var command = currentConnection.CreateCommand();
                    command.CommandText = SQL;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        result.Codigo = reader.GetInt32(0);
                        result.CNPJ = reader.GetString(1);
                        result.Nome = reader.GetString(2);
                    }

                    currentConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if(currentConnection.State == System.Data.ConnectionState.Open)
                        currentConnection.Close();
                }
                
                return null;
            }
            
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            lock (_Locker)
            {
                lock (_Locker)
                {
                    string SQL = $"SELECT * FROM CLIENTE";

                    var database = Factory.DatabaseFactory.BuildDatabase();
                    var currentConnection = database.GetCurrentConnection();
                    List<ClienteModel> result = new List<ClienteModel>();
                    try
                    {
                        var command = currentConnection.CreateCommand();
                        command.CommandText = SQL;
                        using (var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                var cliente = new ClienteModel();
                                cliente.Codigo = reader.GetInt32(0);
                                cliente.CNPJ = reader.GetString(1);
                                cliente.Nome = reader.GetString(2);
                                
                                result.Add(cliente);
                            }
                            
                        }

                        currentConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (currentConnection.State == System.Data.ConnectionState.Open)
                            currentConnection.Close();
                    }

                    return result;
                }
            }
            
        }

        public bool Create(ClienteModel model)
        {
            lock (_Locker)
            {
                string SQL = $"INSERT INTO CLIENTE ( CNPJ, NOME) VALUES ('{model.CNPJ}','{model.Nome}')"; 

                var database = Factory.DatabaseFactory.BuildDatabase();
                var currentConnection = database.GetCurrentConnection();
                bool result = false;
                try
                {
                    var command = currentConnection.CreateCommand();
                    command.CommandText = SQL;
                    result = command.ExecuteNonQuery() > 0;
                    currentConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (currentConnection.State == System.Data.ConnectionState.Open)
                        currentConnection.Close();
                }

                return result;
            }
            
        }
    }
}

using Cadastro.Models.Cliente;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Monitor.App.Cadastro
{
    public static class CadastroManager
    {
        public static void DoCadastro(string Filename)
        {
            bool Success = false;
            
            var client = new RestClient("https://localhost:44338");
            var request = new RestRequest("/api/cliente", Method.POST);
            var cadastroCliente = ReadClienteDoArquivo(Filename);
            
            request.AddJsonBody(JsonConvert.SerializeObject(cadastroCliente));
            var response = client.Execute<CadastroResultModel>(request);
            Success = response.StatusCode == System.Net.HttpStatusCode.OK;
            if(Success)
            {
                Console.WriteLine("Sucesso");
            }
            else
            {
                Console.WriteLine("Erro"); 
            }
        }

        private static ClienteModel ReadClienteDoArquivo(string FileName)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteModel>(File.ReadAllText(FileName));
        }
    }
}

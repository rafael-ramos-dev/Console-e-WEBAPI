using Cadastro.Model;
using Cadastro.Models.Cliente;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Business.Cliente
{
    public class ClienteBusiness
    {
        Data.Cliente.ClienteData _clienteData;
        public ClienteBusiness()
        {
            _clienteData = new Data.Cliente.ClienteData();
        }
        
        public bool Cadastrar(ClienteModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CNPJ)) throw new Model.CustomException.Cliente.CNPJVazioException("CNPJ não pode ser Vazio");
                if (string.IsNullOrEmpty(model.Nome)) throw new Model.CustomException.Cliente.NomeVazioException("Nome não pode ser Vazio");
                if (_clienteData.GetByCNPJ(model.CNPJ) != null) throw new Model.CustomException.Cliente.CNPJDuplicadoException($"o CNPJ {model.CNPJ} já está cadastrado.");
               
                return _clienteData.Create(model);
            }
            catch (Exception ex)
            {
                EscreverArquivoTemporario(ex.Message, model);
                throw ex;
            }
            
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return this._clienteData.GetAll();
        }

        public ClienteModel GetByCodigo(int Codigo)
        {
            return this._clienteData.GetByCodigo(Codigo);
        }
        public ClienteModel GetByCNPJ(string cnpj)
        {
            return this._clienteData.GetByCNPJ(cnpj);
        }

        private void EscreverArquivoTemporario(string message, ClienteModel model)
        {
            if(!Directory.Exists(@".\error\"))
                Directory.CreateDirectory(@".\error\");

            File.AppendAllText(@".\error\erro_cadastros.txt", "reason: " + message + "\r\n" +  Newtonsoft.Json.JsonConvert.SerializeObject(model) + "\r\n" );
        }
    }
}

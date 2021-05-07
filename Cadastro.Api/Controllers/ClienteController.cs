using Cadastro.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cadastro.Api.Controllers
{
    public class ClienteController : ApiController
    {
        Business.Cliente.ClienteBusiness _clienteBusiness;
        public ClienteController()
        {
            _clienteBusiness = new Business.Cliente.ClienteBusiness();
        }

        //api/cliente
        [Route("")]
        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            return _clienteBusiness.GetAll();
        }
        //api/cliente/codigo/1
        [Route("codigo/{codigo}")]
        [HttpGet]
        public object GetByCodigo(int codigo)
        {
            return _clienteBusiness.GetByCodigo(codigo);
        }

        //api/cliente/codigo/123.123.123.123-12
        [Route("cnpj/{cnpj}")]
        [HttpGet]
        public object GetByCNPJ(string cnpj)
        {
            return _clienteBusiness.GetByCNPJ(cnpj);
        }

        //api/cliente
        [Route("")]
        [HttpPost]
        public CadastroResultModel CadastrarCliente([FromBody] ClienteModel clienteModel)
        {
            bool success = false;
            string reason = "";
            try
            {
                success = _clienteBusiness.Cadastrar(clienteModel);
            }
            catch (Model.CustomException.Cliente.CNPJDuplicadoException ex)
            {
                reason = ex.Message;
            }
            catch (Model.CustomException.Cliente.CNPJVazioException ex)
            {
                reason = ex.Message;
            }
            catch (Model.CustomException.Cliente.NomeVazioException ex)
            {
                reason = ex.Message;
            }
            catch (Exception)
            {
                reason = "Erro ao efetuar cadatro;";
            }

            return new CadastroResultModel() {
                Message = reason,
                Success = success,
                ResultModel = clienteModel
            };
        }
       
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCSharp.Models;

namespace WebApiCSharp.Controllers
{
    public class VeiculosController : ApiController
    {


        //GET api/veiculos
        public List<Veiculos> Get()
        {
            var listaVeiculos = Veiculos.GetVeiculos();

            return listaVeiculos;
        }

        // GET api/veiculos/5
        public Veiculos Get(int id)
        {
            var veiculos = new  Veiculos();
            veiculos.GetVeiculo(id);

            return veiculos;
        }

        // POST api/veiculos
        public JObject Post([FromBody] Veiculos veiculo)
        {
            var resultado = "";
          
            if(veiculo == null)
                resultado = "{resultado: \"Faltou parametro no body\"}";
            else if (veiculo.Id != 0)
                resultado = "{resultado: \"Id deve ser zero\"}";
            else if (String.IsNullOrEmpty(veiculo.Marca))
                resultado += "{resultado : \"Marca deve ser informada\"}";
            else if(veiculo.Valor == 0)
                resultado += "{resultado : \"Valor não pode ser nulo nem zero\"}";

            if (String.IsNullOrEmpty(resultado))
            {
                var veiculoNovo = new Veiculos();
                resultado = veiculo.Salvar(veiculo);
                resultado = "{resultado: \""+ resultado +"\"}";
            }
           return JObject.Parse(resultado);
        }

        // PUT api/veiculos/5
        public JObject Put(int id, [FromBody] Veiculos veiculo)
        {
            var resultado = "";

            var vei = new Veiculos();
            veiculo.Id = id;
            resultado = vei.Salvar(veiculo);
            resultado = "{resultado: \"" + resultado + "\"}";

            return JObject.Parse(resultado);
        }

        //api/veiculos/id
        public JObject Delete(int id)
        {           

            var vei = new Veiculos();
            var resultado = vei.Excluir(id);
            resultado = "{resultado: \"" + resultado + "\"}";

            return JObject.Parse(resultado);
        }
    }
}

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

         public static List<Veiculos> listaVeiculos = new List<Veiculos>();


        [HttpGet]
        [Route("api/veiculos/popular")]
        public JObject Popular()
        {
            listaVeiculos.Add(new Veiculos(1, "FORD FIESTA", "1.0 MPI PERSONALITÉ SEDAN 4P", 2005, 2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(2, "Kia Cerato", "1.6 EX3 SEDAN 16V 4P A", 2014, 2015, "Prata", 3, true, 35000, true));
            listaVeiculos.Add(new Veiculos(6, "HYUNDAI HB20", "1.0 COMFORT 12V FLEX 4P", 2017, 2017, "Azul", 3, true, 43000, true));
            listaVeiculos.Add(new Veiculos(12, "CHEVROLET PRISMA", "1.4 MPFI LT BV FLEX 4P", 2013, 2013, "Preto", 3, true, 31000, true));
            listaVeiculos.Add(new Veiculos(27, "VOLKSVAGEN POLO", "1.0 200 TSI HIGHLINE", 2018, 2018, "Amarelo", 3, true, 66045, true));

            var resultado = JObject.Parse("{resultado : \"populado\"}");
            return resultado;
        }

        // GET api/veiculos
        public List<Veiculos> Get()
        {
            return listaVeiculos;
           
        }

        // GET api/veiculos/5
        public Veiculos Get(int id)
        {
            return listaVeiculos.Find(x => x.Id.Equals(id));
        }

        // POST api/veiculos
        public JObject Post([FromBody] Veiculos veiculo)
        {
            var resultado = "";
            if (veiculo.Id == 0)
                resultado = "{resultado: \"Id não pode ser nulo nem zero\"}";
            else if (String.IsNullOrEmpty(veiculo.Marca))
                resultado += "{resultado : \"Marca deve ser informada\"}";
            else if(veiculo.Valor == 0)
                resultado += "{resultado : \"Valor não pode ser nulo nem zero\"}";

            if (String.IsNullOrEmpty(resultado))
            {
                listaVeiculos.Add(new Veiculos(veiculo.Id, veiculo.Marca, veiculo.Modelo, veiculo.Ano, veiculo.Fabricacao, veiculo.Cor, veiculo.Combustivel,
                veiculo.Automatico, veiculo.Valor, veiculo.Ativo));

                resultado = "{resultado: \"OK\"}";
            }
           return JObject.Parse(resultado);
        }

        // PUT api/veiculos/5
        public void Put(int id, [FromBody] Veiculos veiculo)
        {
            var vei = listaVeiculos.Single(x => x.Id.Equals(id));

            vei.Marca = veiculo.Marca;
            vei.Modelo = veiculo.Modelo;
            vei.Ano = veiculo.Ano;
            vei.Fabricacao = veiculo.Fabricacao;
            vei.Cor = veiculo.Cor;
            vei.Combustivel = veiculo.Combustivel;
            vei.Automatico = veiculo.Automatico;
            vei.Valor = veiculo.Valor;
            vei.Ativo = veiculo.Ativo;
           

        }


        public void Delete(int id)
        {
            var item = listaVeiculos.FindIndex(x => x.Id.Equals(id));
            listaVeiculos.RemoveAt(item);
          
        }
    }
}

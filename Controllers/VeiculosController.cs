using Newtonsoft.Json;
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
        public string Popular()
        {
            listaVeiculos.Add(new Veiculos(1, "FORD FIESTA", "1.0 MPI PERSONALITÉ SEDAN 4P", 2005, 2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(2, "Kia Cerato", "1.6 EX3 SEDAN 16V 4P A", 2014, 2015, "Prata", 3, true, 35000, true));
            listaVeiculos.Add(new Veiculos(6, "HYUNDAI HB20", "1.0 COMFORT 12V FLEX 4P", 2017, 2017, "Azul", 3, true, 43000, true));
            listaVeiculos.Add(new Veiculos(12, "CHEVROLET PRISMA", "1.4 MPFI LT BV FLEX 4P", 2013, 2013, "Preto", 3, true, 31000, true));
            listaVeiculos.Add(new Veiculos(27, "VOLKSVAGEN POLO", "1.0 200 TSI HIGHLINE", 2018, 2018, "Amarelo", 3, true, 66045, true));

            return "Populado";
        }

        // GET api/veiculos
        public string Get()
        {
            return JsonConvert.SerializeObject(listaVeiculos);
           
        }

        // GET api/veiculos/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(listaVeiculos.Find(x => x.Id.Equals(id)));
        }

        // POST api/veiculos
        public void Post([FromBody] string value)
        {
        }

        // PUT api/veiculos/5
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpGet]
        [Route("api/veiculos/excluir/{id}")]
        // DELETE api/veiculos/5
        public string Excluir(int id)
        {
            var veiculo = listaVeiculos.Single(x => x.Id.Equals(id));
            listaVeiculos.Remove(veiculo);

            return "Excluido";
        }
    }
}

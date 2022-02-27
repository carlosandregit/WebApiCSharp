using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCSharp.Models
{
    public class Veiculos
    {

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short Ano { get; set; }
        public short Fabricacao { get; set; }
        public string Cor { get; set; }
        public byte Combustivel { get; set; }
        public bool Automatico { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }


        public Veiculos(int id, string marca, string modelo, short ano, short fabricacao, string cor,
            byte combustivel, bool automatico, decimal valor, bool ativo)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Fabricacao = fabricacao;
            Cor = cor;
            Combustivel = combustivel;
            Automatico = automatico;
            Valor = valor;
            Ativo = ativo;

        }
    }
}
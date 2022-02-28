using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

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

        public Veiculos()
        {

        }

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
        private readonly static string _conn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public static List<Veiculos> GetVeiculos()
        {
            var listaCarros = new List<Veiculos>();
            var sql = "select * from Veiculos";

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaCarros.Add(new Veiculos(
                                       Convert.ToInt32(dr["Id"]),
                                        dr["Nome"].ToString(),
                                        dr["Modelo"].ToString(),
                                        Convert.ToInt16(dr["Ano"]),
                                        Convert.ToInt16(dr["Fabricacao"]),
                                        dr["Cor"].ToString(),
                                        Convert.ToByte(dr["Combustivel"]),
                                        Convert.ToBoolean(dr["Automatico"]),
                                        Convert.ToDecimal(dr["Valor"]),
                                        Convert.ToBoolean(dr["Ativo"])
                                        ));
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return listaCarros;
        }

        public string Salvar(Veiculos veiculo)
        {
            var sql = "";

            if(veiculo.Id == 0)            
                sql = "INSERT INTO Veiculos(nome,  modelo,  ano,  fabricacao,  cor, combustivel,  automatico,  valor,  ativo)" +
                    "VALUES (@nome,  @modelo,  @ano,  @fabricacao,  @cor, @combustivel,  @automatico,  @valor,  @ativo)";

  
            else          
                sql = "UPDATE Veiculos SET nome=@nome,  modelo=@modelo,  ano=@ano,  fabricacao=@fabricacao,  cor=@cor, combustivel=@combustivel,  automatico=@automatico,  valor=@valor,  ativo=@ativo " +
                    " WHERE id = " + veiculo.Id;

                try
                {
                    using (var cn = new SqlConnection(_conn))
                    {
                        cn.Open();
                        using (var cmd = new SqlCommand(sql, cn))
                        {

                            cmd.Parameters.AddWithValue("@nome", veiculo.Marca);
                            cmd.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                            cmd.Parameters.AddWithValue("@ano", veiculo.Ano);
                            cmd.Parameters.AddWithValue("@fabricacao", veiculo.Fabricacao);
                            cmd.Parameters.AddWithValue("@cor", veiculo.Cor);
                            cmd.Parameters.AddWithValue("@combustivel", veiculo.Combustivel);
                            cmd.Parameters.AddWithValue("@automatico", veiculo.Automatico);
                            cmd.Parameters.AddWithValue("@valor", veiculo.Valor);
                            cmd.Parameters.AddWithValue("@ativo", veiculo.Ativo);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    return "ok";

                }
                catch (Exception ex)
                {
                    return "Falha: " + ex.Message;
                }
            
        }

        public string Excluir(int id)
        {
            var sql = "DELETE FROM Veiculos WHERE id = " + id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Excluido";
            }
            catch (Exception ex)
            {
               return "Falha: " + ex.Message;
            }
        }
        public void GetVeiculo(int id)
        {
            var sql = "select nome,  modelo,  ano,  fabricacao,  cor, combustivel,  automatico,  valor,  ativo from Veiculos " +
                "where id = " + id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    Id = id;
                                    Marca = dr["Nome"].ToString();
                                    Modelo = dr["Modelo"].ToString();
                                    Ano = Convert.ToInt16(dr["Ano"]);
                                    Fabricacao = Convert.ToInt16(dr["Fabricacao"]);
                                    Cor = dr["Cor"].ToString();
                                    Combustivel = Convert.ToByte(dr["Combustivel"]);
                                    Automatico = Convert.ToBoolean(dr["Automatico"]);
                                    Valor = Convert.ToDecimal(dr["Valor"]);
                                    Ativo = Convert.ToBoolean(dr["Ativo"]);

                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }
    }
}
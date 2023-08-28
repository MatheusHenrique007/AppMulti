using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using AppMulti.Models;
using System.Data;

namespace AppMulti.Controller
{
    public class MySQLCon
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_Matheus;user id=freedb_Matheus Henrique;password=27F8Qu@$qW67xjg;charset=utf8";

        public static List<Cliente> listacliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "SELECT * FROM cliente";
            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente()
                            {
                                id = reader.GetInt32(0),
                                nome = reader.GetString(1),
                                celular = reader.GetString(2)
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
                con.Close();
                return clientes;
            }
        }

        public static void Inserir(string nome, string celular)
        {
            string sql = "INSERT INTO cliente(nome,celular) VALUES (@nome,@celular)";
            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = celular;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void Atualizar(Cliente cliente)
        {
            string sql = "UPDATE cliente SET nome=@nome,celular=@celular WHERE id=@id";
            try
            {
                using(MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using(MySqlCommand cmd = new MySqlCommand(sql,con))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.nome;
                        cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = cliente.celular;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = cliente.id;
                        cmd.CommandType= CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void Excluir(Cliente cliente)
        {
            string sql = "DELETE FROM cliente WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = cliente.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}


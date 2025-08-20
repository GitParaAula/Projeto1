using MySql.Data.MySqlClient;
using System;

namespace Projeto1
{
    class Conexao
    {
        //INTÂNCIA, O ATO DE APELIDAR
        MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=BDProjeto;user=root;pwd=12345678");
        //variavel do tipo string(texto), que é publica e de tipo estatico
        public static string msg;
        public MySqlConnection ConnectarBD()
        {
            //tratamento de erros
            try
            {
                con.Open();

            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return con;
        }

        public MySqlConnection DesConnectarBD()
        {
            try
            {
                con.Close();

            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se desconectar" + erro.Message;
            }
            return con;
        }
    }
}

using MySql.Data.MySqlClient;
using projetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projetoClinica.Dados
{
    public class AcoesEspecialidades
    {
        conexao con = new conexao();
        public void inserirEsp(ModelEspecialidade cmEsp) //Método para inserir especialidade
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbEspecialidade values (default, @Especialidade)", con.MyConectarBD());
            cmd.Parameters.Add("@Especialidade", MySqlDbType.VarChar).Value = cmEsp.Esp;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaEsp()//Método de consulta do tipo da especialidade
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbEspecialidade", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Especialidade = new DataTable();
            da.Fill(Especialidade);
            con.MyDesconectarBD();
            return Especialidade;
        }
    }
}
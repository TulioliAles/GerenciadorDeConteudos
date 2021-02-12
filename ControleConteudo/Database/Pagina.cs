using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection conection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, conection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Demo1
{
    public class Read_Write2Sql
    {
        private string connectionString = "";

        public Read_Write2Sql(string connection)
        {
            connectionString = connection;
        }

        public void WriteIt()
        {
            string word2Write = "";
            string SQL_WiteIt = "INSERT INTO testdata VALUES(@word2Write);";

            while (true)
            {
                Console.WriteLine("Enter word to write to SQL or [quit]");
                word2Write = Console.ReadLine();
                if (word2Write == "quit")
                {
                    return;
                }
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(SQL_WiteIt, conn);
                        cmd.Parameters.AddWithValue("@word2Write", word2Write);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void ReadIt()
        {
            string line2Print = "";
            string SQL_ReadIt = "SELECT * FROM testdata;";

            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ReadIt, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine();
                    Console.WriteLine("----Data Base Contents---");

                    while (reader.Read())
                    {
                        line2Print = reader["data"].ToString();
                        Console.WriteLine(line2Print);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConADO_Example5._1
{
    class Program
    {
        static void Main(string[] args)
        {
           string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
           "AttachDbFilename=F:\\ConsoleAppADONetHandMadeConnect\\ConsoleAppADONetHandMadeConnect\\LocalDB.mdf;Integrated Security = True; Connect Timeout = 30";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                //first mode
                /*
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "Select count(*) from Demo";
                sqlCommand.CommandType.StoreProcedure;
                */

                //second mode
                //SqlCommand command = new SqlCommand("Select count(*) from Demo", connection);

                //third mode
                SqlCommand command = connection.CreateCommand();
                //command.CommandText = "Select count(*) from Demo";
                command.CommandText = "select * from demo;";
                connection.Open();
                //Console.WriteLine("Average count row in Demo is " + (int)command.ExecuteScalar());
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        Console.WriteLine("Demo: " + dataReader.GetInt32(0) +
                            " and Description: " + dataReader.GetString(1));
                    }
                }
                connection.Close();

                Console.Read();
            }
        }
    }
}

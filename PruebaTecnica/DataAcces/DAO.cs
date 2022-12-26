
using MySql.Data.MySqlClient;


namespace PruebaTecnica.DataAcces
{
    public class DAO
    {



        public static MySqlConnection MySqlConnection()
        {

            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();



            
            try
            {
                MySqlConnection newConnection;

                var connectionString = configuration.GetValue<string>("ConnectionStrings:DifaultConnection");

                newConnection = new MySqlConnection(connectionString);

                return newConnection;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

           
        }

        


    }
}

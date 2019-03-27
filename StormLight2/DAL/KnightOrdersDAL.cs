using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormLight2.Models;
using System.Data.SqlClient;

namespace StormLight2.DAL
{
    public class KnightsOrdersDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormLight;Integrated Security=True";

        public List<KnightOrdersModel> GetAllKnightOrders()
        {
            List<KnightOrdersModel> output = new List<KnightOrdersModel>();

            string SQL_GetCommand = "SELECT * FROM Knight_Orders kn JOIN Knight_Orders_Characters koc ON kn.knight_orders_id = koc.knight_orders_id JOIN Character c ON koc.character_id = c.character_id";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(SQL_GetCommand, myConnection);

                    myConnection.Open();

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        KnightOrdersModel temp = new KnightOrdersModel()
                        {
                            Knight_Orders_Id = Convert.ToInt32(myReader["knight_orders_id"]),
                            Knight_Orders_Name = Convert.ToString(myReader["knight_orders_name"]),
                            Heralds = Convert.ToString(myReader["heralds"]),
                            Spren = Convert.ToString(myReader["spren"]),
                            Surges = Convert.ToString(myReader["surges"]),
                            Knight_Orders_Images = Convert.ToString(myReader["knight_orders_images"]),
                            Character_Id = Convert.ToInt32(myReader["character_id"]),
                            Character_Name = Convert.ToString(myReader["character_name"]),
                        };
                        output.Add(temp);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return output;
        }
        public KnightOrdersModel GetKnightOrder(int id)
        {
            return GetAllKnightOrders().FirstOrDefault(k => k.Knight_Orders_Id == id);
        }
    }
}

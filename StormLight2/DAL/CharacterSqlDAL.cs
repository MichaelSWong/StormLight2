using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormLight2.Models;
using System.Data.SqlClient;

namespace StormLight2.DAL
{
    public class CharacterSqlDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormLight;Integrated Security=True";

        public List<CharacterModel> GetAllCharacters()
        {
            List<CharacterModel> output = new List<CharacterModel>();

            string SQL_GetCommand = "SELECT * FROM Character";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(SQL_GetCommand, myConnection);

                    myConnection.Open();

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        CharacterModel temp = new CharacterModel()
                        {
                            Character_Id = Convert.ToInt32(myReader["character_id"]),
                            Character_Name = Convert.ToString(myReader["character_name"]),
                            Abilities = Convert.ToString(myReader["abilities"]),
                            Bonded_With = Convert.ToString(myReader["bonded_with"]),
                            Titles = Convert.ToString(myReader["titles"]),
                            Groups = Convert.ToString(myReader["groups"]),
                            Knight_Orders_Name = Convert.ToString(myReader["knights_orders_name"]),
                            Surges = Convert.ToString(myReader["surges"]),
                            Character_Image = Convert.ToString(myReader["character_image"])
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
        public CharacterModel GetCharacter(int id)
        {
            return GetAllCharacters().FirstOrDefault(c => c.Character_Id == id);
        }
    }
}

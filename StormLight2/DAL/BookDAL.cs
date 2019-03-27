using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormLight2.Models;
using System.Data.SqlClient;

namespace StormLight2.DAL
{
    public class BookDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormLight;Integrated Security=True";

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> output = new List<BookModel>();

            string SQL_GetCommand = "SELECT * FROM BOOK b JOIN Character_Book cb ON b.book_id = cb.book_id JOIN Character c ON c.character_id = cb.character_id;";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(SQL_GetCommand, myConnection);

                    myConnection.Open();

                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        BookModel temp = new BookModel()
                        {
                            Book_Id = Convert.ToInt32(myReader["book_id"]),
                            Book_Name = Convert.ToString(myReader["book_name"]),
                            Published = Convert.ToString(myReader["published"]),
                            Book_Cover = Convert.ToString(myReader["book_cover"]),
                            Book_Image = Convert.ToString(myReader["book_image"]),
                            Character_Id = Convert.ToInt32(myReader["character_id"]),
                            Character_Name = Convert.ToString(myReader["character_name"])

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
        public BookModel GetBook(int id)
        {
            return GetAllBooks().FirstOrDefault(b => b.Book_Id == id);
        }
    }
}
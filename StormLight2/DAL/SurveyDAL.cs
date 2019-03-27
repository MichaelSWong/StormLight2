using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StormLight2.Models;
using Dapper;

namespace StormLight2.DAL
{
    public class SurveyDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormLight;Integrated Security=True";
        const string SaveSurveyString = " INSERT INTO survey_result(character_id, emailAddress, state)values(@character_id, @emailAddress, @state)";

        const string numberOfSurveyString = "SELECT COUNT(*) AS numberOfSurveys, survey_result.character_id, character_name FROM survey_result join character.character_id=survey_result.character_id GROUP BY survey_result.character_id, character_name ORDER BY numberOfSurveys DESC;";

        public int SaveSurvey(SurveyResultModel newSurvey)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int affectedRows = connection.Execute(SaveSurveyString, newSurvey);
                return affectedRows;
            }
        }
    }
}

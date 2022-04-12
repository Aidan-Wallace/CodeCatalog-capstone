using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class ExampleDao : IExampleDAO
    {
        private readonly string connectionString;

        public ExampleDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public CodeExample GetExample(int codeId)
        {
            CodeExample returnExample = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                   //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code WHERE code_id = @code_id", conn);
                    cmd.Parameters.AddWithValue("@code_id", codeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnExample = GetExampleFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnExample;
        }

        public List<CodeExample> GetExamples()
        {
            List<CodeExample> returnExamples = new List<CodeExample>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                     //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code WHERE code_id = @code_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CodeExample returnExample = GetExampleFromReader(reader);
                        returnExamples.Add(returnExample);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnExamples;
        }
        public NewExample AddExample(NewExample newExample)
        {
            NewExample returnNewExample = null;
                //I feel like something needs to go here - misha
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                                                    //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("INSERT INTO code (code_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category) " +
                                                    " VALUES (@codeId, @title, @programmingLanguage, @exampleDate, @codeDescription, @snippet, @difficultyRank, @category)", conn);
                    cmd.Parameters.AddWithValue("@codeId", newExample.codeId);
                    cmd.Parameters.AddWithValue("@title", newExample.title);
                    cmd.Parameters.AddWithValue("@programmingLanguage", newExample.programmingLanguage);
                    cmd.Parameters.AddWithValue("@codeDescription", newExample.codeDescription);
                    cmd.Parameters.AddWithValue("@snippet", newExample.codeSnippet);
                    cmd.Parameters.AddWithValue("@exampleDate", newExample.exampleDate);
                    cmd.Parameters.AddWithValue("@difficultyRank", newExample.difficultyRank);
                    cmd.Parameters.AddWithValue("@category", newExample.category);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample; //not sure if we need to return anything - misha
        }

        private CodeExample GetExampleFromReader(SqlDataReader reader)
        {
            CodeExample e = new CodeExample()
            {
                codeId = Convert.ToInt32(reader["code_id"]),
                title = Convert.ToString(reader["title"]),
                programmingLanguage = Convert.ToString(reader["programming_language"]),
                codeSnippet = Convert.ToString(reader["snippet"]),
                codeDescription = Convert.ToString(reader["code_description"]),
                difficultyRank = Convert.ToInt32(reader["difficulty_rank"]),
                category = Convert.ToString(reader["category"]),
                exampleDate = Convert.ToString(reader["exampleDate"])
            };
            return e;
        }
    }
}
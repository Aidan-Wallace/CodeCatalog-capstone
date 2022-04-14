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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code", conn);
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
        public CodeExample FetchScript(int codeId)
        {
            CodeExample script = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                   //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("SELECT code_id, snippet FROM code WHERE code_id = @code_id", conn);
                    cmd.Parameters.AddWithValue("@code_id", codeId);
                    cmd.Parameters.AddWithValue("@snippet", script);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        script = GetExampleFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return script;
        }

        public List<CodeExample> FetchAllScripts()
        {
            List<CodeExample> scriptsList = new List<CodeExample>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                     //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("SELECT code_id, snippet FROM code", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CodeExample script = GetExampleFromReader(reader);
                        scriptsList.Add(script);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return scriptsList;
        }


        public PendingExample AddExample(PendingExample newExample)
        {
            PendingExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO code ( title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution) " +
                                                    " VALUES ( @title, @programmingLanguage, @exampleDate, @codeDescription, @snippet, @difficultyRank, @category, @attribution)", conn);

                    cmd.Parameters.AddWithValue("@title", newExample.title);
                    cmd.Parameters.AddWithValue("@programmingLanguage", newExample.programmingLanguage);
                    cmd.Parameters.AddWithValue("@exampleDate", newExample.exampleDate);
                    cmd.Parameters.AddWithValue("@codeDescription", newExample.codeDescription);
                    cmd.Parameters.AddWithValue("@snippet", newExample.codeSnippet);
                    cmd.Parameters.AddWithValue("@difficultyRank", newExample.difficultyRank);
                    cmd.Parameters.AddWithValue("@category", newExample.category);
                    cmd.Parameters.AddWithValue("@attribution", newExample.attribution);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample;
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
                difficultyRank = Convert.ToString(reader["difficulty_rank"]),
                category = Convert.ToString(reader["category"]),
                exampleDate = Convert.ToString(reader["example_date"]),
                attribution = Convert.ToString(reader["attribution"]),
            };
            return e;
        }
    }
}

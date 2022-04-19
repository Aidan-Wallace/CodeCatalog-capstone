using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Capstone.DAO
{
    public class ExampleDao : IExampleDAO
    {
        private List<CodeExample> pendingExamples = new List<CodeExample>();
        private List<CodeExample> genericExamples = new List<CodeExample>();
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
        public List<CodeExample> GetExamplesByUser(int userId)
        {
            List<CodeExample> returnExamples = new List<CodeExample>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                   //might have to do a join where user_id = @ user_id - misha
                    SqlCommand cmd = new SqlCommand("SELECT code.code_id, programming_language, title, snippet, code_description, example_date, " +
                        "difficulty_rank, category, code.submission_status, is_public, attribution, generic_example " +
                        "FROM code INNER JOIN user_code ON code.code_id = user_code.code_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
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

        public CodeExample AddExample(CodeExample newExample)
        {
            CodeExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO code ( title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example) " +
                                                    " VALUES ( @title, @programmingLanguage, @exampleDate, @codeDescription, @snippet, @difficultyRank, @category, @attribution, @submissionStatus, @isPublic, @genericExample)", conn);

                    cmd.Parameters.AddWithValue("@title", newExample.title);
                    cmd.Parameters.AddWithValue("@programmingLanguage", newExample.programmingLanguage);
                    cmd.Parameters.AddWithValue("@exampleDate", newExample.exampleDate);
                    cmd.Parameters.AddWithValue("@codeDescription", newExample.codeDescription);
                    cmd.Parameters.AddWithValue("@snippet", newExample.codeSnippet);
                    cmd.Parameters.AddWithValue("@difficultyRank", newExample.difficultyRank);
                    cmd.Parameters.AddWithValue("@category", newExample.category);
                    cmd.Parameters.AddWithValue("@attribution", newExample.attribution);
                    cmd.Parameters.AddWithValue("@submissionStatus", newExample.submissionStatus);
                    cmd.Parameters.AddWithValue("@isPublic", newExample.isPublic);
                    cmd.Parameters.AddWithValue("@genericExample", newExample.genericExample);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample;
        }

        public List<CodeExample> GetExamplesByStatus(int submissionStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                     
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code WHERE submission_status = @submissionStatus", conn);
                    cmd.Parameters.AddWithValue("@submissionStatus", submissionStatus);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CodeExample returnExample = GetExampleFromReader(reader);
                        pendingExamples.Add(returnExample);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return pendingExamples;
        }

        public CodeExample UpdateStatus(int codeId, CodeExample codeExample)
        {   
            CodeExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE code SET submission_status = @submissionStatus WHERE code_id = @codeId", conn);

                    cmd.Parameters.AddWithValue("@codeId", codeId);
                    cmd.Parameters.AddWithValue("@submissionStatus", codeExample.submissionStatus);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample;
        }

        public CodeExample UpdateVisibility(int codeId, CodeExample codeExample)
        {
            CodeExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE code SET is_public = @isPublic WHERE code_id = @codeId AND submission_status = 1", conn);

                    cmd.Parameters.AddWithValue("@codeId", codeId);
                    cmd.Parameters.AddWithValue("@isPublic", codeExample.isPublic);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample;
        }
        public CodeExample UpdateLanguage(int codeId, CodeExample codeExample)
        {
            CodeExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE code SET programming_language = @programmingLanguage WHERE code_id = @codeId", conn);

                    cmd.Parameters.AddWithValue("@codeId", codeId);
                    cmd.Parameters.AddWithValue("@programmingLanguage", codeExample.programmingLanguage);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnNewExample;
        }
        public CodeExample UpdateGenericSet(int codeId, CodeExample codeExample)
        {
            CodeExample returnNewExample = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE code SET generic_example = @genericExample WHERE code_id = @codeId", conn);

                    cmd.Parameters.AddWithValue("@codeId", codeId);
                    cmd.Parameters.AddWithValue("@genericExample", codeExample.genericExample);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException) 
            {
                throw;
            }
            return returnNewExample;
        }
        public List<CodeExample> GetGenericExampleList(int genericExample)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code WHERE generic_example = 1 AND is_public = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CodeExample returnExample = GetExampleFromReader(reader);
                        genericExamples.Add(returnExample);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return genericExamples;
        }

        private CodeExample GetExampleFromReader(SqlDataReader reader)
        {
            CodeExample e = new CodeExample()
            {
                codeId = Convert.ToInt32(reader["code_id"]),
                title = Convert.ToString(reader["title"]),
                submissionStatus = Convert.ToInt32(reader["submission_status"]),
                programmingLanguage = Convert.ToString(reader["programming_language"]),
                codeSnippet = Convert.ToString(reader["snippet"]),
                codeDescription = Convert.ToString(reader["code_description"]),
                difficultyRank = Convert.ToString(reader["difficulty_rank"]),
                category = Convert.ToString(reader["category"]),
                exampleDate = Convert.ToString(reader["example_date"]),
                attribution = Convert.ToString(reader["attribution"]),
                isPublic = Convert.ToInt32(reader["is_public"]),
                genericExample = Convert.ToInt32(reader["generic_example"])
            };
            return e;
        }
        
    }
}

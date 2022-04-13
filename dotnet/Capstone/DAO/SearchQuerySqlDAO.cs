using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class SearchQuerySqlDAO : ISearchQueryDAO
    {
        SearchQuery searchQuery = new SearchQuery();
        private readonly string connectionString;

        public SearchQuerySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<CodeExample> SearchByKeyword(string keyword)
        {
            List<CodeExample> returnExamples = new List<CodeExample>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();                     
                    SqlCommand cmd = new SqlCommand("SELECT * FROM code WHERE (title LIKE '%' + @keyword + '%') " +
                                                     "OR (category LIKE '%' + @keyword + '%') " +
                                                     "OR (code_description LIKE '%' + @keyword + '%') " +
                                                     "OR (programming_language LIKE '%' + @keyword + '%'); ", conn);

                    cmd.Parameters.AddWithValue("@keyword", keyword);

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
        // UNSHRINK TO SEE public List<CodeExample> SearchByTitle(string title) 
        // {
        //     List<CodeExample> returnExamples = new List<CodeExample>();
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();                     
        //             SqlCommand cmd = new SqlCommand("SELECT * FROM code", conn);
        //             SqlDataReader reader = cmd.ExecuteReader();

        //             while (reader.Read())
        //             {
        //                 CodeExample returnExample = GetExampleFromReader(reader);
        //                 returnExamples.Add(returnExample);
        //             }
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return returnExamples;
        // }

        // public List<CodeExample> SearchByProgrammingLanguage(string programmingLanguage)
        // {
        //     List<CodeExample> returnExamples = new List<CodeExample>();
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();                     
        //             SqlCommand cmd = new SqlCommand("SELECT * FROM code", conn);
        //             SqlDataReader reader = cmd.ExecuteReader();

        //             while (reader.Read())
        //             {
        //                 CodeExample returnExample = GetExampleFromReader(reader);
        //                 returnExamples.Add(returnExample);
        //             }
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return returnExamples;
        // }

        // public List<CodeExample> SearchByCategory(string category)
        // {
        //     List<CodeExample> returnExamples = new List<CodeExample>();
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();                     
        //             SqlCommand cmd = new SqlCommand("SELECT * FROM code", conn);
        //             SqlDataReader reader = cmd.ExecuteReader();

        //             while (reader.Read())
        //             {
        //                 CodeExample returnExample = GetExampleFromReader(reader);
        //                 returnExamples.Add(returnExample);
        //             }
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return returnExamples;
        // }

        // public List<CodeExample> SearchByDescription(string codeDescription)
        // {
        //     List<CodeExample> returnExamples = new List<CodeExample>();
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();                     
        //             SqlCommand cmd = new SqlCommand("SELECT * FROM code", conn);
        //             SqlDataReader reader = cmd.ExecuteReader();

        //             while (reader.Read())
        //             {
        //                 CodeExample returnExample = GetExampleFromReader(reader);
        //                 returnExamples.Add(returnExample);
        //             }
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return returnExamples;
        // }
        // public SearchQuery AddSearchKeyword(string keyword, int userId) 
        // {
        //     SearchQuery addedKeyword = null;
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();
        //             SqlCommand cmd = new SqlCommand("INSERT INTO search_index (keyword) " +
        //                                             " VALUES (@keyword) WHERE user_id = @userId", conn);
        //             cmd.Parameters.AddWithValue("@keyword", keyword);
        //             cmd.Parameters.AddWithValue("@userId", userId);
        //             cmd.ExecuteNonQuery();
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return addedKeyword; 
        // }

        // public SearchQuery GetExampleWithSearchKeyword(string keyword) 
        // {
        //     SearchQuery returnSearch = null;
        //     try
        //     {
        //         using (SqlConnection conn = new SqlConnection(connectionString))
        //         {
        //             conn.Open();
        //             SqlCommand cmd = new SqlCommand("SELECT * FROM code c JOIN search_index si ON c.code_id = si.code_id " +
        //                                             "WHERE (c.title LIKE '%' + @keyword + '%' );", conn);
        //             cmd.Parameters.AddWithValue("@keyword", keyword);
        //             SqlDataReader reader = cmd.ExecuteReader();

        //             if (reader.Read())
        //             {
        //                 returnSearch = GetSearchFromReader(reader);
        //             }
        //         }
        //     }
        //     catch (SqlException)
        //     {
        //         throw;
        //     }
        //     return returnSearch;
        // }

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
            };
            return e;
        }
    }
}

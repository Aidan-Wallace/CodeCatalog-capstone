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

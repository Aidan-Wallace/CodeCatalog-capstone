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

        private SearchQuery GetSearchFromReader(SqlDataReader reader)
        {
            SearchQuery search = new SearchQuery()
            {
                userId = Convert.ToInt32(reader["user_id"]),
                keyword = Convert.ToString(reader["keyword"]),
                codeId = Convert.ToString(reader["code_id"]),
            };

            return search;
        }
    }
}

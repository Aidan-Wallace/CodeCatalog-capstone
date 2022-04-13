﻿using Capstone.DAO.Interfaces;
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

        public SearchQuery SearchQuery(string keyword) //might have to make add to check unique title in SQL--also, how many search options should we provide?
        {
            SearchQuery returnSearch = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM code c JOIN search_index si ON c.code_id = si.code_id " +
                                                    "WHERE (c.title LIKE '%' + @keyword + '%' );", conn);
                    cmd.Parameters.AddWithValue("@keyword", keyword);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnSearch = GetSearchFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnSearch;
        }

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

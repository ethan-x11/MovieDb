using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IMDbRESTAPI.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Get(string query, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query, commandType: commandType);
        }

        public T Get(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters, commandType: commandType);
        }
        public IEnumerable<T> GetByCondition(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query, parameters, commandType: commandType);
        }

        public IEnumerable<T> GetByMovieId(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query, parameters, commandType: commandType);
        }

        public int Create(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<int>(query, parameters, commandType: commandType);
        }

        public bool Update(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return Convert.ToBoolean(connection.Execute(query, parameters, commandType: commandType));
        }

        public bool Delete(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            using var connection = new SqlConnection(_connectionString);
            return Convert.ToBoolean(connection.Execute(query, parameters, commandType: commandType));
        }
    }
}

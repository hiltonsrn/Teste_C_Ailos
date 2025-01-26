using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questao5.Infrastructure.Repositories
{
    public class BaseRepository<T>
    {
        protected IConfiguration configuration;
        protected string _baseSelect = $"SELECT * FROM {typeof(T).Name}";
        protected string _baseInsert = $"Insert into {typeof(T).Name} ";
        protected SqliteConnection connection;
        protected async Task<IEnumerable<T>> GetAllByCol(string colName, object colValue)
        {
            var sql = _baseSelect + $" WHERE {colName} = {colValue}";
            return await connection.QueryAsync<T>(sql);
        }
        protected async Task<T> GetOneByCol(string colName,object colValue)
        {
            var sql = _baseSelect + $" WHERE {colName} = {colValue}";
            return await connection.QuerySingleOrDefaultAsync<T>(sql);
        }
        protected async Task<IEnumerable<T>> GetAll()
        {
            return await connection.QueryAsync<T>(_baseSelect);
        }
        protected async Task<T> Add(T item, bool setGuid = true)
        {
            if (setGuid)
                BindGuid(item);
            var sql = _baseInsert +  $"({getCols()})";
            sql += $" VALUES({getValues(item)})";
            await connection.ExecuteAsync(sql, item);
            return item;
        }

        private void BindGuid(T? item)
        {
            var propKey = typeof(T).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(false).Count(a => a.GetType() == typeof(KeyAttribute)) > 0);
            if(propKey != null)
            {
                propKey.SetValue(item, Guid.NewGuid().ToString());
            }
        }

        private string getValues(T? item)
        {
            var typeAspas = new List<Type>() { typeof(string), typeof(char), typeof(DateTime) };
            var props = typeof(T).GetProperties();
            List<string> cols = new List<string>();
            foreach (var prop in props)
            {
                object val = prop.GetValue(item);
                if (val == null)
                {
                    cols.Add("null");
                    continue;
                }
                if (typeAspas.Contains(prop.PropertyType))
                {
                    val = $"'{val}'";
                }
                cols.Add(val.ToString());
            }
            return string.Join(',', cols.ToArray());
        }

        private string getCols()
        {
            var props = typeof(T).GetProperties();
            List<string> cols = new List<string>();
            foreach (var prop in props)
            {
                cols.Add(prop.Name);
            }
            return string.Join(',', cols.ToArray());
        }

        protected void Conectar()
        {
            connection = new SqliteConnection(configuration.GetSection("DatabaseName").Value);
        }
        protected void Desconectar()
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                connection.Dispose();
            }
        }
    }
}
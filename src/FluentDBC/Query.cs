using System.Data.SqlClient;

namespace FluentDBC
{
    public interface IQuery
    {
        public SqlRow One();

        public IEnumerable<SqlRow> Many();
    }

    public partial class Query : IQuery
    {
        private readonly string connectionString;
        private readonly string sql;
        private readonly IEnumerable<(string Name, object Value)> parameters;
        private readonly IEnumerable<string> outputColumns;

        internal Query(
            string connectionString, 
            string sql, 
            IEnumerable<(string, object)> parameters,
            IEnumerable<string> outputColumns)
        {
            this.connectionString = connectionString;
            this.sql = sql;
            this.parameters = parameters;
            this.outputColumns = outputColumns;
        }

        public SqlRow One()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var sqlParameters = parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
            command.Parameters.AddRange(sqlParameters);
            var reader = command.ExecuteReader();

            if (!reader.HasRows) throw new NotFoundException();

            var row = new SqlRow(
                outputColumns.ToDictionary(
                    column => column, 
                    column => reader[column]));
            connection.Close();
            return row;
        }

        public IEnumerable<SqlRow> Many()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var sqlParameters = parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
            command.Parameters.AddRange(sqlParameters);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new SqlRow(
                    outputColumns.ToDictionary(
                        column => column, 
                        column => reader[column]));
            }
            connection.Close();
        }
    }

    public class SqlRow
    {
        private readonly IDictionary<string, object> values;

        public SqlRow(IDictionary<string, object> values)
        {
            this.values = values;
        }

        public object this[string columnName] => values[columnName];
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() { }
    }
}
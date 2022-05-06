namespace FluentDBC
{
    public partial class Query
    {
        public static WithConnectionString Use(string connectionString)
        {
            return new WithConnectionString(connectionString);
        }
    }

    public class WithConnectionString
    {
        private readonly string connectionString;

        internal WithConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public WithSql Run(string sql)
        {
            return new WithSql(connectionString, sql);
        }
    }

    public class WithSql
    {
        private readonly string connectionString;
        private readonly string sql;

        internal WithSql(string connectionString, string sql)
        {
            this.connectionString = connectionString;
            this.sql = sql;
        }

        public WithParameters With(params (string Name, object Value)[] parameters)
        {
            return new WithParameters(connectionString, sql, parameters);
        }
    }

    public class WithParameters
    {
        private readonly string connectionString;
        private readonly string sql;
        private readonly IEnumerable<(string Name, object Value)> parameters;

        internal WithParameters(
            string connectionString,
            string sql,
            IEnumerable<(string Name, object Value)> parameters)
        {
            this.connectionString = connectionString;
            this.sql = sql;
            this.parameters = parameters;
        }

        public WithOutputColumns Select(params string[] outputColumns)
        {
            return new WithOutputColumns(connectionString, sql, parameters, outputColumns);
        }
    }

    public class WithOutputColumns
    {
        private readonly string connectionString;
        private readonly string sql;
        private readonly IEnumerable<(string Name, object Value)> parameters;
        private readonly IEnumerable<string> outputColumns;

        internal WithOutputColumns(
            string connectionString,
            string sql,
            IEnumerable<(string Name, object Value)> parameters,
            IEnumerable<string> outputColumns)
        {
            this.connectionString = connectionString;
            this.sql = sql;
            this.parameters = parameters;
            this.outputColumns = outputColumns;
        }

        public static implicit operator Query(WithOutputColumns self)
        {
            return new Query(
                self.connectionString,
                self.sql,
                self.parameters,
                self.outputColumns);
        }
    }
}

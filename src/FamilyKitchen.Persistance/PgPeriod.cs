using FamilyKitchen.Shared.Entities;
using System.Collections;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgPeriod : IPeriod
    {
        private readonly IDbConnection connection;

        private readonly DateTime start;
        private readonly DateTime end;

        public PgPeriod(IDbConnection connection, DateTime start, DateTime end)
        {
            this.connection = connection;
            this.start = start;
            this.end = end;
        }

        public IEnumerator<IDay> GetEnumerator() => new DayEnumerator(connection, start, end);
        IEnumerator IEnumerable.GetEnumerator() => new DayEnumerator(connection, start, end);
        public JsonArray Json() => new(this.Select(day => day.Json()).ToArray());
    }

    public class DayEnumerator : IEnumerator<IDay>
    {
        private readonly IDbConnection connection;

        private readonly DateTime start;
        private readonly DateTime end;

        private DateTime currentDate;

        public DayEnumerator(IDbConnection connection, DateTime start, DateTime end)
        {
            this.connection = connection;
            this.start = start;
            this.end = end;

            currentDate = start.AddDays(-1);
        }

        public IDay Current => new PgDay(connection, currentDate);

        object IEnumerator.Current => new PgDay(connection, currentDate);

        public void Dispose() => connection.Dispose();

        public bool MoveNext() => (currentDate = currentDate.AddDays(1)) <= end;

        public void Reset() => currentDate = start.AddDays(-1);
    }
}

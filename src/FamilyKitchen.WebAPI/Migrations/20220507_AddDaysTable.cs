using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    public class AddDaysTable : Migration
    {
        public override void Up() => 
            Create.Table("Days")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_DayId").Identity()
                .WithColumn("Date").AsDate();

        public override void Down() => Delete.Table("Days");
    }
}

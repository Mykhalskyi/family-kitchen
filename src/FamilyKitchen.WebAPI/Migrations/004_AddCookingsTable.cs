using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(004, nameof(AddCookingsTable))]
    public class AddCookingsTable : Migration
    {
        public override void Up() => 
            Create.Table("Cookings")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_CookingId").Identity()
                .WithColumn("DayId").AsInt32().ForeignKey("FK_Cooking_DayId", "Days", "Id")
                .WithColumn("DishId").AsInt32().ForeignKey("FK_Cooking_DishId", "Dishes", "Id")
                .WithColumn("Portions").AsInt32();

        public override void Down() => Delete.Table("Cookings");
    }
}

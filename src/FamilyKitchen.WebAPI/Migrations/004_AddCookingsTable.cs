using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(004, nameof(AddCookingsTable))]
    public class AddCookingsTable : Migration
    {
        public override void Up() => 
            Create.Table("Cookings")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_CookingId").Identity()
                .WithColumn("Date").AsDate()
                .WithColumn("DishId").AsInt32().ForeignKey("FK_Cooking_DishId", "Dishes", "Id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("Portions").AsInt32();

        public override void Down() => Delete.Table("Cookings");
    }
}

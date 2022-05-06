using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    public class AddDishesTable : Migration
    {
        public override void Up() =>
            Create.Table("Dishes")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_DishId").Identity()
                .WithColumn("Name").AsString();

        public override void Down() => Delete.Table("Dishes");
    }
}

using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(005, nameof(AddRecipesTable))]
    public class AddRecipesTable : Migration
    {
        public override void Up() => 
            Create.Table("Recipes")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_RecipeId").Identity()
                .WithColumn("DishId").AsInt32().ForeignKey("FK_Recipe_DishId", "Dishes", "Id")
                .WithColumn("Portions").AsInt32()
                .WithColumn("Notes").AsString();

        public override void Down() => Delete.Table("Recipes");
    }
}

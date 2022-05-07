using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(006, nameof(AddIngredientsTable))]
    public class AddIngredientsTable : Migration
    {
        public override void Up() => 
            Create.Table("Ingredients")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_IngredientId").Identity()
                .WithColumn("ProductId").AsInt32().ForeignKey("FK_Ingredient_ProductId", "Products", "Id")
                .WithColumn("RecipeId").AsInt32().ForeignKey("FK_Ingredient_RecipeId", "Recipes", "Id")
                .WithColumn("Amount").AsInt32();

        public override void Down() => Delete.Table("Ingredients");
    }
}

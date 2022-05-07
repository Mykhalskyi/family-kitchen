using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(003, nameof(AddProductsTable))]
    public class AddProductsTable : Migration
    {
        public override void Up() => 
            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_ProductId").Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Unit").AsInt32();

        public override void Down() => Delete.Table("Products");
    }
}

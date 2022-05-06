using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    public class AddProductsTable : Migration
    {
        public override void Up() => 
            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_ProductId").Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Unit").AsInt16();

        public override void Down() => Delete.Table("Products");
    }
}

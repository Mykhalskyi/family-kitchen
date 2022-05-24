using FluentMigrator;

namespace FamilyKitchen.WebAPI.Migrations
{
    [Migration(007, nameof(AddUsersTable))]
    public class AddUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_UserId").Identity()
                .WithColumn("Login").AsString()
                .WithColumn("PasswordHash").AsString();

            Alter.Table("Products")
                .AddColumn("UserId")
                    .AsInt32()
                    .ForeignKey("FK_Product_UserId", "Users", "Id")
                    .OnDelete(System.Data.Rule.Cascade);

            Alter.Table("Dishes")
                .AddColumn("UserId")
                    .AsInt32()
                    .ForeignKey("FK_Dish_UserId", "Users", "Id")
                    .OnDelete(System.Data.Rule.Cascade);

            Alter.Table("Cookings")
                .AddColumn("UserId")
                    .AsInt32()
                    .ForeignKey("FK_Cooking_IserId", "User", "Id")
                    .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}

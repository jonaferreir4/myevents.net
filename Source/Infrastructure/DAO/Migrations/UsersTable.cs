using FluentMigrator;
namespace DAO.Migrations;

[Migration(202505121103)]
public class UsersTable : Migration
{
    public override void Down()
    {
        Delete.Table("Users");
    }

    public override void Up()
    {
        Create.Table("Users")


            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("BirthDate").AsDate().NotNullable()
            .WithColumn("CPF").AsString(11).NotNullable().Unique()
            .WithColumn("Enrollment").AsInt32().NotNullable().Unique()
            .WithColumn("Password").AsString(255).NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
    }
}
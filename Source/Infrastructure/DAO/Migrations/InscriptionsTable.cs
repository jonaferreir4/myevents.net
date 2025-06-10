using System.Data;
using FluentMigrator;

namespace DAO.Migrations;

[Migration(202406072232)]
public class InscriptionsTable : Migration
{
    public override void Down()
    {
        Delete.Table("Inscriptions");
    }

    public override void Up()
    {
        Create.Table("Inscriptions")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt64().NotNullable()
            .WithColumn("EventId").AsInt64().NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        Create.ForeignKey("FK_Inscriptions_Users")
            .FromTable("Inscriptions").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);

        Create.ForeignKey("FK_Inscriptions_Events")
            .FromTable("Inscriptions").ForeignColumn("EventId")
            .ToTable("Events").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);
    }
}
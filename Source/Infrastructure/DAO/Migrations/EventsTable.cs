using System.Data;
using FluentMigrator;

namespace DAO.Migrations;

[Migration(202505292125)]
public class EventsTable : Migration
{
    public override void Down()
    {
        Delete.Table("Events");
    }

    public override void Up()
    {
        Create.Table("Events")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Theme").AsString(50).NotNullable()
            .WithColumn("Description").AsString(500).NotNullable()
            .WithColumn("StartDate").AsDate().NotNullable()
            .WithColumn("EndDate").AsDate().NotNullable()
            .WithColumn("StartTime").AsTime().NotNullable()
            .WithColumn("EndTime").AsTime().NotNullable()
            .WithColumn("Location").AsString(200).NotNullable()
            .WithColumn("Modality").AsString(50).NotNullable()
            .WithColumn("OrganizerId").AsInt32().NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        Create.ForeignKey("FK_Events_Users_Organizer")
        .FromTable("Events").ForeignColumn("OrganizerId")
        .ToTable("Users").PrimaryColumn("Id")
        .OnDelete(Rule.Cascade);
        
    }
}
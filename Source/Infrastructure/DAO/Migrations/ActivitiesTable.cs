using System.Data;
using FluentMigrator;

namespace DAO.Migrations;

[Migration(202506070009)]
public class ActivitiesTable : Migration
{
    public override void Down()
    {
        Delete.ForeignKey("FK_Activities_Events").OnTable("Activities");
        Delete.ForeignKey("FK_Activities_Users_Speaker").OnTable("Activities");
        Delete.Table("Activities");
    }

    public override void Up()
    {
        Create.Table("Activities")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Theme").AsString(50).NotNullable()
            .WithColumn("Type").AsString(50).NotNullable()
            .WithColumn("Description").AsString(500).NotNullable()
            .WithColumn("StartDate").AsDate().NotNullable()
            .WithColumn("EndDate").AsDate().NotNullable()
            .WithColumn("StartTime").AsTime().NotNullable()
            .WithColumn("EndTime").AsTime().NotNullable()
            .WithColumn("MaxParticipants").AsInt32().NotNullable()
            .WithColumn("CertificationHours").AsTime().NotNullable()
            .WithColumn("SpeakerId").AsInt32().Nullable()
            .WithColumn("EventId").AsInt32().NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        Create.ForeignKey("FK_Activities_Events")
            .FromTable("Activities").ForeignColumn("EventId")
            .ToTable("Events").PrimaryColumn("Id")
            .OnDeleteOrUpdate(Rule.Cascade);

        Create.ForeignKey("FK_Activities_Users_Speaker")
            .FromTable("Activities").ForeignColumn("SpeakerId")
            .ToTable("Users").PrimaryColumn("Id")
            .OnDelete(Rule.SetNull);
    }
}
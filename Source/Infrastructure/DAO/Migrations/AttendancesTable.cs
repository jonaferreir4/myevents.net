using System.Data;
using FluentMigrator;

namespace DAO.Migrations;

[Migration(202406082042)]
public class AttendancesTable : Migration
{
    public override void Down()
    {
        Delete.Table("Attendances");
    }

    public override void Up()
    {
        Create.Table("Attendances")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("IsPresent").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("UserId").AsInt64().NotNullable()
            .WithColumn("ActivityId").AsInt64().NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        Create.ForeignKey("FK_Attendances_Users")
            .FromTable("Attendances").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);

        Create.ForeignKey("FK_Attendances_Activities")
            .FromTable("Attendances").ForeignColumn("ActivityId")
            .ToTable("Activities").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);
    }
}
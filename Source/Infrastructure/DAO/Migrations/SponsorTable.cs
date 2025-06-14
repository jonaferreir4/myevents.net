using FluentMigrator;

namespace DAO.Migrations;

[Migration(202506132053)]
public class SponsorTable : Migration
{
    public override void Up()
    {
        Create.Table("Sponsors")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("LogoUrl").AsString(500).NotNullable()
            .WithColumn("Description").AsString(1000).Nullable()
            .WithColumn("WebsiteUrl").AsString(500).Nullable()
            .WithColumn("LinkedInUrl").AsString(500).Nullable()
            .WithColumn("InstagramUrl").AsString(500).Nullable()
            .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("Level").AsInt32().NotNullable()
            .WithColumn("EventId").AsInt64().NotNullable();

        Create.ForeignKey("FK_Sponsors_Event")
            .FromTable("Sponsors").ForeignColumn("EventId")
            .ToTable("Events").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Sponsors_Event").OnTable("Sponsors");
        Delete.Table("Sponsors");
    }
}

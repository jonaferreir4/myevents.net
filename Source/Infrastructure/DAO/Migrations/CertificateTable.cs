using FluentMigrator;

namespace DAO.Migrations;


[Migration(202511061610)]
public class CertificateTable : Migration
{
    public override void Down()
    {
        Delete.Table("Certificates");
    }

    public override void Up()
    {
        Create.Table("Certificates")
        .WithColumn("Id").AsInt32().PrimaryKey().Identity()
        .WithColumn("Name").AsString(255).NotNullable()
        .WithColumn("TotalHours").AsDecimal(5, 2).NotNullable()
        .WithColumn("IssueDate").AsDateTime().NotNullable()
        .WithColumn("VerificationCode").AsString(12).NotNullable().Unique()
        .WithColumn("ActivityId").AsInt32().NotNullable()
        .WithColumn("UserId").AsInt32().NotNullable()
        .WithColumn("CreatedAt").AsDateTime().NotNullable()
        .WithColumn("UpdatedAt").AsDateTime().Nullable();

        Create.ForeignKey("FK_Certificates_Activities")
      .FromTable("Certificates").ForeignColumn("ActivityId")
      .ToTable("Activities").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

        Create.ForeignKey("FK_Certificates_Users")
            .FromTable("Certificates").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

        Create.Index("IX_Certificates_User_Activity")
            .OnTable("Certificates")
            .OnColumn("UserId").Ascending()
            .OnColumn("ActivityId").Ascending()
            .WithOptions().Unique();
    }
}

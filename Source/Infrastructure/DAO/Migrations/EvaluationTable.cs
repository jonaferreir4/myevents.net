using FluentMigrator;

namespace DAO.Migrations;

[Migration(202506232020)]
public class EvaluationTable : Migration
{
    public override void Down()
    {
    
        Delete.ForeignKey("FK_Evaluations_Activities").OnTable("Evaluations");
        Delete.ForeignKey("FK_Evaluations_Users").OnTable("Evaluations");
    
        Delete.Index("IX_Evaluations_ActivityId").OnTable("Evaluations");
        Delete.Index("IX_Evaluations_UserId").OnTable("Evaluations");
        
        Delete.Table("Evaluations");
    }

    public override void Up()
    {
        Create.Table("Evaluations")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Rating").AsInt32().NotNullable()
            .WithColumn("Comment").AsString(int.MaxValue).Nullable()
            .WithColumn("ActivityId").AsInt64().NotNullable()
            .WithColumn("UserId").AsInt64().NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedOn").AsDateTime().Nullable();
        
        Create.ForeignKey("FK_Evaluations_Activities")
            .FromTable("Evaluations").ForeignColumn("ActivityId")
            .ToTable("Activities").PrimaryColumn("Id")
            .OnDelete(System.Data.Rule.Cascade);
            
        Create.ForeignKey("FK_Evaluations_Users")
            .FromTable("Evaluations").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id")
            .OnDelete(System.Data.Rule.Cascade);
            
        Create.Index("IX_Evaluations_ActivityId")
            .OnTable("Evaluations")
            .OnColumn("ActivityId");
            
        Create.Index("IX_Evaluations_UserId")
            .OnTable("Evaluations")
            .OnColumn("UserId");
    }
}
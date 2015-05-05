namespace FutGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamAndPlayers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        RealTeam = c.String(),
                        DisplayLevel = c.Int(nullable: false),
                        CalculatedLevel = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.TeamPlayers",
                c => new
                    {
                        TeamId = c.Long(nullable: false),
                        PlayerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.PlayerId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPlayers", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.TeamPlayers", "TeamId", "dbo.Teams");
            DropIndex("dbo.TeamPlayers", new[] { "PlayerId" });
            DropIndex("dbo.TeamPlayers", new[] { "TeamId" });
            DropTable("dbo.TeamPlayers");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}

namespace EGMovies.BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        Role = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        Genre = c.String(maxLength: 50),
                        ShowingDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ShowFrom = c.String(maxLength: 10),
                        ShowTo = c.String(maxLength: 10),
                        MovieId = c.Int(),
                        CinemaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .Index(t => t.MovieId)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        CinemaGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CinemaGroup", t => t.CinemaGroupId)
                .Index(t => t.CinemaGroupId);
            
            CreateTable(
                "dbo.CinemaGroup",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 80),
                        City = c.String(maxLength: 50),
                        Area = c.String(maxLength: 100),
                        Address = c.String(),
                        Telephone = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesActors",
                c => new
                    {
                        ActorId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActorId, t.MovieId })
                .ForeignKey("dbo.Actor", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviesActors", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MoviesActors", "ActorId", "dbo.Actor");
            DropForeignKey("dbo.Show", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Show", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.Cinema", "CinemaGroupId", "dbo.CinemaGroup");
            DropIndex("dbo.MoviesActors", new[] { "MovieId" });
            DropIndex("dbo.MoviesActors", new[] { "ActorId" });
            DropIndex("dbo.Cinema", new[] { "CinemaGroupId" });
            DropIndex("dbo.Show", new[] { "CinemaId" });
            DropIndex("dbo.Show", new[] { "MovieId" });
            DropTable("dbo.MoviesActors");
            DropTable("dbo.CinemaGroup");
            DropTable("dbo.Cinema");
            DropTable("dbo.Show");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}

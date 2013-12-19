namespace WordsISay_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Plot = c.String(),
                        ImageURL = c.String(),
                        VoteScore = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stories");
        }
    }
}

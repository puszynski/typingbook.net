namespace TypingMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vol1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(nullable: false),
                        BookContent = c.String(nullable: false),
                        Rate = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_ID, t.Author_ID })
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Author_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Author_ID", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_ID", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookAuthors", new[] { "Book_ID" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}

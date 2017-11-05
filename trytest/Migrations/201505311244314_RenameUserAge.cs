namespace trytest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUserAge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserNickname = c.String(),
                        UserPassword = c.String(),
                        UserEmail = c.String(),
                        UserAge = c.Int(nullable: false),
                        UserSex = c.String(),
                        UserRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleID, cascadeDelete: true)
                .Index(t => t.UserRoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendID = c.Int(nullable: false, identity: true),
                        FriendName = c.String(),
                        FriendNickname = c.String(),
                        FriendPassword = c.String(),
                        FriendEmail = c.String(),
                        FriendAge = c.Int(nullable: false),
                        FriendSex = c.String(),
                    })
                .PrimaryKey(t => t.FriendID);
            
            CreateTable(
                "dbo.EventInProjects",
                c => new
                    {
                        EventInProjectID = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                        FriendID = c.Int(nullable: false),
                        EventInProjectTypeID = c.Int(nullable: false),
                        EventInProjectStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventInProjectID)
                .ForeignKey("dbo.Friends", t => t.FriendID, cascadeDelete: true)
                .ForeignKey("dbo.EventInProjectTypes", t => t.EventInProjectTypeID, cascadeDelete: true)
                .ForeignKey("dbo.EventInProjectStatus", t => t.EventInProjectStatusID, cascadeDelete: true)
                .Index(t => t.FriendID)
                .Index(t => t.EventInProjectTypeID)
                .Index(t => t.EventInProjectStatusID);
            
            CreateTable(
                "dbo.EventInProjectTypes",
                c => new
                    {
                        EventInProjectTypeID = c.Int(nullable: false, identity: true),
                        EventInProjectTypeName = c.String(),
                    })
                .PrimaryKey(t => t.EventInProjectTypeID);
            
            CreateTable(
                "dbo.EventInProjectStatus",
                c => new
                    {
                        EventInProjectStatusID = c.Int(nullable: false, identity: true),
                        EventInProjectStatusName = c.String(),
                    })
                .PrimaryKey(t => t.EventInProjectStatusID);
            
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        ContributionID = c.Int(nullable: false, identity: true),
                        ContributionName = c.String(),
                        ContributionQuantity = c.String(),
                        ContributionTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContributionID)
                .ForeignKey("dbo.ContributionTypes", t => t.ContributionTypeID, cascadeDelete: true)
                .Index(t => t.ContributionTypeID);
            
            CreateTable(
                "dbo.ContributionTypes",
                c => new
                    {
                        ContributionTypeID = c.Int(nullable: false, identity: true),
                        ContributionTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ContributionTypeID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contributions", new[] { "ContributionTypeID" });
            DropIndex("dbo.EventInProjects", new[] { "EventInProjectStatusID" });
            DropIndex("dbo.EventInProjects", new[] { "EventInProjectTypeID" });
            DropIndex("dbo.EventInProjects", new[] { "FriendID" });
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropForeignKey("dbo.Contributions", "ContributionTypeID", "dbo.ContributionTypes");
            DropForeignKey("dbo.EventInProjects", "EventInProjectStatusID", "dbo.EventInProjectStatus");
            DropForeignKey("dbo.EventInProjects", "EventInProjectTypeID", "dbo.EventInProjectTypes");
            DropForeignKey("dbo.EventInProjects", "FriendID", "dbo.Friends");
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles");
            DropTable("dbo.ContributionTypes");
            DropTable("dbo.Contributions");
            DropTable("dbo.EventInProjectStatus");
            DropTable("dbo.EventInProjectTypes");
            DropTable("dbo.EventInProjects");
            DropTable("dbo.Friends");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
        }
    }
}

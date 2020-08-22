namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1dbff55a-f6fd-4596-bfc2-fc830e2f4ad3', N'admin@vidly.com', 0, N'AEMdH+qEIztZ54rA10QFFLC1XbD51gNtKqID+xBslLidCvaGE8JuulbB/A0Ev1i2ng==', N'aff84381-2d98-4330-8f4c-fd4ba152d440', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a78432f8-4500-4dd6-881f-aeebd3ffa83c', N'guest@vidly.com', 0, N'AMgJEpThTqP5UWEOFvcxMMzNAvvVzjR62COogCp3xMiI7SNJ5MnrTVRomuaVFZU12w==', N'86a9fdc6-835c-461e-b7ef-0ae426d8082b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'17eea247-f8d8-43b3-850f-4f9d308dbe0b', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1dbff55a-f6fd-4596-bfc2-fc830e2f4ad3', N'17eea247-f8d8-43b3-850f-4f9d308dbe0b')
            ");
        }
        
        public override void Down()
        {
        }
    }
}

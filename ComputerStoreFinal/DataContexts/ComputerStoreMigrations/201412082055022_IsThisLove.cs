namespace ComputerStoreFinal.DataContexts.ComputerStoreMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsThisLove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "MoboID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "CpuID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "MemoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "GpuID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "HardDriveID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "CaseID", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "PsuID", c => c.Int(nullable: false));
            DropColumn("dbo.Computers", "PartID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "PartID", c => c.Int(nullable: false));
            DropColumn("dbo.Computers", "PsuID");
            DropColumn("dbo.Computers", "CaseID");
            DropColumn("dbo.Computers", "HardDriveID");
            DropColumn("dbo.Computers", "GpuID");
            DropColumn("dbo.Computers", "MemoryID");
            DropColumn("dbo.Computers", "CpuID");
            DropColumn("dbo.Computers", "MoboID");
        }
    }
}

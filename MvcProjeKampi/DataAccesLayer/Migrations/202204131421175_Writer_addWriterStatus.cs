﻿namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Writer_addWriterStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}

namespace RestaurantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "TenKH", c => c.String(maxLength: 200));
            AlterColumn("dbo.Customers", "SDT", c => c.String(maxLength: 15));
            AlterColumn("dbo.Employees", "TenNV", c => c.String(maxLength: 200));
            AlterColumn("dbo.Employees", "ChucVu", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "SDT", c => c.String(maxLength: 15));
            AlterColumn("dbo.Menus", "TenMA", c => c.String(maxLength: 200));
            AlterColumn("dbo.Menus", "LoaiMA", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "LoaiMA", c => c.String(maxLength: 20));
            AlterColumn("dbo.Menus", "TenMA", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employees", "SDT", c => c.String(maxLength: 11));
            AlterColumn("dbo.Employees", "ChucVu", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employees", "TenNV", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "SDT", c => c.String(maxLength: 11));
            AlterColumn("dbo.Customers", "TenKH", c => c.String(maxLength: 100));
        }
    }
}

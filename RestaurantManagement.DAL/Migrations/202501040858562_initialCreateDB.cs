namespace RestaurantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 5),
                        TenKH = c.String(maxLength: 200),
                        SDT = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        MaDB = c.String(nullable: false, maxLength: 5),
                        NgayDat = c.DateTime(nullable: false),
                        NgayDen = c.DateTime(nullable: false),
                        SoNguoi = c.Int(nullable: false),
                        GhiChu = c.String(maxLength: 100),
                        MaKH = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MaDB)
                .ForeignKey("dbo.Customers", t => t.MaKH)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 5),
                        TenNV = c.String(maxLength: 200),
                        ChucVu = c.String(maxLength: 50),
                        Luong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDT = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 5),
                        SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NgayTT = c.DateTime(nullable: false),
                        MaDH = c.String(maxLength: 5),
                        MaNV = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.Employees", t => t.MaNV)
                .ForeignKey("dbo.Orders", t => t.MaDH)
                .Index(t => t.MaDH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        MaDH = c.String(nullable: false, maxLength: 5),
                        NgayDH = c.DateTime(nullable: false),
                        MaDB = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MaDH)
                .ForeignKey("dbo.Reservations", t => t.MaDB)
                .Index(t => t.MaDB);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        MaDH = c.String(nullable: false, maxLength: 5),
                        MaMA = c.String(nullable: false, maxLength: 5),
                        SL = c.Int(nullable: false),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaDH, t.MaMA })
                .ForeignKey("dbo.Menus", t => t.MaMA, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.MaDH, cascadeDelete: true)
                .Index(t => t.MaDH)
                .Index(t => t.MaMA);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MaMA = c.String(nullable: false, maxLength: 5),
                        TenMA = c.String(maxLength: 200),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoaiMA = c.String(maxLength: 50),
                        HinhAnh = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaMA);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        MaBan = c.String(nullable: false, maxLength: 5),
                        TrangThai = c.String(maxLength: 50),
                        SoChoNgoi = c.Int(nullable: false),
                        MaDH = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MaBan)
                .ForeignKey("dbo.Orders", t => t.MaDH)
                .Index(t => t.MaDH);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        NgayTD = c.DateTime(nullable: false),
                        TongDoanhThu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SLDH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NgayTD);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "MaDH", "dbo.Orders");
            DropForeignKey("dbo.Tables", "MaDH", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MaDB", "dbo.Reservations");
            DropForeignKey("dbo.OrderItems", "MaDH", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "MaMA", "dbo.Menus");
            DropForeignKey("dbo.Payments", "MaNV", "dbo.Employees");
            DropForeignKey("dbo.Reservations", "MaKH", "dbo.Customers");
            DropIndex("dbo.Tables", new[] { "MaDH" });
            DropIndex("dbo.OrderItems", new[] { "MaMA" });
            DropIndex("dbo.OrderItems", new[] { "MaDH" });
            DropIndex("dbo.Orders", new[] { "MaDB" });
            DropIndex("dbo.Payments", new[] { "MaNV" });
            DropIndex("dbo.Payments", new[] { "MaDH" });
            DropIndex("dbo.Reservations", new[] { "MaKH" });
            DropTable("dbo.Revenues");
            DropTable("dbo.Tables");
            DropTable("dbo.Menus");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Payments");
            DropTable("dbo.Employees");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
        }
    }
}

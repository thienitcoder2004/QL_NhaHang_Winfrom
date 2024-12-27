namespace RestaurantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RestaurantManagement.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantManagement.DAL.Entities.RestaurantManagementDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantManagement.DAL.Entities.RestaurantManagementDBContext context)
        {
            // Insert data into Customers table
            context.Customers.AddOrUpdate(c => c.MaKH,
                new Customer { MaKH = "KH1", TenKH = "Nguyễn Văn A", SDT = "84123456789" },
                new Customer { MaKH = "KH2", TenKH = "Nguyễn Văn B", SDT = "84123459876" },
                new Customer { MaKH = "KH3", TenKH = "Nguyên Thị C", SDT = "845432167899" },
                new Customer { MaKH = "KH4", TenKH = "Nguyễn Văn D", SDT = "841237654899" },
                new Customer { MaKH = "KH5", TenKH = "Nguyễn Quan E", SDT = "849876543211" }
            );

            // Insert data into Reservations table
            context.Reservations.AddOrUpdate(r => r.MaDB,
                new Reservation { MaDB = "DB1", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 12, GhiChu = null, MaKH = "KH1" },
                new Reservation { MaDB = "DB2", NgayDat = new DateTime(2024, 12, 20), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 10, GhiChu = "Có trẻ em", MaKH = "KH2" },
                new Reservation { MaDB = "DB3", NgayDat = new DateTime(2024, 12, 25), NgayDen = new DateTime(2024, 12, 27), SoNguoi = 8, GhiChu = null, MaKH = "KH3" },
                new Reservation { MaDB = "DB4", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 11, GhiChu = null, MaKH = "KH4" },
                new Reservation { MaDB = "DB5", NgayDat = new DateTime(2024, 12, 24), NgayDen = new DateTime(2024, 12, 29), SoNguoi = 5, GhiChu = "Tổ chức sinh nhật", MaKH = "KH5" }
            );

            // Insert data into Employees table
            context.Employees.AddOrUpdate(e => e.MaNV,
                new Employee { MaNV = "NV1", TenNV = "Trần Thái Thông", ChucVu = "Lễ Tân", Luong = 4600000, SDT = "84165397826" },
                new Employee { MaNV = "NV2", TenNV = "Nguyễn Tuấn Anh", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "84697512843" },
                new Employee { MaNV = "NV3", TenNV = "Đỗ Nguyễn Bảo Duy", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "84679821435" },
                new Employee { MaNV = "NV4", TenNV = "Nguyễn Dương Khánh Duy", ChucVu = "Đầu Bếp", Luong = 8600000, SDT = "84163294578" },
                new Employee { MaNV = "NV5", TenNV = "Lâm Nguyễn Thìn", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "84267591384" },
                new Employee { MaNV = "NV6", TenNV = "Nguyễn Ngoc Thiện", ChucVu = "Quản Lý", Luong = 10000000, SDT = "840163297566" }
            );

            // Insert data into Menus table
            context.Menus.AddOrUpdate(m => m.MaMA,
                new Menu { MaMA = "MA1", TenMA = "CupcakeRecipes", Gia = 119000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA2", TenMA = "PenfoldsMax'sShirazCabernet", Gia = 499000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA3", TenMA = "Chivas", Gia = 425000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA4", TenMA = "PinkGrapefruitLemonade", Gia = 89000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA5", TenMA = "Gin", Gia = 685000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA6", TenMA = "BananaJuice", Gia = 80000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA7", TenMA = "RakkorKrumpli", Gia = 199000, LoaiMA = "Nước", HinhAnh = null },
                new Menu { MaMA = "MA8", TenMA = "Borscht", Gia = 199000, LoaiMA = "Bánh", HinhAnh = null },
                new Menu { MaMA = "MA9", TenMA = "DarkSweets", Gia = 149000, LoaiMA = "Bánh", HinhAnh = null },
                new Menu { MaMA = "MA10", TenMA = "PepperoniClassicPizza", Gia = 299000, LoaiMA = "Bánh", HinhAnh = null },
                new Menu { MaMA = "MA11", TenMA = "Rutiwitthbeefslice", Gia = 149000, LoaiMA = "Bánh", HinhAnh = null },
                new Menu { MaMA = "MA12", TenMA = "WhopperBurgerKing", Gia = 99000, LoaiMA = "Bánh", HinhAnh = null },
                new Menu { MaMA = "MA13", TenMA = "Rutluta", Gia = 299000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA14", TenMA = "Burger", Gia = 485000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA15", TenMA = "ChickenLegPiece", Gia = 349000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA16", TenMA = "EggandCucumber", Gia = 250000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA17", TenMA = "EosLuibusdaml", Gia = 150000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA18", TenMA = "EosLuibusdamBeef", Gia = 799000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA19", TenMA = "ItalianSeafoodMushroom", Gia = 380000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA20", TenMA = "LaboriosamDireval", Gia = 180000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA21", TenMA = "OnionRings", Gia = 450000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA22", TenMA = "Shrimpandolive", Gia = 386000, LoaiMA = "Chính", HinhAnh = null },
                new Menu { MaMA = "MA23", TenMA = "SummerCooking", Gia = 749000, LoaiMA = "Chính", HinhAnh = null }
            );

            context.SaveChanges();
        }
    }
}

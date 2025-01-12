namespace RestaurantManagement.DAL.Migrations
{
    using RestaurantManagement.DAL.Entities;
    using System;
    using System.Data.Entity.Migrations;

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
                new Customer { MaKH = "KH5", TenKH = "Nguyễn Quan E", SDT = "849876543211" },
                new Customer { MaKH = "KH001", TenKH = "Nguyễn Ngọc A", SDT = "849876003211" },
                new Customer { MaKH = "KH002", TenKH = "Nguyễn Ngọc B", SDT = "849006543211" },
                new Customer { MaKH = "KH003", TenKH = "Nguyễn Ngọc C", SDT = "849876543211" },
                new Customer { MaKH = "KH004", TenKH = "Nguyễn Ngọc D", SDT = "849876543001" },
                new Customer { MaKH = "KH005", TenKH = "Nguyễn Quan E", SDT = "800876543211" }

            );

            // Insert data into Reservations table
            context.Reservations.AddOrUpdate(r => r.MaDB,
                new Reservation { MaDB = "DB1", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 12, GhiChu = null, MaKH = "KH1" },
                new Reservation { MaDB = "DB2", NgayDat = new DateTime(2024, 12, 20), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 10, GhiChu = "Có trẻ em", MaKH = "KH2" },
                new Reservation { MaDB = "DB3", NgayDat = new DateTime(2024, 12, 25), NgayDen = new DateTime(2024, 12, 27), SoNguoi = 8, GhiChu = null, MaKH = "KH3" },
                new Reservation { MaDB = "DB4", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 11, GhiChu = null, MaKH = "KH4" },
                new Reservation { MaDB = "DB5", NgayDat = new DateTime(2024, 12, 24), NgayDen = new DateTime(2024, 12, 29), SoNguoi = 5, GhiChu = "Tổ chức sinh nhật", MaKH = "KH5" },
                new Reservation { MaDB = "DB001", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 0, GhiChu = null, MaKH = "KH001" },
                new Reservation { MaDB = "DB002", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 0, GhiChu = null, MaKH = "KH002" },
                new Reservation { MaDB = "DB003", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 28), SoNguoi = 0, GhiChu = null, MaKH = "KH003" },
                new Reservation { MaDB = "DB004", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 30), SoNguoi = 0, GhiChu = null, MaKH = "KH004" },
                new Reservation { MaDB = "DB005", NgayDat = new DateTime(2024, 12, 27), NgayDen = new DateTime(2024, 12, 29), SoNguoi = 0, GhiChu = null, MaKH = "KH005" }
            );

            // Insert data into Employees table
            context.Employees.AddOrUpdate(e => e.MaNV,
                new Employee { MaNV = "NV1", TenNV = "Trần Thái Thông", ChucVu = "Lễ Tân", Luong = 4600000, SDT = "8416539782" },
                new Employee { MaNV = "NV2", TenNV = "Nguyễn Tuấn Anh", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "8469751283" },
                new Employee { MaNV = "NV3", TenNV = "Đỗ Nguyễn Bảo Duy", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "8467982143" },
                new Employee { MaNV = "NV4", TenNV = "Nguyễn Dương Khánh Duy", ChucVu = "Đầu Bếp", Luong = 8600000, SDT = "8416329457" },
                new Employee { MaNV = "NV5", TenNV = "Lâm Nguyễn Thìn", ChucVu = "Phục Vụ", Luong = 6800000, SDT = "8426759138" },
                new Employee { MaNV = "NV6", TenNV = "Nguyễn Ngoc Thiện", ChucVu = "Quản Lý", Luong = 10000000, SDT = "0123456789" }
            );

            // Insert data into Menus table
            context.Menus.AddOrUpdate(m => m.MaMA,
                new Menu { MaMA = "MA1", TenMA = "CupcakeRecipes", Gia = 119000, LoaiMA = "Món Nước", HinhAnh = "MA1.png" },
                new Menu { MaMA = "MA2", TenMA = "PenfoldsMax'sShirazCabernet", Gia = 499000, LoaiMA = "Món Nước", HinhAnh = "MA2.png" },
                new Menu { MaMA = "MA3", TenMA = "Chivas", Gia = 425000, LoaiMA = "Món Nước", HinhAnh = "MA3.png" },
                new Menu { MaMA = "MA4", TenMA = "PinkGrapefruitLemonade", Gia = 89000, LoaiMA = "Món Nước", HinhAnh = "MA4.png" },
                new Menu { MaMA = "MA5", TenMA = "Gin", Gia = 685000, LoaiMA = "Món Nước", HinhAnh = "MA5.png" },
                new Menu { MaMA = "MA6", TenMA = "BananaJuice", Gia = 80000, LoaiMA = "Món Nước", HinhAnh = "MA6.png" },
                new Menu { MaMA = "MA7", TenMA = "RakkorKrumpli", Gia = 199000, LoaiMA = "Món Nước", HinhAnh = "MA7.png" },
                new Menu { MaMA = "MA8", TenMA = "Borscht", Gia = 199000, LoaiMA = "Món Bánh", HinhAnh = "MA8.png" },
                new Menu { MaMA = "MA9", TenMA = "DarkSweets", Gia = 149000, LoaiMA = "Món Bánh", HinhAnh = "MA9.png" },
                new Menu { MaMA = "MA10", TenMA = "PepperoniClassicPizza", Gia = 299000, LoaiMA = "Món Bánh", HinhAnh = "MA10.png" },
                new Menu { MaMA = "MA11", TenMA = "Rutiwithchiken", Gia = 250000, LoaiMA = "Món Bánh", HinhAnh = "MA11.png" },
                new Menu { MaMA = "MA12", TenMA = "Rutiwitthbeefslice", Gia = 149000, LoaiMA = "Món Bánh", HinhAnh = "MA12.png" },
                new Menu { MaMA = "MA13", TenMA = "WhopperBurgerKing", Gia = 99000, LoaiMA = "Món Bánh", HinhAnh = "MA13.png" },
                new Menu { MaMA = "MA14", TenMA = "AutLuia", Gia = 299000, LoaiMA = "Món Chính", HinhAnh = "MA14.png" },
                new Menu { MaMA = "MA15", TenMA = "Burger", Gia = 485000, LoaiMA = "Món Chính", HinhAnh = "MA15.png" },
                new Menu { MaMA = "MA16", TenMA = "ChickenLegPiece", Gia = 349000, LoaiMA = "Món Chính", HinhAnh = "MA16.png" },
                new Menu { MaMA = "MA17", TenMA = "EggandCucumber", Gia = 250000, LoaiMA = "Món Chính", HinhAnh = "MA17.png" },
                new Menu { MaMA = "MA18", TenMA = "EosLuibusdam", Gia = 150000, LoaiMA = "Món Chính", HinhAnh = "MA18.png" },
                new Menu { MaMA = "MA19", TenMA = "EosLuibusdamBeef", Gia = 799000, LoaiMA = "Món Chính", HinhAnh = "MA19.png" },
                new Menu { MaMA = "MA20", TenMA = "ItalianSeafoodMushroom", Gia = 380000, LoaiMA = "Món Chính", HinhAnh = "MA20.png" },
                new Menu { MaMA = "MA21", TenMA = "LaboriosamDireva", Gia = 180000, LoaiMA = "Món Chính", HinhAnh = "MA21.png" },
                new Menu { MaMA = "MA22", TenMA = "OnionRings", Gia = 450000, LoaiMA = "Món Chính", HinhAnh = "MA22.png" },
                new Menu { MaMA = "MA23", TenMA = "Shrimpandolive", Gia = 386000, LoaiMA = "Món Chính", HinhAnh = "MA23.png" },
                new Menu { MaMA = "MA24", TenMA = "SummerCooking", Gia = 749000, LoaiMA = "Món Chính", HinhAnh = "MA24.png" }
            );

            // Insert data into Tables table
            context.Tables.AddOrUpdate(
                    t => t.MaBan, // Định danh duy nhất
                    new Table { MaBan = "B1", TrangThai = "Trống", SoChoNgoi = 2, MaDH = null },
                    new Table { MaBan = "B2", TrangThai = "Trống", SoChoNgoi = 2, MaDH = null },
                    new Table { MaBan = "B3", TrangThai = "Trống", SoChoNgoi = 2, MaDH = null },
                    new Table { MaBan = "B4", TrangThai = "Trống", SoChoNgoi = 4, MaDH = null },
                    new Table { MaBan = "B5", TrangThai = "Trống", SoChoNgoi = 4, MaDH = null },
                    new Table { MaBan = "B6", TrangThai = "Trống", SoChoNgoi = 4, MaDH = null },
                    new Table { MaBan = "B7", TrangThai = "Trống", SoChoNgoi = 4, MaDH = null },
                    new Table { MaBan = "B8", TrangThai = "Trống", SoChoNgoi = 6, MaDH = null },
                    new Table { MaBan = "B9", TrangThai = "Trống", SoChoNgoi = 6, MaDH = null },
                    new Table { MaBan = "B10", TrangThai = "Trống", SoChoNgoi = 6, MaDH = null },
                    new Table { MaBan = "B11", TrangThai = "Trống", SoChoNgoi = 6, MaDH = null },
                    new Table { MaBan = "B12", TrangThai = "Trống", SoChoNgoi = 6, MaDH = null },
                    new Table { MaBan = "B13", TrangThai = "Trống", SoChoNgoi = 10, MaDH = null },
                    new Table { MaBan = "B14", TrangThai = "Trống", SoChoNgoi = 10, MaDH = null },
                    new Table { MaBan = "B15", TrangThai = "Trống", SoChoNgoi = 10, MaDH = null }
                );

            context.Orders.AddOrUpdate(
                o => o.MaDH,
                new Order { MaDH = "DH1", NgayDH = new DateTime(2024, 12, 30), MaDB = "DB1" },
                new Order { MaDH = "DH2", NgayDH = new DateTime(2024, 12, 30), MaDB = "DB2" },
                new Order { MaDH = "DH001", NgayDH = new DateTime(2024, 12, 30), MaDB = "DB001" },
                new Order { MaDH = "DH002", NgayDH = new DateTime(2024, 12, 30), MaDB = "DB002" },
                new Order { MaDH = "DH003", NgayDH = new DateTime(2024, 12, 28), MaDB = "DB003" },
                new Order { MaDH = "DH004", NgayDH = new DateTime(2024, 12, 30), MaDB = "DB004" },
                new Order { MaDH = "DH005", NgayDH = new DateTime(2024, 12, 29), MaDB = "DB005" }
                );

            context.OrderItems.AddOrUpdate(
                o => new {o.MaDH, o.MaMA},
                new OrderItem { MaDH = "DH001", MaMA = "MA1", SL = 0, ThanhTien = 0},
                new OrderItem { MaDH = "DH001", MaMA = "MA6", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH001", MaMA = "MA22", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH001", MaMA = "MA17", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH001", MaMA = "MA16", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH002", MaMA = "MA8", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH002", MaMA = "MA7", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH002", MaMA = "MA24", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH002", MaMA = "MA11", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH003", MaMA = "MA6", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH003", MaMA = "MA3", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH003", MaMA = "MA18", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH003", MaMA = "MA20", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH004", MaMA = "MA2", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH004", MaMA = "MA5", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH004", MaMA = "MA15", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH004", MaMA = "MA14", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH005", MaMA = "MA14", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH005", MaMA = "MA21", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH005", MaMA = "MA23", SL = 0, ThanhTien = 0 },
                new OrderItem { MaDH = "DH005", MaMA = "MA12", SL = 0, ThanhTien = 0 }
                );

            context.Payments.AddOrUpdate(
                p => p.MaHD,
                new Payment { MaHD = "HD001", SoTien = 1758000, NgayTT = new DateTime(2024, 12, 30), MaDH = "DH001", MaNV = "NV1" },
                new Payment { MaHD = "HD002", SoTien = 1571000, NgayTT = new DateTime(2024, 12, 30), MaDH = "DH002", MaNV = "NV1" },
                new Payment { MaHD = "HD003", SoTien = 2239000, NgayTT = new DateTime(2024, 12, 28), MaDH = "DH003", MaNV = "NV6" },
                new Payment { MaHD = "HD004", SoTien = 2792000, NgayTT = new DateTime(2024, 12, 30), MaDH = "DH004", MaNV = "NV1" },
                new Payment { MaHD = "HD005", SoTien = 2197000, NgayTT = new DateTime(2024, 12, 29), MaDH = "DH005", MaNV = "NV1" }
                );

            context.SaveChanges();
        }
    }
}

namespace WindowsFormsApp2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WindowsFormsApp2.DAL.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<WindowsFormsApp2.DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WindowsFormsApp2.DAL.DBContext context)
        {
            context.LienHeDbset.AddOrUpdate(new LienHe
            {
                TenGoi = "Ba",
                Email = "ba@gmail.com",
                SDT = "0123456789",
                DiaChi = "Huế",
                TenNhom = "Gia đình"

            }, new LienHe
            {
                TenGoi = "Mẹ",
                Email = "me@gmail.com",
                SDT = "1123456789",
                DiaChi = "Huế",
                TenNhom = "Gia đình"

            }, new LienHe
            {
                TenGoi = "Ki",
                Email = "ki@gmail.com",
                SDT = "2123456789",
                DiaChi = "Huế",
                TenNhom = "Thú cưng"

            }, new LienHe
            {
                TenGoi = "Mino",
                Email = "mino@gmail.com",
                SDT = "3123456789",
                DiaChi = "Huế",
                TenNhom = "Thú cưng"

            }, new LienHe
            {
                TenGoi = "Sơn",
                Email = "son@gmail.com",
                SDT = "4123456789",
                DiaChi = "Hà Giang",
                TenNhom = "Best friend"

            }, new LienHe
            {
                TenGoi = "Sơn Tùng MTP",
                Email = "thanhtung@gmail.com",
                SDT = "5123456789",
                DiaChi = "Thái Bình",
                TenNhom = "Best friend"

            }, new LienHe
            {
                TenGoi = "Tùng",
                Email = "tung@gmail.com",
                SDT = "6123456789",
                DiaChi = "Huế",
                TenNhom = "Best friend"

            }
            , new LienHe
            {
                TenGoi = "Hinata",
                Email = "hinata@gmail.com",
                SDT = "7123456789",
                DiaChi = "Nhật bổn",
                TenNhom = "Fan naruto"

            }, new LienHe
            {
                TenGoi = "Sasuke",
                Email = "sasuke@gmail.com",
                SDT = "8123456789",
                DiaChi = "Nhật bổn",
                TenNhom = "Fan naruto"

            }, new LienHe
            {
                TenGoi = "Naruto",
                Email = "naruto@gmail.com",
                SDT = "9123456789",
                DiaChi = "Japan",
                TenNhom = "Fan naruto"

            }, new LienHe
            {
                TenGoi = "Boruto",
                Email = "boruto@gmail.com",
                SDT = "987654321",
                DiaChi = "Japan",
                TenNhom = "Fan naruto"

            }, new LienHe
            {
                TenGoi = "GRAB",
                Email = "grab@gmail.com",
                SDT = "987654322",
                DiaChi = "Huế",
                TenNhom = "Đói quá không ngủ được"

            }, new LienHe
            {
                TenGoi = "Sushi",
                Email = "hinate@gmail.com",
                SDT = "987654323",
                DiaChi = "Huế",
                TenNhom = "Đói quá không ngủ được"

            }
            );

            context.NhomDbset.AddOrUpdate(new Nhom
            {
                TenNhom = "Gia đình"
            }, new Nhom
            {
                TenNhom = "Thú cưng"
            }, new Nhom
            {
                TenNhom = "Best friend"
            }, new Nhom
            {
                TenNhom = "Không đội trời chung"
            }, new Nhom
            {
                TenNhom = "Fan naruto"
            }, new Nhom
            {
                TenNhom = "Đồng nghiệp"
            }, new Nhom
            {
                TenNhom = "Đói quá không ngủ được"
            }
            );
            context.SaveChanges();
        }
    }
}

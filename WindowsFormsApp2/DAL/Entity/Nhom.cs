using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.DAL.Entity
{
    public class Nhom
    {
        [Key]
        public string TenNhom { get; set; }
        public virtual ICollection<LienHe> DanhSachLienHe { get; set; }
        public static List<Nhom> GetList()
        {
            return new DBContext().NhomDbset.OrderBy(e => e.TenNhom).ToList();
        }
        public static void Remove(String tenNhom)
        {
            var db = new DBContext();
            var objSV = db.NhomDbset.Where(e => e.TenNhom == tenNhom).FirstOrDefault();
            if (objSV != null)
                db.NhomDbset.Remove(objSV);
            db.SaveChanges();
        }
        public static Nhom TimKiem(String tenNhom)
        {
            var db = new DBContext();
            var objNhom = db.NhomDbset.Where(e=>e.TenNhom==tenNhom).FirstOrDefault();
            if (objNhom != null)
                return objNhom;
            return null;
        }
        public static void Add(String tenNhom)
        {
            var db = new DBContext();
            db.NhomDbset.Add(new Nhom {TenNhom=tenNhom});
            db.SaveChanges();
        }
    }
}

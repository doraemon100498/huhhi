using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp2.DAL.Entity
{
    public class LienHe
    {
        [Key]
        public string TenGoi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string TenNhom { get; set; }
        [ForeignKey("TenNhom")]
        public virtual Nhom Nhom { get; set; }
        public static List<LienHe> GetList(String tenNhom)
        {
            return new DBContext().LienHeDbset.Where(e=>e.TenNhom==tenNhom).OrderBy(e=>e.TenGoi).ToList();
        }
        public static LienHe GetLienHe(String tenGoi)
        {
            return new DBContext().LienHeDbset.Where(e => e.TenGoi == tenGoi).FirstOrDefault();
        }
        public static void Remove(String tenGoi)
        {
            var db = new DBContext();
            var objSV = db.LienHeDbset.Where(e => e.TenGoi == tenGoi).FirstOrDefault();
            if (objSV != null)
                db.LienHeDbset.Remove(objSV);
            db.SaveChanges();
        }
        public static void RemoveListContact(String tenNhom)
        {
            var db = new DBContext();
            var Contacts = db.LienHeDbset.Where(e => e.TenNhom == tenNhom).ToList();
            db.LienHeDbset.RemoveRange(Contacts);
            db.SaveChanges();
        }
        public static void Add(LienHe lh)
        {
            var db = new DBContext();
            db.LienHeDbset.Add(lh);
            db.SaveChanges();
        }
        public static List<LienHe> TimKiem(String tenNhom,String key)
        {
            List<LienHe> dslh = LienHe.GetList(tenNhom);
            List<LienHe> dstk=new List<LienHe>();
            foreach(var i in dslh){
                if (i.TenGoi.Trim().ToLower().Contains(key.Trim().ToLower()))
                {
                    dstk.Add(i);
                }                   
            }
            return dstk;
        }
        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
        public static bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }
        public static void Edit(LienHe lh)
        {
            var db = new DBContext();
            var objLH = db.LienHeDbset.Where(e => e.TenGoi == lh.TenGoi).FirstOrDefault();
            if (objLH != null)
            {
                objLH.SDT = lh.SDT;
                objLH.DiaChi = lh.DiaChi;
                objLH.Email = lh.Email;
                objLH.TenNhom = lh.TenNhom;
            }
            db.SaveChanges();

        }
    }
}

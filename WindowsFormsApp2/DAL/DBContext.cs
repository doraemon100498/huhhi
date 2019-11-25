using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DAL.Entity;

namespace WindowsFormsApp2.DAL
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("Data Source=.;Initial Catalog=QuanLyDanhBa;Persist Security Info=True;User ID=sa;Password=1234")
        {}
        public DbSet<LienHe> LienHeDbset { get; set; }
        public DbSet<Nhom> NhomDbset { get; set; }
    }
}

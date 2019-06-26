using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Model;

namespace Xsis.Repo
{
    public class ForgotPasswordFormRepo
    {
        public static List<AddrBook> GetAll()
        {
            List<AddrBook> result = new List<AddrBook>();
            using (var db = new DataContext())
            {
                result = db.AddrBook.ToList();
                return result;
            }
        }

        public static AddrBook GetByID(int ID)
        {
            AddrBook forgotpasswordform = new AddrBook();
            using (DataContext db = new DataContext())
            {
                forgotpasswordform = db.AddrBook.Where(d => d.id == ID).First();
                return forgotpasswordform;
            }
        }

        public static Boolean Editforgotpasswordform(AddrBook forgotpasswordform)
        {
            try
            {
                AddrBook dep;
                using (DataContext db = new DataContext())
                {
                    dep = db.AddrBook.Where(d => d.id == forgotpasswordform.id).First();
                    dep.id = forgotpasswordform.id;
                    dep.modified_by = forgotpasswordform.modified_by;
                    dep.modified_on = DateTime.Now;
                    dep.abpwd = forgotpasswordform.abpwd;
                    db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}

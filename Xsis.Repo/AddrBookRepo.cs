using Xsis.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngxsis.Repo
{

    public class AddrBookRepo
    {
        public static AddrBook GetUname(string Uname)
        {

            AddrBook ab = new AddrBook();
            using (DataContext db = new DataContext())
            {
                ab = db.AddrBook.Where(d => d.email == Uname || d.abuid == Uname).FirstOrDefault();

                //string password = ab.abpwd;
                ////parameter untuk decode password md5 
                //System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                //System.Text.Decoder utf8Decode = encoder.GetDecoder();
                //byte[] todecode_byte = Convert.FromBase64String(password);
                //int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                //char[] decoded_char = new char[charCount];
                //utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                //string result = new String(decoded_char);

                //ab.abpwd = result;
                //end parameter untuk decode password md5 


                return ab;
            }
        }

        public static Boolean EditAddrBook(int ID)
        {
            try
            {
                AddrBook change;
                using (DataContext db = new DataContext())
                {
                    change = db.AddrBook.Where(itm => itm.id == ID).First();
                    change.attempt += 1;
                    change.modified_on = DateTime.Now;
                    db.Entry(change).State = EntityState.Modified;
                    db.SaveChanges();

                    if(change.attempt == 3)
                    {
                        change.is_locked = true;
                        db.Entry(change).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Boolean clrAddrBook()
        {
            try
            {
                List<AddrBook> result = new List<AddrBook>();
                using (DataContext db = new DataContext())
                {
                    result = db.AddrBook.Where(itm => itm.modified_on != null && itm.modified_on < DateTime.Today && itm.attempt < 3).ToList();
                    foreach(var item in result)
                    {
                        item.modified_on = null;
                        item.attempt = 0;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
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

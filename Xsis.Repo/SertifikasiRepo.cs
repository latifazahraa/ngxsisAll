using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Model;

namespace Xsis.Repo
{
    public class SertifikasiRepo
    {
        public static List<Sertifikasi> GetAll()
        {
            List<Sertifikasi> result = new List<Sertifikasi>();
            using (DataContext db = new DataContext())
            {
                result = db.Sertifikasi.OrderByDescending(item3 => item3.id).ToList();
            }
            return result;
        }

        public static bool TmbhSertifikasi(Sertifikasi sertif)
        {
            try
            {
                // Riwayat_Pendidikan pendidikanmdl = new Riwayat_Pendidikan();
                using (DataContext db = new DataContext())
                {
                    sertif.created_on = DateTime.Now;
                    db.Sertifikasi.Add(sertif);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Boolean HapusSertifikasi(int ID, Sertifikasi sertif)
        {
            try
            {
                Sertifikasi sert;
                using (DataContext db = new DataContext())
                {
                    sert = db.Sertifikasi.Where(d => d.id == ID).First();
                    sert.is_delete = true;
                    sert.deleted_by = sertif.deleted_by;
                    sert.deleted_on = DateTime.Now;
                    db.Entry(sert).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Sertifikasi GetByID(int ID)
        {
            Sertifikasi sertif = new Sertifikasi();
            using (DataContext db = new DataContext())
            {
                sertif = db.Sertifikasi.Where(d => d.id == ID).First();
                return sertif;
            }
        }

        public static Boolean EditSertifikasi(Sertifikasi sertif)
        {
            try
            {
                Sertifikasi sertifMdl;
                using (DataContext db = new DataContext())
                {
                    sertifMdl = db.Sertifikasi.Where(d => d.id == sertif.id).First();
                    sertifMdl.modified_by = sertif.modified_by;
                    sertifMdl.modified_on = DateTime.Now;
                    sertifMdl.id = sertif.id;
                    sertifMdl.certificate_name = sertif.certificate_name;
                    sertifMdl.publisher = sertif.publisher;
                    sertifMdl.valid_start_year = sertif.valid_start_year;
                    sertifMdl.valid_start_month = sertif.valid_start_month;
                    sertifMdl.until_year = sertif.until_year;
                    sertifMdl.until_month = sertif.until_month;
                    sertifMdl.notes = sertif.notes;
                    db.Entry(sertifMdl).State = System.Data.Entity.EntityState.Modified;
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

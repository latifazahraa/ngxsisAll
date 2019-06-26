using Xsis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Xsis.Repo
{
    public class OrganisasiRepo
    {
        public static List<Organisasi> GetAll()
        {
            List<Organisasi> result = new List<Organisasi>();
            using (var db = new DataContext())
            {
                //result = db.Organisasi.ToList();
                result = (from t in db.Organisasi
                          where t.biodata_id == 1
                          select t).OrderByDescending(x => x.id).ToList();
                return result;
            }
            
        }

        public static object GetSelect()
        {
            throw new NotImplementedException();
        }

        public static Boolean Createorganisasi(Organisasi organisasimdl)
        {
            try
            {
                Organisasi organisasi = new Organisasi();
                using (DataContext db = new DataContext())
                {
                    organisasi.biodata_id = 1;
                    organisasi.created_by = organisasimdl.created_by;
                    organisasi.created_on = DateTime.Now;
                    organisasi.name = organisasimdl.name;
                    organisasi.position = organisasimdl.position;
                    organisasi.entry_year = organisasimdl.entry_year;
                    organisasi.exit_year = organisasimdl.exit_year;
                    organisasi.responsibility = organisasimdl.responsibility;
                    organisasi.notes = organisasimdl.notes;
                    db.Organisasi.Add(organisasi);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static Organisasi GetByID(int ID)
        {
            Organisasi organisasi = new Organisasi();
            using (DataContext db = new DataContext())
            {
                organisasi = db.Organisasi.Where(d => d.id == ID).First();
                return organisasi;
            }
        }

        public static Boolean Deleteorganisasi(int ID, Organisasi organisasimdl)
        {
            try
            {
                Organisasi dep;
                using (DataContext db = new DataContext())
                {
                    dep = db.Organisasi.Where(d => d.id == ID).First(); 
                    dep.is_delete = true;
                    dep.deleted_by = organisasimdl.deleted_by;
                    dep.deleted_on = DateTime.Now;
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

        public static Boolean Editorganisasi(Organisasi organisasi)
        {
            try
            {
                Organisasi dep;
                using (DataContext db = new DataContext())
                {
                    dep = db.Organisasi.Where(d => d.id == organisasi.id).First();//d adalah suatu elemen di dalam dep, dimana d adalah dep.id, kemudian dep.id dibandingkan dengan ID.
                    dep.modified_by = organisasi.modified_by;
                    dep.modified_on = DateTime.Now;
                    dep.notes = organisasi.notes;
                    dep.responsibility = organisasi.responsibility;
                    dep.exit_year = organisasi.exit_year;
                    dep.entry_year = organisasi.entry_year;
                    dep.position = organisasi.position;
                    dep.name = organisasi.name;
                    db.Entry(dep).State = EntityState.Modified;//dep diperlakukan sebagai Entry di dalam database organisasi (System.Data.Entity.EntityState.Modified)
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

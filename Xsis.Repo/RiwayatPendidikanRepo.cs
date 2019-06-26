using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Model;
using Xsis.ViewModel;

namespace Xsis.Repo
{
    public class RiwayatPendidikanRepo
    {
        //public static List<Riwayat_Pendidikan> GetAll()
        //{
        //    List<Riwayat_Pendidikan> result = new List<Riwayat_Pendidikan>();
        //    using (DataContext db = new DataContext())
        //    {
        //        result = db.Riwayat_Pendidikan.ToList();
        //    }
        //    return result;
        //}

        public static List<RiwayatPendidikanViewModel> GetAll(int idBiodata)
        {
            List<RiwayatPendidikanViewModel> result = new List<RiwayatPendidikanViewModel>();
            using (var db = new DataContext())
            {
                result = (from item1 in db.Riwayat_Pendidikan
                          join item2 in db.Educational_Level on item1.education_level_id equals item2.id
                          where item1.is_delete == false && item1.biodata_id == idBiodata
                          select new RiwayatPendidikanViewModel
                          {
                              id = item1.id,
                              school_name = item1.school_name,
                              education_level_name = item2.name,
                              entry_year = item1.entry_year,
                              graduation_year = item1.graduation_year,
                              major = item1.major,
                              gpa = item1.gpa
                          }
                          
                          ).OrderByDescending(item3 => item3.id).ToList();
            }
            return result;
        }

        public static List<Educational_Level> GetSelect()
        {
            List<Educational_Level> result = new List<Educational_Level>();
            using (var db = new DataContext())
            {
                result = db.Educational_Level.ToList();
                return result;
            }
        }

        public static bool Tmbhpendidikan(Riwayat_Pendidikan pendidikan)
        {
            try
            {
               // Riwayat_Pendidikan pendidikanmdl = new Riwayat_Pendidikan();
                using (DataContext db = new DataContext())
                {
                    pendidikan.created_on = DateTime.Now;
                    db.Riwayat_Pendidikan.Add(pendidikan);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Boolean HapusPendidikan(int ID, Riwayat_Pendidikan pend)
        {
            try
            {
                Riwayat_Pendidikan dep;
                using (DataContext db = new DataContext())
                {
                    dep = db.Riwayat_Pendidikan.Where(d => d.id == ID).First();
                    dep.is_delete = true;
                    dep.deleted_by = pend.deleted_by;
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

        public static Riwayat_Pendidikan GetByID(int ID)
        {
            Riwayat_Pendidikan pendidikan = new Riwayat_Pendidikan();
            using (DataContext db = new DataContext())
            {
                pendidikan = db.Riwayat_Pendidikan.Where(d => d.id == ID).First();
                return pendidikan;
            }
        }

        public static Boolean EditPendidikan(Riwayat_Pendidikan pendidikanMdl)
        {
            try
            {
                Riwayat_Pendidikan pend;
                using (DataContext db = new DataContext())
                {
                    pend = db.Riwayat_Pendidikan.Where(d => d.id == pendidikanMdl.id).First();
                    pend.modified_by = pendidikanMdl.modified_by;
                    pend.modified_on = DateTime.Now;
                    pend.biodata_id = pend.biodata_id;
                    pend.id = pendidikanMdl.id;
                    pend.school_name = pendidikanMdl.school_name;
                    pend.major = pendidikanMdl.major;
                    pend.education_level_id = pendidikanMdl.education_level_id;
                    pend.entry_year = pendidikanMdl.entry_year;
                    pend.graduation_year = pendidikanMdl.graduation_year;
                    pend.notes = pendidikanMdl.notes;
                    db.Entry(pend).State = System.Data.Entity.EntityState.Modified;
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

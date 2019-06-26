using Xsis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngxsis.Repo
{
    public class CatatanRepo
    {
        public static List<Catatan> GetAll()
        {
            List<Catatan> result = new List<Catatan>();
            using (DataContext db = new DataContext())
            {
                result = db.Catatan.ToList();
            }
            return result;
        }
    }
}

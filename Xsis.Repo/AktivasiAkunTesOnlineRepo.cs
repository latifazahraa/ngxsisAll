using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Model;

namespace Xsis.Repo
{
    public class AktivasiAkunTesOnlineRepo
    {
        public static List<Test_Type> GetAllType()
        {
            List<Test_Type> result = new List<Test_Type>();
            using (DataContext db = new DataContext())
            {
                result = db.Test_Type.OrderByDescending(item3 => item3.id).ToList();
            }
            return result;
        }

        public static List<Online_Test> GetAllTes()
        {
            List<Online_Test> result = new List<Online_Test>();
            using (DataContext db = new DataContext())
            {
                result = db.Online_Test.OrderByDescending(item3 => item3.id).ToList();
            }
            return result;
        }
    }
}

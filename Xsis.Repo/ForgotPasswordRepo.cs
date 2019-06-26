using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;  //tambahan
using System.Net.Mail;   //tambahan
using System.Net.Http;   //tambahan
using Xsis.Model;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;

namespace Xsis.Repo
{
    public class ForgotPasswordRepo
    {
        public static AddrBook FindEmail(string email)
        {

            AddrBook ab = new AddrBook();
            using (DataContext db = new DataContext())
            {
                ab = db.AddrBook.Where(d => d.email == email).FirstOrDefault();
                return ab;
            }
        }

        public static string UpdateDB(string email,string shortURL)
        {
            var result = "";
            AddrBook ab = new AddrBook();
            using (DataContext db = new DataContext())
            {
                ab = db.AddrBook.Where(d => d.email == email).First();
                if (ab.fp_counter == null)
                {
                    ab.fp_counter = 0;
                }
                ab.fp_counter += 1;
                ab.fp_expired_date = DateTime.Now.AddMinutes(10);
                ab.fp_token = shortURL;
                db.Entry(ab).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return result;
        }


        public static string SendEmail(string email)

        {
            var shortURL = RandomURL();
            try

            {

                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("latia.sabrina@gmail.com");
                mail.To.Add(email);
                mail.Subject = "XSIS forgot password verification";
                mail.IsBodyHtml = true;
                string htmlStr = "Please click on the below link to set up your password <a href=\" http://localhost:41162/NewPassword/Index?shortURL=" + shortURL + "\" >" + shortURL + "</a>";
                mail.Body = htmlStr;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("latia.sabrina@gmail.com", "19051996");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                UpdateDB(email, shortURL);

                return shortURL;
            }

            catch (Exception)

            {
                var error = "";
                return error;
            }

        }

        public static bool VerificationLink(string shortURL)
        {
            string token = shortURL;
            var vDateNow = DateTime.Now;
            AddrBook ab = new AddrBook();
            using (DataContext db = new DataContext())
            {
                ab = db.AddrBook.Where(d => d.fp_token == shortURL.Trim()).FirstOrDefault();

                if (ab != null)
                {
                    if (vDateNow <= ab.fp_expired_date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
   
            }
        }



        public static string RandomURL()
        {
            // List of characters and numbers to be used...  
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<char> characters = new List<char>()
    {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
    'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    'Q', 'R', 'S',  'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_'};

            string URL = "";
            Random rand = new Random();
            // run the loop till I get a string of 10 characters  
            for (int i = 0; i < 11; i++)
            {
                // Get random numbers, to get either a character or a number...  
                int random = rand.Next(0, 3);
                if (random == 1)
                {
                    // use a number  
                    random = rand.Next(0, numbers.Count);
                    URL += numbers[random].ToString();
                }
                else
                {
                    random = rand.Next(0, characters.Count);
                    URL += characters[random].ToString();
                }
            }
            return URL;
        }
    }  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Model;
using System.IO;

namespace Taxi.Helpers.Auth
{
    class Authhelper
    {
        taxiEntities context = new taxiEntities();

        private static readonly string path = $"{AppDomain.CurrentDomain.BaseDirectory}/auth.txt";

        public user AuthSaveUser()
        {
            if (File.Exists(path))
            {
                string[] userdata = File.ReadAllLines(path);
                return Auth(userdata[0], userdata[1]);
            }
            return null;
        }

        public static bool IsRemember()
        {
            return File.Exists(path);
        }

        public void AuthCreateFile(user user)
        {
            string[] userdata = new string[2];
            userdata[0] = user.email;
            userdata[1] = user.password;
            File.WriteAllLines(path, userdata);
        }

        public user Auth(string login, string pass)
        {
            var user = context.user.ToList().Where(i => i.email == login && i.password == pass);
            if (user.Count() == 1)
            {
                return user.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public void LogOut()
        {
            File.Delete(path);
        }
    }
}

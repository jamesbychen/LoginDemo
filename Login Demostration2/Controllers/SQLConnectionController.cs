using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Login_Demostration2.Models
{
    public class SQLConnectionController : Controller
    {
        public string userId = "james";
        public string userName = "James Chen";
        string password = "12345678";
        public string key = "demo";
        public string MD5Password()
        {
            MD5 hasher = MD5.Create();
            string MD5pw = Convert.ToBase64String(hasher.ComputeHash(Encoding.Default.GetBytes(password + key)));
            return MD5pw;
    }
}

}
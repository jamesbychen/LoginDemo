using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;

namespace Login_Demostration2.Controllers
{
    public class PublicFunctionController : ApiController
    {
        SQLConnectionController scc = new SQLConnectionController();
        //取得密碼(with MD5)
        public string getPassword(string name)
        {
            //取出使用者的密碼
            return scc.MD5Password();
        }

        //將字串加入KEY後以MD5加密
        public string getMD5(string pw)
        {
            string md5key = pw + scc.key;
            MD5 md5hasher = MD5.Create();
            //將密碼串入KEY值之後再以MD5加密
            string result = Convert.ToBase64String(md5hasher.ComputeHash(Encoding.Default.GetBytes(md5key)));
            return result;
        }

        //取得IP
        public string getClientIP()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(sIPAddress))
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] ipArray = sIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }
    }
}

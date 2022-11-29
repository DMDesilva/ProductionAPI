using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class LoginUsrAuth
    {
        public string username { get; set; }
        public string password { get; set; }

        static string sysPWKey = "@1B2c3D4e5F6g7H8";
      //  static string sysEncKey = "7H81B2c3D4e@5F6g";
        public LoginUsrAuth()
        {
            username = "";
            password = "";
        }

        public DataTable Userlog()
        {   //LoginUsrAuth log = new LoginUsrAuth();

            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(password);
            var tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(sysPWKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();

            string pass = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            {
                
                var objDIc = new Dictionary<string, object>
                {     
                    {"username",username},
                    {"pass",pass},
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("spr_login", objDIc);
            }

        }

        public DataTable MCUserlog()
        {   //LoginUsrAuth log = new LoginUsrAuth();

            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(password);
            var tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(sysPWKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();

            string pass = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            {

                var objDIc = new Dictionary<string, object>
                {
                    {"username",username},
                    {"pass",pass},
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("mc_inven_login", objDIc);
            }

        }

        public DataTable VerifyAccount()
        {   //LoginUsrAuth log = new LoginUsrAuth();

            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(password);
            var tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(sysPWKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();

            string pass = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            {

                var objDIc = new Dictionary<string, object>
                {
                    {"username",username},
                    {"pass",pass},
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("order_sheet_login", objDIc);
            }

        }

        public static string Decryptor(string pass)

        {
            string value = string.Empty;


                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(pass);
                var tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(sysPWKey);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }
    }
}

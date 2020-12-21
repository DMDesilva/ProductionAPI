using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class CommonData
    {

        public static string ConStr()
        {
            var conS = "";
            try
            {
                // conS = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                // conS = @"Data Source=DESKTOP-7E3JA5M\SQLEXPRESS;DESKTOP-7E3JA5M\SQLEXPRESSDESKTOP-7E3JA5M\SQLEXPRESSinitial catalog=ORACLE;user id=kan;password=Abc@1234";
                // conS = @"Data Source=DESKTOP-7E3JA5M\SQLEXPRESS;initial catalog=ORACLE;";
           conS = @"Data Source=192.168.1.17;initial catalog=ORACLE;user id=sa;password=jkGMT@123";
         // conS = @"Data Source=DESKTOP-MPPPN7P\SQLEXPRESS;initial catalog=ORACLE;user id=sa;password=123";
              // conS = @"Data Source=DESKTOP-7E3JA5M\DM;initial catalog=ORACLE;Integrated Security=True";
            }
            catch (Exception e)
            {
                var tt = e;
                // ErrorHandler.Log("Common- getConStr", e.Message, e.Source);
#if DEBUG
                throw;
#endif
            }
            return conS;
        }



    }
}

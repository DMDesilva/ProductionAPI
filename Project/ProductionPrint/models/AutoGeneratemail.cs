using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class AutoGeneratemail
    {
        public string mas_cat { get; set; }
        public string cat_name { get; set; }
        public string sup_item_nme { get; set; }
        public string sup_item_code { get; set; }
        public string sb_itm_nme { get; set; }
        public string unit_name { get; set; }
        public decimal stock_qty { get; set; }
        public int moq { get; set; }
        public int ids { get; set; }

        public string sto { get; set; }
        public string scc { get; set; }
        public string sbcc { get; set; }
        public string sbody { get; set; }
        public string ssubject { get; set; }

        private decimal connection { get; set; }

        public AutoGeneratemail()
        {
            mas_cat = "";
            cat_name = "";
            sup_item_nme= "";
            sup_item_code= "";
            sb_itm_nme= "";
            unit_name= "";
            stock_qty= 0;
            moq= 0;
            ids = 1;
            sto = "madusanka@jkgmnt.com,prasad@jkgmnt.com,ashoka@jkgmnt.com,priyadarshani@jkgmnt.com,hashara@jkgmnt.com,sashila@jkgmnt.com";
            //prasad@jkgmnt.com,ashoka@jkgmnt.com,priyadarshani@jkgmnt.com,hashara@jkgmnt.com,sashila@jkgmnt.com
            scc = "";
            sbcc = "danushkads48@gmail.com";
            sbody = "";
            ssubject = "SEWING STOCK ITEMS LIST";
        }

        public DataTable AutosendMailItmList()
        {
            var dt = (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [mas_cat],[cat_name],[sup_item_nme]," +
                "[sup_item_code],[sb_itm_nme],[unit_name],[stock_qty],[moq]" +
                "FROM [erpWarehouse].[dbo].[View_load_all_stock] " +
                "where moq >= stock_qty and cat_name='SEWING' order by [mas_cat]");

            string sBody = "<!DOCTYPE html> " +
              "<html> " +
              "<head> " +
              "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head> " +

          "<body>" +
           //Mail Header

           "<table style='border: 3px solid #000080; font-family: Cambria; height: 34px;'>" +
           "<tbody>" +
           "<tr><th style='width:1500px;font-size:1.5rem; color:black;'> SEWING STOCK ITEMS LIST </th></tr> " +
           "</tbody>" +
           "</table>" + "</br>" +
           "<p style='color:red;font-size:1rem;'>" + DateTime.Now.ToString("yyyy-MM-dd") + "</p>" +
            // ITEM LIST 
            "<table style='font-family: Cambria;'>" +
             "<thead>" +
              "<tr>" +
                " <th style='border:1px solid black; padding:5px;'> #</th>" +
                " <th style='border:1px solid black; padding:5px;'> Item Catgory</th>" +
                " <th style='border:1px solid black; padding:5px;'> Item Name</th>" +
                " <th style='border:1px solid black; padding:5px;'> Sub Item Name</th>" +
                " <th style='border:1px solid black; padding:5px;'> Unit</th>" +
                " <th style='border:1px solid black; padding:5px;'>Stock Qty</th>" +
                " <th style='border:1px solid black; padding:5px;'>Minimum Order Qty</th>" +
               "</tr>" +

            "</thead>" +
           "<tbody>";
            foreach (DataRow row in dt.Rows)
            {
                // Get the values from the current row
                mas_cat = (string)row["mas_cat"];
                sup_item_nme = (string)row["sup_item_nme"];
                sup_item_code = (string)row["sup_item_code"];
                sb_itm_nme = (string)row["sb_itm_nme"];
                unit_name = (string)row["unit_name"];
                stock_qty = (decimal)row["stock_qty"];
                moq = (int)row["moq"];

                // Append a list item to the HTML string for each row
                sBody += "<tr> <td style='border:1px solid black; color:black;padding:5px;'>" + ids + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + mas_cat + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + sup_item_nme + " - " + sup_item_code + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + sb_itm_nme + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + unit_name + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + stock_qty + " </td>"
                       + "<td style='border:1px solid black; color:black;padding:5px;'>" + moq + " </td> </tr>";

                ids++;

            }

            sBody += "</tbody>" +
     "</table>" +
    //Auto Generate Word
    "<hr><p><font size='1'><I>This is a Auto Generated Mail From JK Mail System Developed By JK IT Department [Generated Date " + DateTime.Now.ToString("yyyy-MM-dd") + " Time " + DateTime.Now.ToString("hh:mm:ss") + "- From JK Messenger ]</I></font></p>" +
    "</hr></body></html>";


            GenarateMail(sto, scc, sbcc, sBody, ssubject);
          //  GenarateMail('danushkads48@gmail.com', 'danushkads48@gmail.com', 'danushkads48@gmail.com', sBody,);
            return dt;
        }

        private string GenarateMail(string sTo, string sCc, string sBcc, string sBody, string sSubject)
        {
            string returnValue = "";
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Host = "5.189.189.152";
                client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("jkmsngr@jkgmnt.com", "jkm!1234");
                client.Timeout = 20000;
                MailAddress mailAdress = new MailAddress("madusanka@jkgmnt.com", "JK Messenger");
                msg.From = mailAdress;

                if (sTo.Trim().Length > 0)
                {
                    foreach (string sToBreak in sTo.Split(",".ToCharArray()))
                        msg.To.Add(sToBreak);
                }

                if (sCc.Trim().Length > 0)
                {
                    foreach (string sCcBreak in sCc.Split(",".ToCharArray()))
                        msg.CC.Add(sCcBreak);
                }

                if (sBcc.Trim().Length > 0)
                {
                    foreach (string sBccBreak in sBcc.Split(",".ToCharArray()))
                        msg.Bcc.Add(sBccBreak);
                }
                msg.Subject = sSubject;
                msg.Body = sBody;
                msg.BodyEncoding = System.Text.Encoding.Default;
                msg.SubjectEncoding = System.Text.Encoding.Default;
                msg.IsBodyHtml = true;
                client.Send(msg);

                //  Functions.WriteLog("Logs", "OutLook.jk", sSubject + " - SEND SUCCESSFULLY");
                returnValue = sSubject + " - SEND";
            }
            catch (Exception Ex)
            {
                //  Functions.WriteLog("Logs", "OutLook.jk", sSubject + " - SENDING FAILED - " + Ex.Message);
                returnValue = sSubject + " - FAIL" + Ex;
            }

            return returnValue;
        }
    }

}

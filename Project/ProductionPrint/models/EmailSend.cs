using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class EmailSend
    {
        public string sto { get; set; }
        public string scc { get; set; }
        public string sbcc { get; set; }
        public string sbody { get; set; }
        public string ssubject { get; set; }
        public string po_no { get; set; }
        public string email { get; set; }
        public int qnty { get; set; }

        public EmailSend()
        {
            sto = "";
            scc = "";
            sbcc = "";
            sbody = "";
            ssubject = "";
            po_no = "";
            email = "";
            qnty =0;
        }
        public DataTable SendEmails()
        {
            var rtnVal= new DataTable ();
            string sBody = "<!DOCTYPE html> " +
               "<html> " +
               "<head> " +
               "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head> " +

          
           "<body>" +
            //Mail Header

            "<table style='border: 3px solid Blue; font-family: Cambria; height: 34px;'>" +
            "<tbody>" +
            "<tr><th style='width: 700px;'> Fabric Stock Remind" + DateTime.Now.ToString("yyyy-MM-dd") + "</th></tr> " +
            "</tbody>" +
            "</table>" +

          //Auto Generate Word
           "<hr><p><font size='1'><I>This is a Auto Generated Mail From JK Mail System Developed By JK IT Department [Generated Date " + DateTime.Now.ToString("yyyy-MM-dd") + " Time " + DateTime.Now.ToString("hh:mm:ss") + "- From JK Messenger ]</I></font></p>" +
           "</hr></body></html>";
            GenarateMail(sto, scc, sbcc, sBody, ssubject);
            return rtnVal;
        }

        public DataTable SendEmailsQntyChange()
        {
            var rtnVal = new DataTable();
            string sBody = "<!DOCTYPE html> " +
               "<html> " +
               "<head> " +
               "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head> " +


           "<body>" +
            //Mail Header

            "<table style='border: 3px solid Blue; font-family: Cambria; height: 34px;'>" +
            "<tbody>" +
            "<tr><th style='width: 700px;'> Production Qnty Change </th></tr> " +
            "</tbody>" +
            "</table>" + "</br>" +
            "<p>"+ DateTime.Now.ToString("yyyy-MM-dd")+"<p>" +
            "<h3> <b>"+ po_no + "</b> </h3> "+ "<h4> change into "+ qnty + "PCs. </h4> " +"<p> Qnty Changed Successfully.</p>" +
           //Auto Generate Word
           "<hr><p><font size='1'><I>This is a Auto Generated Mail From JK Mail System Developed By JK IT Department [Generated Date " + DateTime.Now.ToString("yyyy-MM-dd") + " Time " + DateTime.Now.ToString("hh:mm:ss") + "- From JK Messenger ]</I></font></p>" +
           "</hr></body></html>";
            GenarateMail(sto, scc, sbcc, sBody, ssubject);
            return rtnVal;
        }
        public DataTable SendEmailsChangePassword()
        {
            var rtnVal = new DataTable();
            string sBody = "<!DOCTYPE html> " +
               "<html> " +
               "<head> " +
               "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head> " +
           "<body>" +
            //Mail Header

            "<table style='border: 3px solid Blue; font-family: Cambria; height: 34px;'>" +
            "<tbody>" +
            "<tr><th style='width: 700px;'> Your Password is Changed </th></tr> " +
            "</tbody>" +
            "</table>" + "</br>" +
            "<p>" + DateTime.Now.ToString("yyyy-MM-dd") + "<p>" +
            "<h3> <b> Password :- </b> </h3> " + "<h4> Jk@1234 </h4> " +
           //Auto Generate Word
           "<hr><p><font size='1'><I>This is a Auto Generated Mail From JK Mail System Developed By JK IT Department [Generated Date " + DateTime.Now.ToString("yyyy-MM-dd") + " Time " + DateTime.Now.ToString("hh:mm:ss") + "- From JK Messenger ]</I></font></p>" +
           "</hr></body></html>";
            GenarateMail(sto, scc, sbcc, sBody, ssubject);
            return rtnVal;
        }
        private string GenarateMail(string sTo, string sCc, string sBcc, string sBody, string sSubject)
        {
            string returnValue = "";
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("jkmsngr@gmail.com", "jkMail@123");
                client.Timeout = 20000;
                MailAddress mailAdress = new MailAddress("jkmsngr@gmail.com", "JK Messenger");
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

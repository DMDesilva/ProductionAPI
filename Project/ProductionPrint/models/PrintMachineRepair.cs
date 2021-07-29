using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class PrintMachineRepair
    {
        public Guid idx { get; set; }
        public string machine_no { get; set; }
        public string machine_mode { get; set; }
        public string serial_no { get; set; }
        public DateTime purchase_date  { get; set; }
        public decimal purch_value { get; set; }
        public string supplier { get; set; }
        public string owner { get; set; }
        public string ip_address { get; set; }
        public string img { get; set; }
        public Guid usr { get; set; }
        public int typ { get; set; }
        private string connection { get; set; }

        public PrintMachineRepair(string conn)
        {
            idx = new Guid();
            machine_no = "";
            machine_mode = "";
            serial_no = "";
            purchase_date = DateTime.Now;
            purch_value = 0;
            supplier = "";
            owner = "";
            ip_address = "";
            img = "";
            usr=new Guid();
            typ = 0;
            connection = conn;
        }
        public DataTable LoadPrintmachinRep()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [Idx] ,[id],[machine_mode],[serial_no],CONVERT(DATE,[purchase_date]) as purchase_date,[purch_value],[supplier]  ,[owner],[ip_address],[img] ,0 as cs ,[machine_no] FROM [dbo].[_PrintSec_machine] order by id");
            }
        }
        public DataTable Save_machine()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"machine_no",machine_no},
                {"machine_mode",machine_mode},
                {"serial_no",serial_no},
                {"purchase_date",purchase_date},
                {"purch_value",purch_value},
                {"supplier",supplier},
                {"owner",owner},
                {"ip_address",ip_address},
                {"img",img},
                {"usr",usr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_Machine_Save", objDIc);
            }
        }


    }
}

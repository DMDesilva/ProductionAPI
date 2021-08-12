using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class SparepartAssign
    {
        public Guid idx { get; set; }
        public Guid machineIdx { get; set; }
        public Guid assignIdx { get; set; }
        public Guid spart_serial_Idx { get; set; }
        public Guid color_idx { get; set; }
        public DateTime assigndate { get; set; }
        public int prnttyp { get; set; }
        public int spartsId { get; set; }
        public int unit_id { get; set; }
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public string sb_itm_nme { get; set; }
        public int stock_qty { get; set; }
        public int s_qty { get; set; }
        public List<serials> serials { get; set; }
        public string spartsname {get; set; }
        public string spartSerialNo {get; set; }
        public string pcount { get; set; }
        public Guid usr { get; set; }
        public int typ { get; set; }
        private string connection { get; set; }

        public SparepartAssign(string conn)
        {
            idx = new Guid();
            machineIdx = new Guid();
            assignIdx = new Guid();
            color_idx = new Guid();
            assigndate = DateTime.Now;
            spartsId = 0;
            prnttyp = 0;
            unit_id = 0;
            spartsname = "";
            spartSerialNo = "";
            pcount = "";
            usr = new Guid();

            itm_id = 0;
            sb_itm_id = 0;
            stock_qty = 0;
            sb_itm_nme = "";
            s_qty = 0;
            typ = 0;
            serials = new List<serials>(); 
            connection = conn;
        }
        public DataTable LoadSparepart()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [sb_itm_id] ,[sb_itm_nme] ,[itm_id],[stock_qty],([stock_qty]-[sqnty]) as sqnty , 0 as expanded  FROM [erpWarehouse].[dbo].[itm_lgr_transa_stock$sub] where (itm_id=6043 or  itm_id=6010) and [stock_qty] >0  order by itm_id");
            }
        }

        public DataTable LoadSpartAssignData()
        {
            {
                //var objDIc = new Dictionary<string, object>(); 
                return (new DbAccess(CommonData.ConStr())).FillDataTable("924139" +
                    "");
            }
        }

        public DataTable LoadSpartSerial()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[spart_serial_Idx],[itm_id],[sb_itm_id] ,[stock_qty],[s_qty] ,[serial_no] ,[sb_itm_nme],[isActive] FROM [dbo].[VIEW_Print_Sec_sparepart_Serial]");
            }
        }

        public DataTable LoadColor()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[id] ,[colors],[isActive] FROM [dbo].[_PrintSec_machine_colors] order by id");
            }
        }
       
        public DataTable LoadUnit()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id],[unit] FROM [dbo].[_PrintSec_Units]");
            }
        }
        public DataTable LoadAssignSparemachn()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT sp.[idx] ,sp.[id] ,sp.[machineIdx],prntmchn.[machine_mode],prntmchn.[serial_no],sp.[assigndate] ,sp.[spartsId] ,sp.[spartsname] ,sp.[spartSerialNo],sp.[pcount],sp.[isActive] FROM [dbo].[_PrintSec_machine_spareparts] sp INNER JOIN [dbo].[_PrintSec_machine] prntmchn on sp.[machineIdx]=prntmchn.Idx");
            }
        }
        public DataTable Save_Spareprts()
        {
            {
                var objDIc = new Dictionary<string, object> {
               // {"idx",idx},
                {"machineIdx",machineIdx},
                {"assigndate",assigndate},
                {"prnttyp",prnttyp},
                {"spartsId",spartsId},
                {"spartsname",spartsname},
                {"color_idx",color_idx},
                {"unit_id",unit_id},
                {"count",pcount},
                {"usr",usr}
              // {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_Machine_Spareparts", objDIc);
            }
        }
        public DataTable Save_SpareprtsSerial()
        {
            {
                var objDIc = new Dictionary<string, object> {
               
                {"itm_id",itm_id},
                {"sb_itm_id",sb_itm_id},
                {"sb_itm_nme",sb_itm_nme},
                {"stock_qty",stock_qty},
                {"s_qty",s_qty},
                {"serials",new serials("").InvItemListToDataTable(serials)},
                {"usr",usr}
              // {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_Machine_Spart_serial", objDIc);
            }
        }

        public DataTable Save_ApproveIssue()
        {
            {
                var objDIc = new Dictionary<string, object> {

                {"assignIdx",assignIdx},
                {"spart_serial_Idx",spart_serial_Idx},
                {"machineIdx",machineIdx},
                {"spartsId",spartsId},
                {"usr",usr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_sec_prt_app_issue", objDIc);
            }
        }

    }

    public class serials
    {
        public string serialNo { get; set; }

        public serials(string v)
        {
            serialNo = " ";
        }

        public DataTable InvItemListToDataTable(List<serials> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("serialNo", typeof(string));
            //dt1.Columns.Add("order_qty", typeof(int));
           // dt1.Columns.Add("plan_id", typeof(int));
            //dt1.Columns.Add("NewNic", typeof(string));


            foreach (var item in lst)
            {

                DataRow _serial = dt1.NewRow();
                _serial["serialNo"] = item.serialNo;

                dt1.Rows.Add(_serial);
            }
            return dt1;
        }
    }
}

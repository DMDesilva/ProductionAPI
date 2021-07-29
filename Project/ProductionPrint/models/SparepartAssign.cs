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
        public DateTime assigndate { get; set; }
        public string prnttyp { get; set; }
        public int spartsId { get; set; }
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public int stock_qty { get; set; }
        public int s_qty { get; set; }
        public List<serials> serials { get; set; }
        public string spartsname {get; set; }
        public string spartSerialNo {get; set; }
        public string pcount { get; set; }
        public Guid usr { get; set; }
        private string connection { get; set; }

        public SparepartAssign(string conn)
        {
            idx = new Guid();
            machineIdx = new Guid();
            assigndate = DateTime.Now;
            spartsId = 0;
            spartsname = "";
            spartSerialNo = "";
            pcount = "";
            usr = new Guid();

            itm_id = 0;
            sb_itm_id = 0;
            stock_qty = 0;
            s_qty = 0;
            serials = new List<serials>(); 
            connection = conn;
        }
        public DataTable LoadSparepart()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [sb_itm_id] ,[sb_itm_nme] ,[itm_id],[stock_qty],([stock_qty]-[sqnty]) as sqnty FROM [erpWarehouse].[dbo].[itm_lgr_transa_stock$sub] where (itm_id=6043 or  itm_id=6010) and [stock_qty] >0  order by itm_id");
            }
        }
        public DataTable LoadColor()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[id] ,[colors],[isActive] FROM [dbo].[_PrintSec_machine_colors] order by id");
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
                {"spartsId",spartsId},
                {"spartsname",spartsname},
                {"spartSerialNo",spartSerialNo},
                {"pcount",pcount},
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
                {"stock_qty",stock_qty},
                {"s_qty",s_qty},
                {"serials",new serials("").InvItemListToDataTable(serials)},
                {"usr",usr}
              // {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_Machine_Spart_serial", objDIc);
            }
        }
        //
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

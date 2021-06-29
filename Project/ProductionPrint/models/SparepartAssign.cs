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
            connection = conn;
        }
        public DataTable LoadSparepart()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [sb_itm_id] ,[sb_itm_nme] ,[itm_id],[stock_qty] FROM [erpWarehouse].[dbo].[itm_lgr_transa_stock$sub] where (itm_id=6043 or  itm_id=6010) and [stock_qty] >0  order by itm_id");
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
    }
}

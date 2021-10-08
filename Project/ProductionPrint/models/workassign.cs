using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class workassign
    {
        public int wid { get; set; }
        public string wrkername { get; set; }
        public string img { get; set; }
        public int pcs { get; set; }
        public Guid spr_idx { get; set; }
        public Guid usr { get; set; }
        public DateTime wrk_date { get; set; }
        public DateTime strtTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime sprTime { get; set; }
        public int typ { get; set; }
        public workassign()
        {
            wid = 0;
            pcs = 0;
            wrkername = "";
            img = "";
            spr_idx = new Guid();
            usr = new Guid();
            wrk_date = DateTime.Now;
            strtTime = DateTime.Now;
            endTime = DateTime.Now;
            sprTime = DateTime.Now;
            typ = 0;
        }
        public DataTable GetWrkhour()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id] ,[worker] ,[img] ,[wrk_date] ,[work_hr_strt],[work_hr_end] FROM [dbo].[VIEW_Screen_Print_wrk_hr_details] where [wrk_date]=CONVERT(DATE,GETDATE())");
        }

        public DataTable GetWrkproductDetais()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [spr_idx],[wid] ,[sprTime],[cal_imp],[count_hr],[pcs],[sty_id],[sty_nme],[so_id] ,[so_no],[fab_color] ,[impress],[ups],[sprdate],[worker],[wrk_date],[work_hr_strt],[work_hr_end] FROM [dbo].[VIEW_Spr_work_product_dt] where [wrk_date]=CONVERT(DATE,GETDATE())");
        }

        public DataTable SaveWrkAssign()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"wid",wid},
                   {"wrk_date",wrk_date},
                   {"strtTime",strtTime},
                   {"endTime",endTime}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_workhr", objDIc);
            }


        }
        public DataTable SaveNewWorker()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"wid",wid},
                   {"wrkername",wrkername},
                   {"img",img},
                   {"usr",usr},
                   {"typ",typ}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Screen_print_Wrker_add", objDIc);
            }


        }

        public DataTable SaveWrkprod_work()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"wid",wid},
                   {"spr_idx",spr_idx},
                   {"pcs",pcs},
                   {"sprTime",sprTime},
                   {"usr",usr}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Screen_Print_hr", objDIc);
            }


        }

    }
}

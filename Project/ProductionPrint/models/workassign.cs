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
        public DateTime strtTime { get; set; }
        public DateTime endTime { get; set; }

        public workassign()
        {
            wid = 0;
            strtTime = DateTime.Now;
            endTime = DateTime.Now;

        }
        public DataTable GetWrkhour()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id]  ,[worker]  ,[img] ,[wrk_date] ,[work_hr_strt],[work_hr_end] FROM [dbo].[VIEW_Screen_Print_wrk_hr_details] where [wrk_date]=CONVERT(DATE,GETDATE())");
        }
        public DataTable SaveWrkAssign()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"wid",wid},
                   {"strtTime",strtTime},
                   {"endTime",endTime}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_workhr", objDIc);
            }


        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class BrakeDown
    {
        public Guid idx { get; set; }
        public Guid machineIdx { get; set; }
        public DateTime brake_date { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string resone { get; set; }
        public Guid usr { get; set; }
        public int typ { get; set; }
        private string connection { get; set; }
        
        public BrakeDown(string conn)
        {
            idx = new Guid();
            machineIdx = new Guid();
            brake_date = DateTime.Now;
            start_time = DateTime.Now;
            end_time = DateTime.Now;
            resone = "";
            usr = new Guid(); 
            typ = 0;
            connection = conn;
        }

        public DataTable LoadBrakeDown()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  brk.[Idx] ,brk.[machineIdx],brk.[brake_date] ,brk.[start_time] ,brk.[end_time] ,brk.[resone] ,brk.[isActive],prntmchn.[machine_mode],prntmchn.[serial_no],Convert(time(7),GETDATE()) as [etime] FROM [dbo].[_PrintSec_machine_brakedwn] brk INNER JOIN [dbo].[_PrintSec_machine] prntmchn on brk.[machineIdx]=prntmchn.Idx");
            }
        }

        public DataTable Save_Brakedwn()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"machineIdx",machineIdx},
                {"brake_date",brake_date},
                {"start_time",start_time},
                {"end_time",end_time},
                {"resone",resone},
                {"usr",usr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Print_Machine_BrkDwn", objDIc);
            }
        }

    }
}

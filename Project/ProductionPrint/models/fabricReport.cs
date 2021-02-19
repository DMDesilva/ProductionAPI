using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class fabricReport
    {

        public DateTime tstDate { get; set; }
        public DateTime shipdate { get; set; }
        public string invNo { get; set; }
        public int lotnum { get; set; }
        public string fabCode { get; set; }
        public decimal testBefor_L { get; set; }
        public decimal testBefor_M { get; set; }
        public decimal testBefor_B { get; set; }
        public decimal testBeforW_L { get; set; }
        public decimal testBeforW_M { get; set; }
        public decimal testBeforW_B { get; set; }
        public decimal yard { get; set; }
        public string test { get; set; }
        public string rollnum { get; set; }
        public decimal afterSubL_L1 { get; set; }
        public decimal afterSubL_L2 { get; set; }
        public decimal afterSubL_L3 { get; set; }
        public decimal prasentage_L { get; set; }
        public decimal afterSubW_W1 { get; set; }
        public decimal afterSubW_W2 { get; set; }
        public decimal afterSubW_W3 { get; set; }
        public decimal prasentage_W { get; set; }
        public string cW { get; set; }
        public decimal testHeat { get; set; }
        public decimal testtime { get; set; }
        public decimal gsm { get; set; }
        public Boolean manualReport { get; set; }
        public Guid usr { get; set; }

        private string connection { get; set; }
        public fabricReport(string conn)
        {
            tstDate = DateTime.Now;
            shipdate = DateTime.Now;
            invNo = "";
            lotnum = 0;
            fabCode = "";
            testBefor_L = 0;
            testBefor_M = 0;
            testBefor_B = 0;
            testBeforW_L = 0;
            testBeforW_M = 0;
            testBeforW_B = 0;
            yard = 0;
            test = "";
            rollnum = "";
            afterSubL_L1 = 0;
            afterSubL_L2 = 0;
            afterSubL_L3 = 0;
            prasentage_L = 0;
            afterSubW_W1 = 0;
            afterSubW_W2 = 0;
            afterSubW_W3 = 0;
            prasentage_W = 0;
            cW = "";
            testHeat = 0;
            testtime = 0;
            gsm = 0;
            manualReport = true;
            usr = new Guid();
            connection = conn;
        }

         public DataTable LoadFabDatails()
        {
            return (new DbAccess(connection)).FillDataTable("SELECT [Idx] ,[Id],[tstDate]  ,[shipdate] ,[invNo] ,[lotnum],[fabCode]  ,[testBefor_L]  ,[testBefor_M] ,[testBefor_B],[testBeforW_L] ,[testBeforW_M],[testBeforW_B] ,[yard],[test] ,[rollnum] ,[afterSubL_L1]  ,[afterSubL_L2] ,[afterSubL_L3] ,[prasentage_L],[afterSubW_W1] ,[afterSubW_W2],[afterSubW_W3] ,[prasentage_W],[cW] ,[testHeat],[testtime],[gsm],[manualReport] ,[CreatedDate],[CreatedBy],[IsActive]  FROM [dbo].[fabric_Report_details] where CONVERT(date,[CreatedDate])=CONVERT(date,GetDate())");
        }
        public DataTable SearchDtByFabDatails( DateTime SearchDt)
        {
            return (new DbAccess(connection)).FillDataTable("SELECT [Idx] ,[Id],[tstDate]  ,[shipdate] ,[invNo] ,[lotnum],[fabCode]  ,[testBefor_L]  ,[testBefor_M] ,[testBefor_B],[testBeforW_L] ,[testBeforW_M],[testBeforW_B] ,[yard],[test] ,[rollnum] ,[afterSubL_L1]  ,[afterSubL_L2] ,[afterSubL_L3] ,[prasentage_L],[afterSubW_W1] ,[afterSubW_W2],[afterSubW_W3] ,[prasentage_W],[cW] ,[testHeat],[testtime],[gsm],[manualReport] ,[CreatedDate],[CreatedBy],[IsActive]  FROM [dbo].[fabric_Report_details] where CONVERT(date,[CreatedDate])=CONVERT(date,'" + SearchDt.ToString()+ "')");
        }

        public DataTable SaveFabricReport()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"tstDate",tstDate},
                    {"shipdate",shipdate},
                    {"invNo",invNo},
                    {"lotnum",lotnum},
                    {"fabCode",fabCode},
                    {"testBefor_L",testBefor_L},
                    {"testBefor_M",testBefor_M},
                    {"testBefor_B",testBefor_B},
                    {"testBeforW_L",testBeforW_L},
                    {"testBeforW_M",testBeforW_M},
                    {"testBeforW_B",testBeforW_B},
                    {"yard",yard},
                    {"test",test},
                    {"rollnum",rollnum},
                    {"afterSubL_L1",afterSubL_L1},
                    {"afterSubL_L2",afterSubL_L2},
                    {"afterSubL_L3",afterSubL_L3},
                    {"prasentage_L",prasentage_L},
                    {"afterSubW_W1",afterSubW_W1},
                    {"afterSubW_W2",afterSubW_W2},
                    {"afterSubW_W3",afterSubW_W3},
                    {"prasentage_W",prasentage_W},
                    {"cW",cW},
                    {"testHeat",testHeat},
                    {"testtime",testtime},
                    {"gsm",gsm},
                   {"manualReport",manualReport},
                    {"usr",usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("FabricReportSave", objDIc);
            }
        }

    }
}

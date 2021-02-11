
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class fileDINumData
    {
        public string fileNo  { get; set; }
        public string dINo  { get; set; }
        public string Descr { get; set; }
        public Guid fileIdx { get; set; }
        public Guid idx { get; set; }
        public int typ { get; set; }
        public Guid USR { get; set; }
        private string Connection { get; set; }

        public fileDINumData(string conn)
        {
            fileNo = "";
            dINo = "";
            Descr = "";
            typ = 0;
            fileIdx = new Guid();
            idx = new Guid();
            USR = new Guid();
            Connection = conn;
        }

        public DataTable LoadFileNo()
        {
           
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx],[Id],[fileNo] ,[description] FROM [ORACLE].[dbo].[Quality_MAST_Files]");
        }

       
        public DataTable LoadFileTransfer()
        {

            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx] ,[fileIdx],[fileNo] ,[di_no] FROM [dbo].[VIEW_Quality_file_manage]");
        }
        public DataTable MastFileSave()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"fileNo",fileNo},
                    { "Descr",Descr},
                    { "USR",USR}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("MAST_FileSave", objDIc);
            }
        }

        public DataTable SaveTransfile()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"Idx",idx},
                    {"fileIdx",fileIdx},
                    { "di_no",dINo},
                    { "Descr",Descr},
                    { "USR",USR},
                    { "typ",typ}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveTranFile", objDIc);
            }
        }
    }
}

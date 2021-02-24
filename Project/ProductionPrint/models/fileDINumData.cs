
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class fileDINumData
    {
        public string fileNo { get; set; }
        public string dINo { get; set; }
        public string Descr { get; set; }
        public Guid fileIdx { get; set; }
        public Guid idx { get; set; }
        public int typ { get; set; }
        public Guid USR { get; set; }
        public List<dinoArray> dinoArray { get; set; }
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
            dinoArray = new List<dinoArray>();

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

        public DataTable DeleteTransferFile(Guid Idx)
        {

           // return (new DbAccess(Connection)).FillDataTable("Delete from  [dbo].[Quality_trans_file_DI_No] where Idx ='"+ Idx.ToString()+ "'");
            {
                var objDIc = new Dictionary<string, object> {
                    {"Idx",Idx}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("DeleteIte", objDIc);
            }
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
                   // { "di_no",dINo},
                    { "di_no",new dinoArray().InvItemListToDataTable(dinoArray)},
                    { "USR",USR},
                    { "typ",typ}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveTranFile", objDIc); //
            }
        }
    }

    public class dinoArray
    {
        public int id { get; set; }
        public string DINO { get; set; }
        public string Descr { get; set; }

        public dinoArray()
        {
            id = 0;
            DINO = "";
            Descr = "";

        }

        public DataTable InvItemListToDataTable(List<dinoArray> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("DINO", typeof(string));
            dt1.Columns.Add("Descr", typeof(string));

            foreach (var item in lst)
            {

                DataRow _Desplan = dt1.NewRow();
                _Desplan["id"] = item.id;
                _Desplan["DINO"] = item.DINO;
                _Desplan["Descr"] = item.Descr;

                dt1.Rows.Add(_Desplan);
            }
            return dt1;
        }

    }
}

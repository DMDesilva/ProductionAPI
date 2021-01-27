using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DesignDepartment
    {
        public DateTime asignDate { get; set; }
        public int plant_Id { get; set; }
        public Guid designId { get; set; }
        public int sec_Id { get; set; }
        public Guid usr { get; set; }
        public List<assignData> assignData { get; set; }
        private string connection { get; set; }
     

        public DesignDepartment(string Conn)
        {
            asignDate = DateTime.Now;
            plant_Id = 0;
            designId = new Guid();
            sec_Id = 0;
            usr = new Guid();
            assignData = new List<assignData>();
            connection = Conn;
        }
        public DataSet LoadDataDesign()
        {
            {
                var objDIc = new Dictionary<string, object>();
               // return (new DbAccess(CommonData.ConStr())).FillDataTable("");
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("LoadWorkPendData", objDIc);
            }
        }
        public DataTable LoadDesigners()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [Idx],CONCAT([fname] ,' - ',[EpfNo]) as usrInfo FROM [dbo].[Auth_Users] where SectionId=350");
            }
        }
        public DataTable LoadDesignCount()
        {
            {
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [designIdx], COUNT([PO]) as cntOrds  ,Sum([qnty]) as sumQnty FROM [dbo].[VIEW_LoadCompletedPo] where IsActive=1 group by [designIdx]");
            }
        }
        public DataTable LoadMarkAsignData()
        {  //SELECT [Idx] ,[Id] ,[tpIdx]  ,[asignDate] ,[ods_id] ,[po_no] ,[designIdx]  ,[Username],[EpfNo] ,[IsActive] ,[remark],[sizeMark] ,[nameSheet] ,[noSize] ,[buyer_category],[buyer_id],[country_id] ,[country_name] ,[qnty],[sizes],[pattern_name],[fname],[product_no],[fabric],[comment] FROM [dbo].[VIEW_AsignForDesigner]
            {
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [Idx] ,[designIdx] ,[fname] ,[Username]  ,[asignDate] ,[IsActive]  ,[comment] ,[remark],[markSt] ,[nameSheet]  ,[noSize]  ,[prcSt]   ,[sizeMark] ,[PO] as po_no,[Product] as product_no,[Fabric] ,[OrderType] ,[Client],[Coodinator],[Distributor],[bySize],[sizes],[tp],[a3] ,[nonetp],[Pattern] as pattern_name,[qnty] ,[ods_id],[designCmnt] FROM [dbo].[VIEW_LoadCompletedPo]");
            }
        }
        public DataTable SaveDesign()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"asignDate",asignDate},
                    {"plant_Id",plant_Id},
                    {"sec_Id",sec_Id},
                    {"designId",designId},
                    {"usr",usr},
                    {"assignData",new assignData("").InvItemListToDataTable(assignData) }

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveDesignAsign", objDIc);
            }
        }
    }
    public class assignData
    {
        public Guid idx { get; set; }
        public int ods_id { get; set; }
        public string comment { get; set; }

        public assignData(string v)
        {
            idx = new Guid();
            ods_id = 0;
            comment = "";
        }
        public DataTable InvItemListToDataTable(List<assignData> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("ods_id", typeof(int));
            dt1.Columns.Add("comment", typeof(string));
            foreach (var item in lst)
            {

                DataRow _Desplan = dt1.NewRow();
                _Desplan["idx"] = item.idx;
                _Desplan["ods_id"] = item.ods_id;
                _Desplan["comment"] = item.comment;
              
                dt1.Rows.Add(_Desplan);
            }
            return dt1;
        }
    }
}

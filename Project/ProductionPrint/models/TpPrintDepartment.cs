using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class TpPrintDepartment
    {
        public DateTime tpDate { get; set; }
        public Guid usr { get; set; }
        public List<orderList> orderLists { get; set; }
        public List<data> data { get; set; }
       
        private string ConnectionString { get; set; }

        public TpPrintDepartment(string Conn)
        {
            tpDate = DateTime.Now;
            usr = new Guid();
            orderLists = new List<orderList>();
            data= new List<data>();
            ConnectionString =Conn;
        }
        
        public DataTable LoadTestPrintData()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [Idx] ,[ods_id] ,[po_no]  ,[tpDate] ,[design_id]  ,[product_no] ,[product_desc] ,[buyer_id] ,[buyer_category]  ,[pattern_id]  ,[pattern_name],[color_profile],[sizes] ,[country_id] ,[country_name] ,[fabric]  ,[markSt],[remark]  ,[sizeMark]  ,[nameSheet] ,[noSize] ,[createdDate]   ,[createdBy] ,[modifiedDate] ,[modifiedBy] ,[qnty] ,[tp] ,[a3] ,[nonetp] FROM [dbo].[VIEW_Test_PrintedMark] order by tpDate desc");
            }
        }
       
        public DataTable LoadordrList()
        {

            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("tpOrderList", objDIc);
            }
        }

        public DataTable SaveTestPrint()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"tpDate",tpDate},
                    {"usr",usr},
                    {"orderList",new orderList("").InvItemListToDataTable(orderLists) }

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveTesprintMark", objDIc);
            }
        }
        public DataTable SaveAust()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                   
                    {"orderList",new data("").InvItemListToDataTable(data) }

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("", objDIc);
            }
        }
    }
    public class orderList
    {
        public int ods_id { get; set; }
        public int order_qty { get; set; }
        public Boolean tp { get; set; }
        public Boolean a3 { get; set; }
        public Boolean nonetp { get; set; }
        public string coment { get; set; }
        public Boolean sizeMark   { get; set; }
        public Boolean nameSheet { get; set; }
        public string noSize { get; set; }
       
        public orderList(string v)
        {
            ods_id = 0;
            order_qty = 0;
            tp = false;
            a3 = false;
            nonetp = false;
            coment = "";
            sizeMark = false; 
            nameSheet = false;
            noSize = "";
        }
        public DataTable InvItemListToDataTable(List<orderList> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("ods_id", typeof(int));
            dt1.Columns.Add("order_qty", typeof(int));
            dt1.Columns.Add("tp", typeof(Boolean));
            dt1.Columns.Add("a3", typeof(Boolean));
            dt1.Columns.Add("nonetp", typeof(Boolean));
            dt1.Columns.Add("coment", typeof(string));
            dt1.Columns.Add("sizeMark", typeof(Boolean));
            dt1.Columns.Add("nameSheet", typeof(Boolean));
            dt1.Columns.Add("noSize", typeof(string));


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["ods_id"] = item.ods_id;
                _plan["order_qty"] = item.order_qty;
                _plan["tp"] = item.tp;
                _plan["a3"] = item.a3;
                _plan["nonetp"] = item.nonetp;
                _plan["coment"] = item.coment;
                _plan["sizeMark"] = item.sizeMark;
                _plan["nameSheet"] = item.nameSheet;
                _plan["noSize"] = item.noSize;
                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }

    public class data
    {
        //[JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        //[JsonProperty(PropertyName = "ShippingStatus")]
        public string ShippingStatus { get; set; }
       // [JsonProperty(PropertyName = "week")]
        public string week { get; set; }
        //[JsonProperty(PropertyName = "PO")]
        public string PO { get; set; }
        public data(string v)
        {
            id = 0;
            ShippingStatus = "";
            week ="";
            PO = "";
           
        }
        public DataTable InvItemListToDataTable(List<data> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("ShippingStatus", typeof(string));
            dt1.Columns.Add("week", typeof(string));
            dt1.Columns.Add("PO", typeof(string));
            //dt1.Columns.Add("nonetp", typeof(Boolean));
            //dt1.Columns.Add("coment", typeof(string));
            //dt1.Columns.Add("sizeMark", typeof(Boolean));
            //dt1.Columns.Add("nameSheet", typeof(Boolean));
            //dt1.Columns.Add("noSize", typeof(string));


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["id"] = item.id;
                _plan["shipSt"] = item.ShippingStatus;
                _plan["week"] = item.week;
                _plan["PO"] = item.PO;
                //_plan["a3"] = item.a3;
                //_plan["nonetp"] = item.nonetp;
                //_plan["coment"] = item.coment;
                //_plan["sizeMark"] = item.sizeMark;
                //_plan["nameSheet"] = item.nameSheet;
                //_plan["noSize"] = item.noSize;
                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }



}

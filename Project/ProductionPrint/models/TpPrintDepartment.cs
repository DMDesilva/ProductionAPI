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
                    {"AusDat",new data("").InvItemListToDataTable(data) }

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveAustaliaUpload", objDIc);
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
        
        public int id { get; set; }
        public string ShippingStatus { get; set; }
        public string week { get; set; }
        public string PO { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string BalanceQty { get; set; }
        public string BySize { get; set; }
        public string Pattern { get; set; }
        public string Fabric { get; set; }
        public string IsDyed { get; set; }
        public string OrderDate { get; set; }
        public string OrderType { get; set; }
        public string Client { get; set; }
        public string Coodinator { get; set; }
        public string Distributor { get; set; }
        public string Mode { get; set; }
        public string Sizes { get; set; }
        public string SizeCount { get; set; }
        public string LabelName { get; set; }
        public string LateOrder { get; set; }
        public string PhotoApproval { get; set; }
        public string IsRepeat { get; set; }
        public string NameNum { get; set; }
        public string Comment { get; set; }
        public string tp { get; set; }
        public string a3 { get; set; }
        public string nonTp { get; set; }
        public string nameSheet { get; set; }
        public Guid usr { get; set; }
        public data(string v)
        {
            id = 0;
            ShippingStatus = "";
            week ="";
            PO = "";
            Product = "";
            Quantity = "";
            BalanceQty = "";
            BySize = "";
            Pattern = "";
            Fabric = "";
            IsDyed = "";
            OrderDate = "";
            OrderType = "";
            Client = "";
            Coodinator = "";
            Distributor = "";
            Mode = "";
            Sizes = "";
            SizeCount = "";
            LabelName = "";
            LateOrder = "";
            PhotoApproval = "";
            IsRepeat = "";
            NameNum = "";
            Comment = "";
            tp = "";
            a3 = "";
            nonTp = "";
            nameSheet = "";
            usr = new Guid();
        }
        public DataTable InvItemListToDataTable(List<data> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("ShippingStatus", typeof(string));
            dt1.Columns.Add("week", typeof(string));
            dt1.Columns.Add("OrderDate", typeof(string));
            dt1.Columns.Add("PO", typeof(string));
            dt1.Columns.Add("Product", typeof(string));
            dt1.Columns.Add("Pattern", typeof(string));
            dt1.Columns.Add("Fabric", typeof(string));
            dt1.Columns.Add("Quantity", typeof(string));
            dt1.Columns.Add("BalanceQty", typeof(string));
            dt1.Columns.Add("OrderType", typeof(string));
            dt1.Columns.Add("Sizes", typeof(string));
            dt1.Columns.Add("BySize", typeof(string));
            dt1.Columns.Add("SizeCount", typeof(string));
            dt1.Columns.Add("IsDyed", typeof(string));
            dt1.Columns.Add("tp", typeof(string));
            dt1.Columns.Add("a3", typeof(string));
            dt1.Columns.Add("nonTp", typeof(string));
            dt1.Columns.Add("nameSheet", typeof(string));
            dt1.Columns.Add("Client", typeof(string));
            dt1.Columns.Add("Coodinator", typeof(string));
            dt1.Columns.Add("Distributor", typeof(string));
            dt1.Columns.Add("Mode", typeof(string));
            dt1.Columns.Add("LabelName", typeof(string));
            dt1.Columns.Add("LateOrder", typeof(string));
            dt1.Columns.Add("PhotoApproval", typeof(string));
            dt1.Columns.Add("IsRepeat", typeof(string));
            dt1.Columns.Add("NameNum", typeof(string));
            dt1.Columns.Add("Comment", typeof(string));
            dt1.Columns.Add("usr", typeof(Guid));

            foreach (var item in lst)
            {
                DataRow _plan = dt1.NewRow();
                _plan["id"] = item.id;
                _plan["ShippingStatus"] = item.ShippingStatus;
                _plan["week"] = item.week;
                _plan["OrderDate"] = item.OrderDate;
                _plan["PO"] = item.PO;
                _plan["Product"] = item.Product;
                _plan["Pattern"] = item.Pattern;
                _plan["Fabric"] = item.Fabric;
                _plan["Quantity"] =item.Quantity;
                _plan["BalanceQty"] = item.BalanceQty;
                _plan["OrderType"] = item.OrderType;
                _plan["Sizes"] = item.Sizes;
                _plan["BySize"] = item.BySize;
                 _plan["SizeCount"] =item.SizeCount;
                _plan["IsDyed"] = item.IsDyed;
                _plan["tp"] = item.tp;
                _plan["a3"] = item.a3;
                _plan["nonTp"] = item.nonTp;
                _plan["nameSheet"] = item.nameSheet;
                _plan["Client"] = item.Client;
                _plan["Coodinator"] = item.Coodinator;
                _plan["Distributor"] = item.Distributor;
                _plan["Mode"] = item.Mode;
                _plan["LabelName"] = item.LabelName;
                _plan["LateOrder"] = item.LateOrder;
                _plan["PhotoApproval"] = item.PhotoApproval;
                _plan["IsRepeat"] = item.IsRepeat;
                _plan["NameNum"] = item.NameNum;
                _plan["Comment"] = item.Comment;
                _plan["usr"] =item.usr;
                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }



}

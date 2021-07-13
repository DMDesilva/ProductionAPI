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

        
        public DataTable LoadAusTstPrintData()
        {
            {
                
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("LoadAusTstMark", objDIc);
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
        public string po { get; set; }
        public string product_no { get; set; }
        public string fabric { get; set; }
        public string pattern_name { get; set; }
        public string coordinator { get; set; }
        public string sizes { get; set; }
        public string customer_name { get; set; }
       
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
            po = "";
            product_no = "";
            fabric = "";
            pattern_name = "";
            coordinator = "";
            sizes = "";
            customer_name = "";
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
            dt1.Columns.Add("po", typeof(string));
            dt1.Columns.Add("product_no", typeof(string));
            dt1.Columns.Add("fabric", typeof(string));
            dt1.Columns.Add("pattern_name", typeof(string));
            dt1.Columns.Add("coordinator", typeof(string));
            dt1.Columns.Add("sizes", typeof(string));
            dt1.Columns.Add("customer_name", typeof(string));


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
                _plan["po"] = item.po;
                _plan["product_no"] = item.product_no;
                _plan["fabric"] = item.fabric;
                _plan["pattern_name"] = item.pattern_name;
                _plan["coordinator"] = item.coordinator;
                _plan["sizes"] = item.sizes;
                _plan["customer_name"] = item.customer_name;
                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }

    public class data
    {

        //  public int id { get; set; }
        public string po_no { get; set; }
        public string product { get; set; }
        public string order_qty { get; set; }
        public string pattern { get; set; }
        public string fabric { get; set; }
        //  public string IsDyed { get; set; }
        public string order_date { get; set; }
        public string del_date { get; set; }
        public string coordinator { get; set; }
        public string order_type { get; set; }
        public string distributer { get; set; }
        public string client_name { get; set; }
        public string sizes { get; set; }
        public string print_type { get; set; }
        public string ship_mode { get; set; }
        public string label_name { get; set; }
        public string order_sub_cat { get; set; }
        public string is_repeat { get; set; }
        public string by_size { get; set; }
        public string Comment { get; set; }
        public Guid usr { get; set; }
        
         //public string order_type { get; set; }
         //public string SizeCount { get; set; }
         //public string LateOrder { get; set; }
         //public string PhotoApproval { get; set; }
        //public string NameNum { get; set; }
        //public string tp { get; set; }
        //public string a3 { get; set; }
        //public string nonTp { get; set; }
        //public string nameSheet { get; set; }

        public data(string v)
        {
            //   id = 0;   
            po_no = "";
            product = "";
            order_qty = "";
            pattern = "";
            fabric = "";
            order_date= "";
            del_date = "";
            coordinator = "";
            order_type = "";
            distributer = "";
            client_name = "";
            sizes = "";
            print_type = "";
            ship_mode = "";
            label_name = "";
            order_sub_cat = "";
            is_repeat = "";
            by_size = "";
            Comment = "";

            //IsDyed = "";
            //SizeCount = "";
            //LateOrder = "";
            //NameNum = "";
            //tp = "";
            //a3 = "";
            //nonTp = "";
            //nameSheet = "";
            usr = new Guid();
        }
        public DataTable InvItemListToDataTable(List<data> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("po_no", typeof(string));
            dt1.Columns.Add("product", typeof(string));
            //dt1.Columns.Add("week", typeof(string));
            dt1.Columns.Add("order_qty", typeof(int));
            dt1.Columns.Add("pattern", typeof(string));
            dt1.Columns.Add("fabric", typeof(string));
            dt1.Columns.Add("order_date", typeof(string));
            dt1.Columns.Add("del_date", typeof(string));
            dt1.Columns.Add("coordinator", typeof(string));
            dt1.Columns.Add("distributer", typeof(string));
            dt1.Columns.Add("client_name", typeof(string));
            dt1.Columns.Add("sizes", typeof(string));
            dt1.Columns.Add("print_type", typeof(string));
            dt1.Columns.Add("ship_mode", typeof(string));
            dt1.Columns.Add("label_name", typeof(string));
            dt1.Columns.Add("by_size", typeof(string));
            dt1.Columns.Add("is_repeat", typeof(string));
            dt1.Columns.Add("Comment", typeof(string));
            //dt1.Columns.Add("nameSheet", typeof(string));
            //dt1.Columns.Add("Client", typeof(string));
            //dt1.Columns.Add("Coodinator", typeof(string));
            //dt1.Columns.Add("Distributor", typeof(string));
            //dt1.Columns.Add("Mode", typeof(string));
            //dt1.Columns.Add("LabelName", typeof(string));
            //dt1.Columns.Add("LateOrder", typeof(string));
            //dt1.Columns.Add("PhotoApproval", typeof(string));
            //dt1.Columns.Add("IsRepeat", typeof(string));
            //dt1.Columns.Add("NameNum", typeof(string));
            dt1.Columns.Add("usr", typeof(Guid));

            foreach (var item in lst)
            {
                DataRow _plan = dt1.NewRow();
               // _plan["id"] = item.id;
                _plan["po_no"] = item.po_no;
                _plan["product"] = item.product;
                _plan["order_qty"] = item.order_qty;
                _plan["pattern"] = item.pattern;
                _plan["fabric"] = item.fabric;
                _plan["order_date"] = item.order_date;
                _plan["del_date"] = item.del_date;
                _plan["coordinator"] =item.coordinator;
                _plan["distributer"] = item.distributer;
                _plan["client_name"] = item.client_name;
                _plan["sizes"] = item.sizes;
                _plan["print_type"] = item.print_type;
                _plan["ship_mode"] =item.ship_mode;
                _plan["label_name"] = item.label_name;
                _plan["by_size"] = item.by_size;
                _plan["is_repeat"] = item.is_repeat;
                _plan["Comment"] = item.Comment;
                //_plan["nameSheet"] = item.nameSheet;
                //_plan["Client"] = item.Client;
                //_plan["Coodinator"] = item.Coodinator;
                //_plan["Distributor"] = item.Distributor;
                //_plan["Mode"] = item.Mode;
                //_plan["LabelName"] = item.LabelName;
                //_plan["LateOrder"] = item.LateOrder;
                //_plan["PhotoApproval"] = item.PhotoApproval;
                //_plan["IsRepeat"] = item.IsRepeat;
                //_plan["NameNum"] = item.NameNum;
                //_plan["Comment"] = item.Comment;
                _plan["usr"] =item.usr;  
                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }



}

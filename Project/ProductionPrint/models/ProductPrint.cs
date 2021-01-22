using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class ProductPrint
    {
        public DateTime Trns_Date { get; set; }
        public int PlantId { get; set; }
        public int id { get; set; }
        public int PrintSecId { get; set; }
        public int isActive { get; set; }
        public int roomId { get; set; }
        public decimal size { get; set; }
        public int sub_sec_id { get; set; }
        public int OrdId { get; set; }
        public int Prod_Qnty { get; set; }
        public string Prod_Shift { get; set; }
        public string printComment { get; set; }
        public string ProdOption { get; set; }
        public string Psection { get; set; }
        public string PCName { get; set; }
        public string UserName { get; set; }
        public Guid CreatedBy { get; set; }
        private string ConnectionString { get; set; }

        public ProductPrint(string ConnStr)
        {
            ConnectionString = ConnStr;
            PCName= Environment.MachineName;
            CreatedBy = new Guid();
            id = 0;
            isActive = 0;
        }

        public DataTable LoadPlants()
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT plant_id, plant_name FROM common_opratn_master_plants WHERE (isdeleted = 0)  ORDER BY plant_name");

        }
        public DataTable PrintDash()
        {

            {
                var objDIc = new Dictionary<string, object>();
                //    {

                //       {"Id",id},
                //       { "IsActive",isActive}

                //};
                //  var dt = 
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Prod_Print_Dashboard", objDIc); 
            }

        }
        public DataTable LoadRooms()
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT  [Id],[room],[shift] FROM[dbo].[MAST_PrintProduction_Shift_Room] order by [Id]");

        }
        public DataTable LoadAssignMachine(int roomId)
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT [Id] ,[roomId] ,[room] ,[shift],[sub_sec_id] ,[sub_sec_name] FROM [dbo].[VIEW_MAST_Assign_Shift_Room] where [IsActive]=1 and [roomId]='" + roomId.ToString()+ "'");

        }
        public DataTable LoadMachine(int roomId)
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT [Id] ,[roomId] ,[room] ,[shift],[sub_sec_id] ,[sub_sec_name],[IsActive] FROM [dbo].[VIEW_MAST_Assign_Shift_Room] where  [roomId]='" + roomId.ToString() + "'");

        }
        public DataTable LoadUserGrp()
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT [Id] ,[group_name],[group_Id] FROM [dbo].[Auth_Users_Group]");
        }

        public DataTable LoadSizes()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [sizes_category_id],[size_names],[sort_ordr] FROM [dbo].[mercha_size_master_breakdown]");
            }
        }

        public DataTable LoadPrintOrderList()
        {

            {
                var objDIc = new Dictionary<string, object>();
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("GetPrintOrdList ", objDIc);
                return dt;
            }

        }
        public DataTable LoadPRintMachine()
        {

            {
                var objDIc = new Dictionary<string, object> {

                   {"plant_id",1}

            };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("PROD_LoadPrintMachine", objDIc);
                return dt;
            }

        }
        public DataTable DisableMach()
        {

            {
                var objDIc = new Dictionary<string, object> {

                   {"Id",id},
                   { "IsActive",isActive}

            };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Prod_Print_DisableMachine", objDIc);
                return dt;
            }

        }
        public DataTable LoadProdData()
        {
           // DateTime today= DateTime.Now.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Today;
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT *,CONCAT(po_no,' - ',product_no) as VL FROM system_view_mercha_podata where despathed_date='"+ today.ToString("yyyy-MM-dd") + "' order by po_no");

        }
        public DataTable LoadPrintOption()
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT [Id],[PrintOpName] FROM [dbo].[prod_print_option] ");

        }

        public DataTable SaerchPrdDt(string searchDt)
        {
          //  var dt = oid;
            //GetProdDetails

            {
                var objDIc = new Dictionary<string, object> {

                   {"Search",searchDt}

            };
              //  var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("GetProdDetails", objDIc);
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("GetProdDetails", objDIc);
            }

           

        }

        public DataTable LoadOrdersDt(DateTime FrmDt)
        {
            return (new DbAccess(ConnectionString)).FillDataTable("SELECT trans_id, trans_date, plant_name, section_name, sub_sec_name, po_no, product_no,pattern_name, production_qty, prod_shift FROM dgv_view_prdctn_poproductn WHERE(trans_date = CONVERT(DATETIME,'"+FrmDt.ToString()+"'))");
        }

        public DataTable SavePrintDt()
        {
                string pc_name = Environment.MachineName;
                UserName = Environment.UserName;
                string Usr = UserName.ToString() +"/"+ pc_name.ToString();
            {
                var objDIc = new Dictionary<string, object> {

                   {"Trns_Date",Trns_Date},
                   {"PlantId",PlantId},
                   {"PrintSecId",PrintSecId},
                   {"roomId",roomId},
                   {"OrdId",OrdId},
                   {"size",size},
                   {"Prod_Qnty",Prod_Qnty} ,
                   {"Prod_Shift",Prod_Shift},    
                   {"printComment",printComment},
                   {"ProdOption",ProdOption},
                   //{"Psection",Psection},
                   {"CreatedBy", CreatedBy}
            };
                
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SavePrintOrder", objDIc);
            }
        }


        public DataTable DeactivePrintProd(string trnsId)
        {
         // string ip=  Microsoft.AspNetCore.Http.HttpContext.Connection.RemoteIpAddress.ToString();

            {
                var objDIc = new Dictionary<string, object>
                {
                   {"transId",trnsId}
                 };
                return (new DbAccess(CommonData.ConStr()).LoadDatatableBySP("DeletePrintData", objDIc));
            }
        }
        public DataTable LoadPrintProdHisrty()
        {
            DateTime today = DateTime.Today;
            return (new DbAccess(CommonData.ConStr()).FillDataTable("Select * from [dbo].[VIEW_Product_PrintSection_History] where trans_date='" + today.ToString("yyyy-MM-dd") + "'  order by po_no "));
        }
        
        public DataTable LoadPrintData()
        {
            DateTime today = DateTime.Today;
            return (new DbAccess(CommonData.ConStr()).FillDataTable("SELECT [Idx],[Trns_Date] ,[PlantId] ,[plant_name] ,[PrintSecId] ,[sub_sec_name] ,[OrdId] ,[po_no] ,[Prod_Qnty],[size] ,[Prod_Shift] ,[PrintSection] ,[room]  ,[ProdOption] ,[PrintOpName] ,[printComment] FROM [dbo].[VIEW_Print_Production]"));
        }
        public DataTable PrintProdHisrtyFilter()
        {
            DateTime today = DateTime.Today;
            //[dbo].[VIEW_Product_PrintSection_History]
           // return (new DbAccess(CommonData.ConStr()).FillDataTable("SELECT [OrdId],[po_no] ,[order_qty],[Prod_Qnty],[Idx],CONVERT(date,[Trns_Date])as Trns_Date,[PlantId],[plant_name],[PrintSecId],[sub_sec_name],[Prod_Shift],[ProdOption],[PrintOpName],[printComment]FROM [dbo].[VIEW_Product_Print_Histry] where IsActive=1 and Trns_Date='" + today.ToString("yyyy-MM-dd") + "'  order by po_no "));
            return (new DbAccess(CommonData.ConStr()).FillDataTable("Select * from [dbo].[VIEW_Product_PrintSection_History] where trans_date='" + today.ToString("yyyy-MM-dd") + "'  order by po_no "));
        }

        public DataTable CompletedPrint()
        {
            DateTime today = DateTime.Today;
            //[dbo].[VIEW_Product_PrintSection_History]
            // return (new DbAccess(CommonData.ConStr()).FillDataTable("SELECT [OrdId],[po_no] ,[order_qty],[Prod_Qnty],[Idx],CONVERT(date,[Trns_Date])as Trns_Date,[PlantId],[plant_name],[PrintSecId],[sub_sec_name],[Prod_Shift],[ProdOption],[PrintOpName],[printComment]FROM [dbo].[VIEW_Product_Print_Histry] where IsActive=1 and Trns_Date='" + today.ToString("yyyy-MM-dd") + "'  order by po_no "));
            return (new DbAccess(CommonData.ConStr()).FillDataTable("Select * from [dbo].[VIEW_Product_PrintSection_History] where trans_date='" + today.ToString("yyyy-MM-dd") + "' and [section_id]=4  order by po_no  "));
        }

        public DataTable HeatPressPending()
        {
            DateTime today = DateTime.Today;
            //[dbo].[VIEW_Product_PrintSection_History]
            // return (new DbAccess(CommonData.ConStr()).FillDataTable("SELECT [OrdId],[po_no] ,[order_qty],[Prod_Qnty],[Idx],CONVERT(date,[Trns_Date])as Trns_Date,[PlantId],[plant_name],[PrintSecId],[sub_sec_name],[Prod_Shift],[ProdOption],[PrintOpName],[printComment]FROM [dbo].[VIEW_Product_Print_Histry] where IsActive=1 and Trns_Date='" + today.ToString("yyyy-MM-dd") + "'  order by po_no "));
            return (new DbAccess(CommonData.ConStr()).FillDataTable("Select * from [dbo].[VIEW_Heat_Press_Pending] where trans_date='" + today.ToString("yyyy-MM-dd") + "' and [section_id]=4  order by po_no  "));
        }

        public DataTable SearchHeat(DateTime fromdt, DateTime todate)
        {
            {
                var objDIc = new Dictionary<string, object>
                {

                   {"fromdt",fromdt},{"todate",todate},{"typ",1}
                 };
                return (new DbAccess(CommonData.ConStr()).LoadDatatableBySP("SearchHeat", objDIc));
            }
        }

        public DataTable LoadData()
        {
            return (new DbAccess(CommonData.ConStr()).FillDataTable("SELECT  [Idx],[BId],[BankName] FROM [dbo].[MAST_Bank]"));
        }
        //INSERT INTO [dbo].[tbl_UserGroup] ([Id],[UserGroup]) VALUES ()
        public DataTable InsertData(int Id, string Usr)
        {
            return (new DbAccess(CommonData.ConStr()).FillDataTable("INSERT INTO [dbo].[tbl_UserGroup] ([Id],[UserGroup]) VALUES ('" + Id.ToString() + "','" + Usr.ToString() + "')"));
        }
    }
}

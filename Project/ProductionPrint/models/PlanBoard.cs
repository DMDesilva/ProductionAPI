﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class PlanBoard
    {
        public Guid Idx { get; set; }
        public Guid PIdx { get; set; }
        public int plan_id { get; set; }
        public int plant_Id { get; set; }
        public int sec_Id { get; set; }
        public int sub_sec_Id { get; set; }
        public int ods_id { get; set; }
        public int qnty { get; set; }
        public DateTime plan_Date { get; set; }
        public DateTime sewPln_date { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid Usr { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public List <planItem> planItem { get; set; }
        public DateTime designPln_date { get; set; }
        public DateTime printingPln_date { get; set; }
        public DateTime hPrintingPln_date { get; set; }
        public DateTime devPln_date { get; set; }
        public DateTime scPritingPln_date { get; set; }
        public DateTime reCutPln_date { get; set; }
        public DateTime cutPln_date { get; set; }
        public DateTime diCutPln_date { get; set; }
        public DateTime packingPln_date { get; set; }
        public DateTime embPln_date { get; set; }
        public DateTime tp_date { get; set; }
        public DateTime tc_date { get; set; }
        public DateTime num_date { get; set; }
        public DateTime inp_date { get; set; }
        public int typ { get; set; }
        private string connection { get; set; }

        public PlanBoard(string conn)
        {
            connection = conn;
            Idx = new Guid();
            PIdx = new Guid();
            plant_Id = 0;
            ods_id = 0;
            qnty = 0;
            plan_id = 0;
            sec_Id = 0;
            sub_sec_Id = 0;
         
            plan_Date = DateTime.Now;
            planItem = new List<planItem>();
            CreatedDate = DateTime.Now;
            Usr = new Guid();
            ModifiedDate = DateTime.Now;

            designPln_date = new DateTime(0001,1, 1); 
            printingPln_date = new DateTime(0001, 1, 1);
            hPrintingPln_date = new DateTime(0001, 1, 1);
            devPln_date = new DateTime(0001, 1, 1);
            scPritingPln_date = new DateTime(0001, 1, 1);
            reCutPln_date = new DateTime(0001, 1, 1);
            cutPln_date = new DateTime(0001, 1, 1);
            diCutPln_date = DateTime.Now;
            packingPln_date = new DateTime(0001, 1, 1);
            embPln_date = new DateTime(0001, 1, 1);
            tp_date = new DateTime(0001, 1, 1);
            tc_date = new DateTime(0001, 1, 1);
            num_date = new DateTime(0001, 1, 1);
            inp_date = new DateTime(0001, 1, 1);
            // ModifiedBy = new Guid();
            typ =0;
        }

        public DataTable LoadSewingPlan(DateTime frmDt)
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"frmDt",frmDt},
                  // {"toDt",toDt}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("[dbo].[SewingPlan_Load]", objDIc);
            }
        }
        public DataTable PlanProdData(int st)
        {
           {
                var objDIc = new Dictionary<string, object> {
                    {"St",st }
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Plan_Orders", objDIc);
            }

      
        }
        public DataTable LoadSectionPlanData(int sec_Id)
        {
            {
                var objDIc = new Dictionary<string, object> {

                ///{"frmDt",frmDt},
                   {"sec_Id",sec_Id}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Load_SectionWisePaln", objDIc);
            }
        }
        public DataTable LoadSectionforPlan()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SectionforPlan", objDIc);
            }
        }
        public DataTable LoadPlanData()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("LoadPlanOrder", objDIc);
            }
        }
        
        public DataTable LoadAllSectionPlanData(string frmDt)
        {
            {
                //var objDIc = new Dictionary<string, object>(); SELECT [subli_cat_id],[sublimation_category]FROM [dbo].[mercha_prodct_master_sublimacat]
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [Idx],[plan_date],[plant_Id] ,[plant_name] ,[sec_Id],[section_name] ,[St],[ord_Id] ,[po_no] ,[plan_qnty],[plan_id],[sewPln_date],[design_id] ,[subli_cat_id],[sublimation_category],0 as subcat FROM [dbo].[VIEW_Plan_SectionWise] where [plan_date]='" + frmDt.ToString()+ "'");
            }
        }

        public DataTable LoadSublimct()
        {
            {
                //var objDIc = new Dictionary<string, object>(); 
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [subli_cat_id],[sublimation_category]FROM [dbo].[mercha_prodct_master_sublimacat]");
            }
        }

        public DataSet PlanDashboard(string FrmDat, string toDate)
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"from",FrmDat},
                    {"ToDate",toDate}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("Sewing_PlanDashboard", objDIc);
            }
        }
        public DataTable PlanSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"plant_Id",plant_Id},
                    {"sec_Id",sec_Id},
                    {"sub_sec_Id",sub_sec_Id},
                    {"plan_Date",plan_Date},
                    {"sewPln_date",sewPln_date},
                    { "Usr",Usr},
                    {"planItem",new planItem("").InvItemListToDataTable(planItem) }
                    
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Sec_wise_Plan_save", objDIc);
            }
        } 
        public DataTable PlanChangeSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"plant_Id",plant_Id},
                    {"sec_Id",sec_Id},
                    {"sub_sec_Id",sub_sec_Id},
                    {"PIdx",PIdx},
                    {"plan_id",plan_id},
                    {"plan_Date",plan_Date},
                    {"ord_Id",ods_id},
                    {"qnty",qnty},
                    {"sewPln_date",sewPln_date},
                    { "Usr",Usr},
                    { "typ",typ}
                    

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Section_Change_PlanDate", objDIc);
            }
        }
        public DataTable Date_SecPlanSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"designPln_date",designPln_date},
                    {"printingPln_date",printingPln_date},
                    {"hPrintingPln_date",hPrintingPln_date},
                    {"devPln_date",devPln_date},
                  //  {"scPritingPln_date",scPritingPln_date},
                    {"reCutPln_date",reCutPln_date},
                //    {"cutPln_date",cutPln_date},
                  //  {"diCutPln_date",diCutPln_date},
                    {"packingPln_date",packingPln_date},
                 //   {"embPln_date",embPln_date},
                    {"sewPln_date",sewPln_date},
                    {"tp_date",tp_date},
                    {"tc_date",tc_date},
                    {"num_date",num_date},
                    {"inp_date",inp_date},
                    {"planItem",new planItem("").InvItemListToDataTable(planItem)},
                    { "Usr",Usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_date_Sec_Plan", objDIc);
            }
        }
    }

    public class planItem
    {
        
        public int plan_id { get; set; }
        public int ods_id { get; set; }
        public int order_qty { get; set; }
       // public string Nic { get; set; }
       // public string NewNic { get; set; }
        

        public planItem(string v)
        {
            plan_id = 0;
            ods_id = 0;
            order_qty = 0;
        }
        public DataTable InvItemListToDataTable(List<planItem> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("ods_id", typeof(int));
            dt1.Columns.Add("order_qty", typeof(int));
            dt1.Columns.Add("plan_id", typeof(int));
            //dt1.Columns.Add("NewNic", typeof(string));


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["ods_id"] = item.ods_id;
                _plan["order_qty"] = item.order_qty;
                _plan["plan_id"] = item.plan_id;
                // _plan["Nic"] = item.Nic;
                //  _plan["NewNic"] = item.NewNic;

                dt1.Rows.Add(_plan);
            }
            return dt1;
        }

    }
}

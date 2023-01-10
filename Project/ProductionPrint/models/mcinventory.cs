using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class mcinventory
    {
        public Guid idx { get; set; }
        public int dep_id { get; set; }
        public int r_id { get; set; }
        public int m_id { get; set; }
        public DateTime job_date { get; set; }
        public DateTime job_time { get; set; }
        public string job_no { get; set; }
        public string job_des { get; set; }
        public string  mc_key { get; set; }
        public bool lvl_1 { get; set; }
        public bool lvl_2 { get; set; }
        public bool lvl_3 { get; set; }
        public bool lvl_4 { get; set; }
        public int lvl{ get; set; }
        public DateTime req_date { get; set; }
        public Guid usr { get; set; }
        public int jb_typ { get; set; }
        public List<sprts> sprts { get; set; }
        public List<mcnic> mcnic { get; set; }
        //----------------------------------------
        public string r_typs { get; set; }
        public string m_name { get; set; }
        public int mst_cat { get; set; }
        public int sb_itm_id { get; set; }
        public int emp { get; set; }
        public string job_img { get; set; }
        public string jobauth { get; set; }
        public string info { get; set; }
        public DateTime plndt { get; set; }
        public DateTime plntime { get; set; }
        private string conn { get; set; }
        public mcinventory(string con)
        {
            idx = new Guid();
            dep_id = 0;
            r_id = 0;
            m_id = 0;
            job_no = "";
            job_img = "";
            job_date = DateTime.Now;
            job_time = DateTime.Now;
            job_des = "";
            mc_key = "";
            info = "";
            lvl_1 = false;
            lvl_2 = false;
            lvl_3 = false;
            lvl_4 = false;
            lvl = 0;
            req_date = DateTime.Now;
            plndt = DateTime.Now;
            plntime = DateTime.Now;
            usr = new Guid();
            r_typs = "";
            m_name = "";
            jobauth = "";
            mst_cat = 0;
            emp = 0;
            conn = con;
           
        }

        public DataTable GetDepartments()
        {
            return (new DbAccess(conn)).FillDataTable("SELECT [dept_id],[dept_nme],[dept_st] FROM [sysTower].[dbo].[user_master_dep]");
        }
        public DataTable GetSwRepireDt()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT[idx],[rp_no],[mc_key],[dept_nme],[r_typs] ,[m_name] ,[job_des]FROM [dbo].[VIEW_Mcinventory_repair] order by [rp_no]");
        }
        public DataTable GetSwRepireDetails()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[hidx],[itm_id],[sup_item_code],[sup_item_nme]  ,[sb_itm_id] ,[sb_itm_nme] ,[stock_qty] ,[re_qnty] ,[unit_name]FROM [dbo].[VIEW_Mcinventory_repair_details]");
        }
        public DataTable GetRepairtyps()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT[id],[r_typs]FROM[dbo].[_Mcinventory_repair_typs]");
        }
        public DataTable Getmachanic()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT[id] ,[m_name] FROM[dbo].[_Mcinventory_mechanics]");
        }

        public DataTable GetmcjobReq()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT[idx] ,[job_no],[dep_id] ,[dept_nme] ,[mc_key],[job_date] ," +
                "convert(varchar,(Convert(time(0),[job_time])),100)as[job_time] ,[job_des]  ,[lvl],st,[jb_typ],[job_img]," +
                "convert(varchar,(Convert(time(0),[rpaire_assign_time])),100)as [rpaire_assign_time],convert(varchar,(Convert(time(0),[rpaire_time])),100)as [rpaire_time] " +
                " ,[recreat_no] ,[recreate_info] ,Convert(time(0),[reassign_end_time]) as reassign_end_time,Convert(time(0),[recreatedate]) as recreatetime " +
                ",[rejected_info] ,Convert(date,[rejecteddate]) as reg_date , " +
                "convert(varchar, (Convert(time(0),[rejecteddate])), 100) as rej_time,[rpaire_date],[rpaire_assign_date],[jobAhuth]" +
                ",Convert(date,[plndt])as plndt,convert(varchar, (Convert(time(0),[plntime])), 100)  as plntime ,[r_id] FROM [dbo].[VIEW_Mcinventory_repair_job_req] where [isActive]=1 order by [job_no] desc");
        }

        public DataTable GetMachine()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [mc_key],[mccat_id] ," +
                "[mccat_name]  ,[mctyp] ,[mc_desc] ,[brnd] ,[mc_modl] " +
                ",[mc_seral] ,[manfac_yr] ,[pwr]  ,[amp],[phase] " +
                " ,[voltage] ,[hz_val] ,[loctn_name],CONCAT([mc_key],' - ',[mc_desc]) as mchin,[typ],[rmrks]" +
                "FROM [sysMcInventory].[dbo].[load_view_mcinv] order by mccat_id");
        }
        public DataTable GetAllSparepart()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT sup_item_code, sup_item_nme,sb_itm_nme, stock_qty," +
                " cat_name, unit_name,moq,lead_tme, re_ordr FROM [erpWarehouse].[dbo].[report_view_stock]  WHERE  cat_id in (SELECT  [cat_id] " +
                "FROM [erpWarehouse].[dbo].[itm_lgr_master_catgry]where [relate]=7 or [p_relate]=7) and stock_qty > 0");
        }
        public DataTable GetAllpartsMainitm()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT DISTINCT [itm_id] , CONCAT( [sup_item_code],' - ', [sup_item_nme]) as itm,[sup_item_code] ,[sup_item_nme]FROM [erpWarehouse].[dbo].[VIEW_maintance_issues]");
        }
        public DataTable GetAllparts()
      {
         return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [itm_id] ,[sup_item_code],[sup_item_nme],[cat_name],[sb_itm_id],[sb_itm_nme] " +
             ",[stock_qty],[unit_name],[iss_qty] FROM [erpWarehouse].[dbo].[VIEW_maintance_issues]");
       }
        public DataTable GetUsedSpartDetails()
      {
         return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [idx]  ,[jb_req_idx] ,[itm_id]  ,[sb_itm_id]   ,[sup_item_code]  ,[sup_item_nme] ,[re_qnty] as iss_qty,[sb_itm_nme] ,[unit_name]  FROM [dbo].[VIEW_Mcinventory_used_spareprts_details] where isActive=1");
       }
        public DataTable GetAssinedJob()
          {
         return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx] ,[job_no] ,[dep_id] ,[dept_nme],[mc_key],[job_date]," +
             "[job_time],[job_des],[lvl],[st],[jb_typ],[job_img] ,[r_id],[r_typs] ," +
                "[rpaire_assign_time],[rpaire_time],[recreat_no] ,[recreate_info] ,Convert(time(0),[reassign_end_time]) as reassign_end_time" +
                ",Convert(time(0),[recreatedate]) as recreatetime ,jobAhuth FROM [dbo].[View_Mcinventory_assigned_jobs] where [isActive]=1 order by [job_no] desc");
          }
        public DataTable GetAssinedMach()
          {
         return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[jb_req_idx] ,[job_no],[m_name] FROM [ORACLE].[dbo].[VIEW_Mcinventory_assigned_machnic]");
          }
        
        public DataTable Getspareparts()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("view_sw_spareparts", objDIc);
            }
        }
        public DataSet GetDetailsreq()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_getAssign_jobreq ", objDIc);
            }
        }
        public DataTable updateSycn()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_update_complete_sycn", objDIc);
            }
        }
        public DataTable MasterSave()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"r_typs",r_typs},
                    {"m_name",m_name},
                    {"mst_cat",mst_cat},
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_mcinvetory_masterSave", objDIc);
            }
        }
        public DataTable GetblncStock(int itm_id, int sb_itm)
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"itm_id",itm_id},
                    {"sb_itm",sb_itm}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Maintance_stock", objDIc);
            }
        }
        //public DataTable JobpartRemove()
        //{
        //    {
        //        var objDIc = new Dictionary<string, object> {
        //            {"idx",idx},
        //            {"sb_itm_id",sb_itm_id} 
        //        };

        //        return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("", objDIc);
        //    }
        //}
        public DataTable GenaralJobSave()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"idx",idx},
                    {"dep_id",dep_id},
                    {"job_date",job_date},
                    {"job_time",job_time},
                    {"job_des",job_des},
                    {"mc_key",mc_key},
                    {"lvl",lvl},
                    {"jb_typ",jb_typ},
                    {"job_img",job_img},
                    {"usr",usr},
                    {"jobauth",jobauth}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Mcinventory_job_request", objDIc);
            }
        }
        public DataTable SWRepairSave()
         {
            {
                var objDIc = new Dictionary<string, object> {
                    {"dep_id",dep_id},
                    {"r_id",r_id},
                    {"m_id",m_id},
                    {"mc_key",mc_key},
                    {"job_des",job_des},
                    {"sprts",new sprts().InvItemListToDataTable(sprts) },
                 //   {"mst_cat",mst_cat},
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_mcinvetory_swrepair_save", objDIc);
            }
        }

        public DataTable jobassignSave()
         {
            {
                var objDIc = new Dictionary<string, object> {
                    {"idx",idx},
                    {"job_no",job_no},
                    {"r_id",r_id},
                    {"sprts",new sprts().InvItemListToDataTable(sprts)},
                    {"mcnic",new mcnic().InvItemListToDataTable(mcnic)},
                    {"plndt",plndt},
                    {"plntime",plntime},
                    {"typ",1},
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("jobassign", objDIc);
            }
        }
        public DataTable jobupdate()
         {
            {
                var objDIc = new Dictionary<string, object> {
                    {"idx",idx},
                    {"job_no",job_no},
                    {"r_id",r_id},
                    {"sprts",new sprts().InvItemListToDataTable(sprts)},
                    {"mcnic",new mcnic().InvItemListToDataTable(mcnic)},
                    {"plndt",plndt},
                    {"plntime",plntime},
                    {"typ",2},
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("jobassign", objDIc);
            }
        }
        public DataTable JobEnd()
         {
            {
                var objDIc = new Dictionary<string, object> {
                  
                    {"job_no",job_no}, 
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_jobend", objDIc);
            }
        }
        public DataTable JobReject()
         {
            {
                var objDIc = new Dictionary<string, object> {
                  
                    {"idx",idx},
                    {"job_no",job_no},
                    {"info",info},
                    {"emp",emp}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_job_reject", objDIc);
            }
        }
        public DataTable JobCreate()
         {
            {
                var objDIc = new Dictionary<string, object> {
                  
                    {"idx",idx}, 
                    {"job_no",job_no}, 
                    {"info",info}, 
                    {"usr",usr}
                };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_jobrecreate", objDIc);
            }
        }
    }
    public class sprts
    {
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public decimal re_qnty { get; set; }
        public string unit_name { get; set; }

        public sprts()
        {
            itm_id = 0;
            sb_itm_id = 0;
            re_qnty =0;
            unit_name = "";        
        }

        public DataTable InvItemListToDataTable(List<sprts> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_id", typeof(int));
            dt1.Columns.Add("re_qnty", typeof(decimal));
            dt1.Columns.Add("unit_name", typeof(string));
           
            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["itm_id"] = item.itm_id;
                _acc["sb_itm_id"] = item.sb_itm_id;
                _acc["re_qnty"] = item.re_qnty;
                _acc["unit_name"] = item.unit_name;

                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
    public class mcnic
    {
        public int id { get; set; }
        public string m_name { get; set; }
      
        public mcnic()
        {
            id = 0;
            m_name = "";
        }

        public DataTable InvItemListToDataTable(List<mcnic> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("m_name", typeof(string));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["id"] = item.id;
                _acc["m_name"] = item.m_name;

                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }

}

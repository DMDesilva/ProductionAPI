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
        //----------------------------------------
        public string r_typs { get; set; }
        public string m_name { get; set; }
        public int mst_cat { get; set; }

        private string conn { get; set; }

        public mcinventory(string conn)
        {
            idx = new Guid();
            dep_id = 0;
            r_id = 0;
            m_id = 0;
            job_date = DateTime.Now;
            job_time = DateTime.Now;
            job_des = "";
            mc_key = "";
            lvl_1 = false;
            lvl_2 = false;
            lvl_3 = false;
            lvl_4 = false;
            lvl = 0;
            req_date = DateTime.Now;
            usr = new Guid();
            r_typs = "";
            m_name = "";
            mst_cat = 0;
            conn = conn;

        }

        public DataTable GetDepartments()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [dept_id],[dept_nme],[dept_st] FROM [sysTower].[dbo].[user_master_dep]");
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
                "[job_time] ,[job_des]  ,[lvl],st FROM [dbo].[VIEW_Mcinventory_repair_job_req] order by [job_no] desc");
        }

        public DataTable GetMachine()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [mc_key],[mccat_id] ," +
                "[mccat_name]  ,[mctyp] ,[mc_desc] ,[brnd] ,[mc_modl] " +
                ",[mc_seral] ,[manfac_yr] ,[pwr]  ,[amp],[phase] " +
                " ,[voltage] ,[hz_val] ,[loctn_name],CONCAT([mc_key],' - ',[mc_desc]) as mchin,[typ] " +
                "FROM [sysMcInventory].[dbo].[load_view_mcinv] order by mccat_id");
        }
        
        public DataTable Getspareparts()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("view_sw_spareparts", objDIc);
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
                    {"usr",usr}
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
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DamagePanel
    {
        public Guid idx{ get; set; }
        public int depid { get; set; }
        public int odsid { get; set; }
        public int st { get; set; }
        public string size { get; set; }
        public int qnty { get; set; }
        public string dmgereason { get; set; }
        public string imgArr1 { get; set; }
        public string imgArr2 { get; set; }
        public Guid usr { get; set; }

        private string conn { get; set; }
        
        public DamagePanel(string connection)
        {
            idx = new Guid();
            depid = 0;
            odsid = 0;
            size = "";
            qnty =0;
            dmgereason = "";
            imgArr1 = "";
            imgArr2 = "";
            usr = new Guid();
            st = 0;
            conn = connection;
        }
        public DataTable LoadSizes()
        {
            return (new DbAccess(conn)).FillDataTable("SELECT [sizes_category_id],[size_names] FROM [dbo].[mercha_size_master_breakdown]");
        }
        public DataTable LoaddamageDetails()
        {
            return (new DbAccess(conn)).FillDataTable("SELECT [Idx] ,[ods_id],[po_no],[depId] ,[section_name] ,[size] ,[dqnty],[reson] ,[damagedate] ,[fabric] ,[img1],[img2] ,[qr_id],[IsActive] ,[st] FROM [ORACLE].[dbo].[View_Damage_Panel_Details]");
        }
        public DataTable DamagePanelSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"depid",depid},
                    {"odsid",odsid},
                    {"size",size},
                    {"qnty",qnty},
                    {"dmgereason",dmgereason},
                    {"imgArr1",imgArr1},
                    {"imgArr2",imgArr2},
                    {"usr",usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("DamagePanelSave", objDIc);
            }
        }
        public DataTable ApproveDamage()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"idx",idx},
                    {"st",st},
                    {"usr",usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("ApproveDamage", objDIc);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class PatternCreate
    {
        public Guid buyer_id { get; set; } 
        public Guid pattern_id { get; set; } 
        public string pattern_name { get; set; } 
        public string pattern_des { get; set; } 
        public string origin_ref { get; set; } 
        public string corr_pattern { get; set; } 
        public string consum { get; set; } 
        public string keyword { get; set; } 
        public string specil_att { get; set; } 
        public string fact_des { get; set; } 
        public int print_typ_id { get; set; } 
        public string prod_line { get; set; } 
        public string note { get; set; } 
        public string fac_note { get; set; } 
        public string mark_desc { get; set; } 
        public string conv_fact { get; set; } 
        public double smv { get; set; } 
        public int suplier_id { get; set; } 
        public bool isCore { get; set; } 
        public bool isActive { get; set; }

        public Guid request_by { get; set; }
        public string firm_Qty { get; set; }
        public string potential_Qty { get; set; }
        public string customer { get; set; }

        public Guid item_id { get; set; }
        public Guid item_sub_id { get; set; }
        public Guid pttn_other_idx { get; set; }
        public string item_desc { get; set; }

        public int id{ get; set; }
        public string p_type { get; set; }
        public string size { get; set; }
        public int agegroup { get; set; }
        public int age_group { get; set; }
        public string catergory { get; set; }
        public int gender { get; set; }
        public int size_set_id { get; set; }
        public int unit_id { get; set; }
        public decimal machine_smv { get; set; }
        public decimal cost_smv { get; set; }
        public decimal prod_smv { get; set; }

        public decimal sweing_smv { get; set; }
        public decimal pck_smv { get; set; }
        public decimal ws_smv { get; set; }

        public int cat_id { get; set; }
        public string description { get; set; }

        public string imgs { get; set; }
        public string mesur_imgs { get; set; }
        public string garmnt_nt { get; set; }
        public string spec_mesur_imgs { get; set; }

        public int typ { get; set; } 
        public Guid usr { get; set; }
        public List<accesseries> accesseries { get; set; }
        public List<fabricCon> fabricCon { get; set; }
        public List<pttnEmb> pttnEmb { get; set; }
        private string connection { get; set; }

        public PatternCreate( string conn)
        {
            buyer_id = new Guid();
            pattern_id = new Guid();
            pttn_other_idx = new Guid();
            pattern_name = "";
            pattern_des = "";
            origin_ref = "";
            corr_pattern = "";
            consum = "";
            keyword = "";
            specil_att = "";
            fact_des = "";
            mark_desc = "";
            conv_fact = "";
            smv = 0;
            print_typ_id = 0;
            suplier_id = 0;
            isCore = false;
            isActive = true;

            request_by = new Guid();
            firm_Qty = "";
            potential_Qty = "";
            customer = "";

            item_id = new Guid();
            item_sub_id = new Guid();
            item_desc = "";

            p_type = "";
            size = "";
            agegroup  = 0;
            age_group = 0;
            catergory = "";
            gender = 0;
            size_set_id = 0;
            unit_id = 0;
            machine_smv = 0;
            cost_smv = 0;
            prod_smv = 0;

            sweing_smv=0;
            pck_smv = 0;
            ws_smv = 0;

            cat_id = 0;
            description = "";

            imgs = "";
            mesur_imgs = "";
            garmnt_nt = "";
            spec_mesur_imgs = "";
            typ = 0;
            note = "";
            fac_note= "";
            usr = new Guid();
            accesseries = new List<accesseries>();
            fabricCon = new List<fabricCon>();
            pttnEmb = new List<pttnEmb>();
            connection = conn;
        }
        
        public DataTable GetItms()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [itm_id],[sup_item_code] ,[sup_item_nme],[sb_itm_id],[sb_itm_nme],[cat_id],[cat_name] ,[stock_qty] ,[unit_id],[unit_name],0 as cs ,0 as consm ,CONCAT([sup_item_nme],' - ',[sb_itm_nme],' - ',[cat_name]) as itms , CONCAT([sup_item_code],' - ', [sup_item_nme],' - ',[sb_itm_nme]) AS fabitm ,0 as consum FROM [erpWarehouse].[dbo].[VIEW_Item_details] where stock_qty >0");
        }
        public DataSet Load_Mast_data()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("Merchandiser_Loadt_Mast", objDIc);
            }
        }
        
        public DataSet Load_PatternDt_data()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("Get_Pattern_dt", objDIc);
            }
        }
        public DataTable Save_Master()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"p_type",p_type},
                {"size",size},
                {"agegroup",agegroup},
                {"catergory",catergory},
                {"gender",gender},
                {"description",description},
                {"typ",typ},
                {"usr",usr}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Merchandiser_pttninfo_MAST_Save", objDIc);
            }
        }

        public DataTable Save_Pattern_Create()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"buyer_id",buyer_id},
                {"pattern_name",pattern_name},
                {"gender",gender},
                {"agegroup",age_group},
                {"item_ids",item_id},
                {"pttn_other_idx",pttn_other_idx},
                {"size_set_id",size_set_id},
                {"keyword",keyword},
                {"pattern_des",pattern_des},
                {"origin_ref",origin_ref},
                {"corr_pattern",corr_pattern},    
                {"fact_des",fact_des},
                {"note",note},
                {"isCore",isCore},
                {"isActive",isActive},

                {"request_by",request_by},
                {"firm_Qty",firm_Qty},
                {"potential_Qty",potential_Qty},
                {"customer",customer},              
                //{"item_sub_id",item_sub_id},               
                               
                //{"unit_id",unit_id},
                //{"machine_smv",machine_smv},
    
                {"cat_id",cat_id},

                {"sweing_smv",sweing_smv},
                {"pck_smv",pck_smv},
                {"ws_smv",ws_smv},

                {"imgs",imgs},
                {"mesur_imgs",mesur_imgs},
                {"spec_mesur_imgs",spec_mesur_imgs},
                {"garmnt_nt",garmnt_nt},

                {"accesseries",new accesseries().InvItemListToDataTable(accesseries)},
                {"fabricCon",new fabricCon().InvItemListToDataTable(fabricCon)},
                {"pttnEmb",new pttnEmb().InvItemListToDataTable(pttnEmb)},

                {"usr",usr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_pattern_save", objDIc);
            }
        }
    }

    public class accesseries
    {
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public string cat_name { get; set; }
        public string sb_itm_nme { get; set; }
        public string sup_item_code { get; set; }
        public string sup_item_nme { get; set; }
        public decimal consm { get; set; }

        public accesseries()
        {
            itm_id = 0;
            sb_itm_id = 0;
            cat_name = "";
            sb_itm_nme = "";
            sup_item_code = "";
            sup_item_nme = "";
            consm = 0;
        }

        public DataTable InvItemListToDataTable(List<accesseries> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_id", typeof(int));
            dt1.Columns.Add("cat_name", typeof(string));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("sup_item_code", typeof(string));
            dt1.Columns.Add("sup_item_nme", typeof(string));
            dt1.Columns.Add("consm",typeof(decimal));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["itm_id"] = item.itm_id;
                _acc["sb_itm_id"] = item.sb_itm_id;
                _acc["cat_name"] = item.cat_name;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["sup_item_code"] = item.sup_item_code;
                _acc["sup_item_nme"] = item.sup_item_nme;
                _acc["consm"] = item.consm;
               
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }

    public class fabricCon
    {
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public string sup_item_code { get; set; }
        public string sb_itm_nme { get; set; }
        public decimal consum { get; set; }

        public  fabricCon()
        {
            itm_id = 0;
            sb_itm_id = 0;
            sup_item_code = "";
            sb_itm_nme = "";
            consum = 0;
        }

        public DataTable InvItemListToDataTable(List<fabricCon> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("sup_item_code", typeof(string));
            dt1.Columns.Add("consum", typeof(decimal));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["itm_id"] = item.itm_id;
                _acc["sb_itm_id"] = item.sb_itm_id;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["sup_item_code"] = item.sup_item_code;
                _acc["consum"] = item.consum;

                dt1.Rows.Add(_acc);
            }
            return dt1;
        }

    }

    public class pttnEmb
    {
        public int emb_id { get; set; }

        public pttnEmb()
        {
            emb_id = 0;
        }

        public DataTable InvItemListToDataTable(List<pttnEmb> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("emb_id", typeof(int));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["emb_id"] = item.emb_id;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }

    }


}



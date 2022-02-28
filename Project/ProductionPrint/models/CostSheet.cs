using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class CostSheet
    {
        public Guid idx { get; set; }
        public Guid pttnIdx { get; set; }
        public string suppname { get; set; }
        public string facname { get; set; }
        public string cntryOrg { get; set; }
        public string portLoad { get; set; }
        public string qtever { get; set; }
        public string prodltime { get; set; }
        public int minordQty { get; set; }
        public int minclQty { get; set; }
        public string bookded { get; set; }
        public DateTime estiHnddate { get; set; }
        public string stylRef { get; set; }
        public string descrp { get; set; }
        public string prdTyp { get; set; }
        public int ordQnty { get; set; }
        public string color { get; set; }
        public string sesn { get; set; }  
        public string demrtNo { get; set; }  
        public string demrtName { get; set; }  
        public decimal retlprce { get; set; }  
        public decimal totlfob { get; set; }  
        public decimal totlFab { get; set; }  
        public decimal totlTrim { get; set; }  
        public decimal totlNtTrim { get; set; }  
        public decimal ttlwsh { get; set; }  
        public decimal ttlpck { get; set; }  
        public decimal ttlothr { get; set; }  
        public decimal ttllbr { get; set; }
        public decimal profit { get; set; }
        public decimal d_lngth { get; set; }
        public decimal d_width { get; set; }
        public decimal d_hight { get; set; }
        public decimal pack_qnty { get; set; }

        public List<fabDt> fabDt { get; set; }
        public List<swtrim> swtrim { get; set; }
        public List<nttrimDt> nttrimDt { get; set; }
        public List<packDt> packDt { get; set; }
        public List<washDt> washDt { get; set; }
        public List<embDt> embDt { get; set; }
        public List<othrsDt> othrsDt { get; set; }
        public List<labour> labour { get; set; }
        public Guid usr { get; set; }
        public CostSheet()
        {
            idx = new Guid();
            pttnIdx = new Guid();
            suppname ="";
            facname ="";
            cntryOrg ="";
            portLoad="";
            qtever ="";
            prodltime ="";
            minordQty = 0;
            minclQty =0;
            bookded = "";
            estiHnddate = DateTime.Now;
            stylRef ="";
            descrp ="";
            prdTyp ="";
            ordQnty = 0;
            color ="";
            sesn ="";
            demrtNo ="";
            demrtName ="";
            retlprce = 0;
            totlfob = 0;
            totlFab = 0;
            totlTrim = 0;
            totlNtTrim = 0;
            ttlwsh = 0;
            ttlpck = 0;
            ttlothr= 0;
            ttllbr = 0;
            profit = 0;
            d_lngth = 0;
            d_width = 0;
            d_hight = 0;
            pack_qnty = 0;
            fabDt = new List<fabDt>();
            swtrim  = new List<swtrim> (); 
            nttrimDt = new List<nttrimDt> ();
            packDt = new List<packDt> (); 
            washDt=new List<washDt>();
            embDt =new List<embDt> ();
            othrsDt=new List<othrsDt>();
            labour = new List<labour> ();
            usr= new Guid();
        }
      
        public DataSet LoadCostingDt()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Merchandiser_costing_details", objDIc);
            }
        }
        public DataTable Save_Costing()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"pttnIdx",pttnIdx},
                {"suppname",suppname},
                {"facname",facname},
                {"cntryOrg",cntryOrg},
                {"portLoad",portLoad},
                {"qtever",qtever},
                {"prodltime",prodltime},
                {"minordQty",minordQty},
                {"minclQty",minclQty},
                {"bookded",bookded},
                {"estiHnddate",estiHnddate},
                {"stylRef",stylRef},
                {"descrp",descrp},
                {"prdTyp",prdTyp},
                {"ordQnty",ordQnty},
                {"color",color},
                {"sesn",sesn},
                {"demrtNo",demrtNo},
                {"demrtName",demrtName},
                {"retlprce",retlprce},
                {"totlfob",totlfob},
                {"totlFab",totlFab},
                {"totlTrim",totlTrim},
                {"totlNtTrim",totlNtTrim},
                {"ttlwsh",ttlwsh},
                {"ttlpck",ttlpck},
                {"ttlothr",ttlothr},
                {"ttllbr",ttllbr},
                {"profit",profit},
                {"d_lngth",d_lngth},
                {"d_width",d_width},
                {"d_hight",d_hight},
                {"pack_qnty",pack_qnty},
                {"fabDt",new fabDt().InvItemListToDataTable(fabDt)},
                {"swtrim",new swtrim().InvItemListToDataTable(swtrim)},
                {"nttrimDt",new nttrimDt().InvItemListToDataTable(nttrimDt)},
                {"packDt",new packDt().InvItemListToDataTable(packDt)},
                {"washDt",new washDt().InvItemListToDataTable(washDt)},
                {"embDt",new embDt().InvItemListToDataTable(embDt)},
                {"othrsDt",new othrsDt().InvItemListToDataTable(othrsDt)},
                {"labour",new labour().InvItemListToDataTable(labour)},
                {"usr",usr}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Merchandiser_save_Costing", objDIc);
            }
        }

    }

    public class fabDt
    {
        public Guid idx { get; set; }
        public string sup_item_nme { get; set; }
        public string sb_itm_nme { get; set; }
        public decimal extra { get; set; }
        public decimal usage { get; set; }
        public decimal fabprice { get; set; }
        public decimal wastage { get; set; }
        public decimal fnltotl { get; set; }

        public fabDt()
        {
            idx = new Guid();
            sup_item_nme = "";
            sb_itm_nme = "";
            extra = 0;
            usage = 0;
            fabprice = 0;
            wastage = 0;
            fnltotl = 0;
    }
        public DataTable InvItemListToDataTable(List<fabDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("sup_item_nme", typeof(string));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("extra", typeof(decimal));
            dt1.Columns.Add("usage", typeof(decimal));
            dt1.Columns.Add("fabprice", typeof(decimal));
            dt1.Columns.Add("wastage", typeof(decimal));
            dt1.Columns.Add("fnltotl", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["idx"] = item.idx;
                _acc["sup_item_nme"] = item.sup_item_nme;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["extra"] = item.extra;
                _acc["usage"] = item.usage;
                _acc["fabprice"] = item.fabprice;
                _acc["wastage"] = item.wastage;
                _acc["fnltotl"] = item.fnltotl;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
    public class swtrim
    {
        public Guid idx { get; set; }
        public string cat_name { get; set; }
        public string sb_itm_nme { get; set; }
        public decimal trimprice { get; set; }
        public decimal usage { get; set; }
        public decimal wastage { get; set; }
        public decimal totl { get; set; }

        public swtrim()
        {
            idx = new Guid();
            cat_name = "";
            sb_itm_nme = "";
            trimprice = 0;
            usage = 0;
            wastage = 0;
            totl = 0;

        }
        public DataTable InvItemListToDataTable(List<swtrim> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("cat_name", typeof(string));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("trimprice", typeof(decimal));
            dt1.Columns.Add("usage", typeof(decimal));
            dt1.Columns.Add("wastage", typeof(decimal));
            dt1.Columns.Add("totl", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["idx"] = item.idx;
                _acc["cat_name"] = item.cat_name;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["trimprice"] = item.trimprice;
                _acc["usage"] = item.usage;
                _acc["wastage"] = item.wastage;
                _acc["totl"] = item.totl;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
    public class nttrimDt
    {
        public Guid idx { get; set; }
        public string cat_name { get; set; }
        public string sb_itm_nme { get; set; }
        public decimal trimprice { get; set; }
        public decimal usage { get; set; }
        public decimal wastage { get; set; }
        public decimal totl { get; set; }

        public nttrimDt()
        {
            idx = new Guid();
            cat_name = "";
            sb_itm_nme = "";
            trimprice =0;
            usage = 0;
            wastage = 0;
            totl = 0;

        }

        public DataTable InvItemListToDataTable(List<nttrimDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("cat_name", typeof(string));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("trimprice", typeof(decimal));
            dt1.Columns.Add("usage", typeof(decimal));
            dt1.Columns.Add("wastage", typeof(decimal));
            dt1.Columns.Add("totl", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["idx"] = item.idx;
                _acc["cat_name"] = item.cat_name;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["trimprice"] = item.trimprice;
                _acc["usage"] = item.usage;
                _acc["wastage"] = item.wastage;
                _acc["totl"] = item.totl;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }

    }

    public class packDt
    {
        public Guid idx { get; set; }
        public string cat_name { get; set; }
        public int itm_id { get; set; }
        public int sb_itm_id { get; set; }
        public string sb_itm_nme { get; set; }
        public string unit { get; set; }
        public decimal usage { get; set; }
        public decimal wast { get; set; }
        public decimal pck_totl { get; set; }

        public packDt()
        {
            idx = new Guid();
            cat_name = "";
            itm_id = 0;
            sb_itm_id = 0;
            sb_itm_nme = "";
            unit = "";
            usage = 0;
            wast = 0;
            pck_totl = 0;

        }

        public DataTable InvItemListToDataTable(List<packDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("cat_name", typeof(string));
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            dt1.Columns.Add("unit", typeof(string));
            dt1.Columns.Add("usage", typeof(decimal));
            dt1.Columns.Add("wast", typeof(decimal));
            dt1.Columns.Add("pck_totl", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["idx"] = item.idx;
                _acc["cat_name"] = item.cat_name;
                _acc["itm_id"] = item.itm_id;
                _acc["sb_itm_id"] = item.sb_itm_id;
                _acc["sb_itm_nme"] = item.sb_itm_nme;
                _acc["unit"] = item.unit;
                _acc["usage"] = item.usage;
                _acc["wast"] = item.wast;
                _acc["pck_totl"] = item.pck_totl;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
    public class washDt
    {
        public int plant_id { get; set; }
        public string plant_name { get; set; }
        public string dec { get; set; }
        public decimal dura { get; set; }
        public decimal price { get; set; }

        public washDt()
        {
            plant_id = 0;
            plant_name = "";
            dec = "";
            dura = 0;
            price = 0;
        }

        public DataTable InvItemListToDataTable(List<washDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("plant_id", typeof(int));
            dt1.Columns.Add("plant_name", typeof(string));
            dt1.Columns.Add("dec", typeof(string));
            dt1.Columns.Add("dura", typeof(decimal));
            dt1.Columns.Add("price", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["plant_id"] = item.plant_id;
                _acc["plant_name"] = item.plant_name;
                _acc["dec"] = item.dec;
                _acc["dura"] = item.dura;
                _acc["price"] = item.price;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }

    }

    public class embDt
    {
        public int embishment_id { get; set; }
        public string descr { get; set; }
        public string embishment { get; set; }
        public int plant_id { get; set; }
        public string plcmnt { get; set; }
        public decimal emprice { get; set; }

        public embDt()
        {
            embishment_id = 0;
            descr = "";
            embishment = "";
            plant_id = 0;
            plcmnt = "";
            emprice = 0;

        }
        public DataTable InvItemListToDataTable(List<embDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("embishment_id", typeof(int));
            dt1.Columns.Add("descr", typeof(string));
            dt1.Columns.Add("embishment", typeof(string));
            dt1.Columns.Add("plant_id", typeof(int));
            dt1.Columns.Add("plcmnt", typeof(string));
            dt1.Columns.Add("emprice", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["embishment_id"] = item.embishment_id;
                _acc["descr"] = item.descr;
                _acc["embishment"] = item.embishment;
                _acc["plant_id"] = item.plant_id;
                _acc["plcmnt"] = item.plcmnt;
                _acc["emprice"] = item.emprice;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }

    }
    public class othrsDt
    {
        public string othr_nme { get; set; }
        public string shr_dec { get; set; }
        public string supp { get; set; }
        public string unit { get; set; }
        public decimal uni_pric { get; set; }
        public decimal usge { get; set; }
        public decimal wast { get; set; }
        public decimal totl { get; set; }

        public othrsDt()
        {
            othr_nme = "";
            shr_dec = "";
            supp = "";
            unit = "";
            uni_pric = 0;
            usge = 0;
            totl = 0;
        }
        public DataTable InvItemListToDataTable(List<othrsDt> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("othr_nme", typeof(string));
            dt1.Columns.Add("shr_dec", typeof(string));
            dt1.Columns.Add("supp", typeof(string));
            dt1.Columns.Add("unit", typeof(string));
            dt1.Columns.Add("uni_pric", typeof(decimal));
            dt1.Columns.Add("usge", typeof(decimal));
            dt1.Columns.Add("wast", typeof(decimal));
            dt1.Columns.Add("totl", typeof(decimal));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["othr_nme"] = item.othr_nme;
                _acc["shr_dec"] = item.shr_dec;
                _acc["supp"] = item.supp;
                _acc["unit"] = item.unit;
                _acc["uni_pric"] = item.uni_pric;
                _acc["usge"] = item.usge;
                _acc["wast"] = item.wast;
                _acc["totl"] = item.totl;

                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
    public class labour
    {
        public string product { get; set; }
        public decimal smv { get; set; }
        public decimal cpm { get; set; }
        public decimal totl { get; set; }

        public labour()
        {
            product = "";
            smv = 0;
            cpm = 0;
            totl = 0;
        }

        public DataTable InvItemListToDataTable(List<labour> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("product", typeof(string));
            dt1.Columns.Add("smv", typeof(decimal));
            dt1.Columns.Add("cpm", typeof(decimal));
            dt1.Columns.Add("totl", typeof(decimal));

            foreach (var item in lst)
            {

                DataRow _acc = dt1.NewRow();
                _acc["product"] = item.product;
                _acc["smv"] = item.smv;
                _acc["cpm"] = item.cpm;
                _acc["totl"] = item.totl;

                dt1.Rows.Add(_acc);
            }
            return dt1;
        }


    }

}

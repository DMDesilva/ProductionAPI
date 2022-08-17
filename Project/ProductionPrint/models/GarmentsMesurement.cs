using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class GarmentsMesurement
    {
        public Guid idx { get; set; }
        public int pttn_id { get; set; }
        public string c_details { get; set; }
        public string c_types { get; set; }
        public string c_finish { get; set; }
        public string c_infor { get; set; }
        public string c_loc { get; set; }
        public bool c_top { get; set; }
        public string img { get; set; }
        public List<messure> messure { get; set; }
        public List<g_sizes> g_sizes { get; set; }
        public List<sizes_mesure> sizes_mesure { get; set; }
        private string connnection { get; set; }
        public Guid usr { get; set; }
        public GarmentsMesurement()
        {
            idx = new Guid();
            pttn_id = 0;
            c_details = "";
            c_finish = "";
            c_infor = "";
            c_types = "";
            c_loc = "";
            c_top = false;
            img = "";
            messure = new List<messure>();
            g_sizes = new List<g_sizes>();
            sizes_mesure = new List<sizes_mesure>();
            usr = new Guid();
        }
        public GarmentsMesurement(string conn)
        {
            connnection = conn;
        }
        public DataTable GetSizes()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id],[sizes],0 as cs FROM [dbo].[_Merchandiser_MAST__Garments_size]");
        }

        public DataTable Getmesurepattern()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("" +
                "SELECT mesure.idx, mesure.pttn_id, pttn.pattern_name," +
                "pttn.pattern_description, mesure.c_types, mesure.c_loc" +
                ",mesure.c_finish, mesure.c_top,mesure.c_details" +
                ",mesure.c_infor,mesure.img " +
                "FROM[dbo].[_Mechandiser_Gmnt_mesure_header] as mesure " +
                "INNER JOIN[dbo].[develp_master_pattern] as pttn ON mesure.pttn_id = pttn.pattern_id");
        }
       

        public DataSet Get_spect_sheet_details()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"g_idx",idx}
              
            };
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("get_spect_sheet", objDIc);
            }
        }
        public DataTable update_column_size()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"g_sizes",new sizes_mesure().InvItemListToDataTable(sizes_mesure)},
                {"usr",usr}
                
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_update_size_column", objDIc);
            }
        }
        public DataTable update_garment_sheet()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"c_details",c_details},
                {"c_finish",c_finish},
                {"c_infor",c_infor},
                {"c_types",c_types},
                {"c_loc",c_loc},
                {"c_top",c_top},
                {"img",img},
                {"usr",usr}
                
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_update_mesure_details", objDIc);
            }
        }

        public DataTable save_spect_Sheet()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"pttn_id",pttn_id},
                {"c_details",c_details},
                {"c_finish",c_finish},
                {"c_infor",c_infor},
                {"c_types",c_types},
                {"c_loc",c_loc},
                {"c_top",c_top},
                {"img",img},
                {"messure",new messure().InvItemListToDataTable(messure)},
                {"g_sizes",new g_sizes().InvItemListToDataTable(g_sizes)},
                {"usr",usr}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Garment_mesurment", objDIc);
            }
        }
    }

    public class messure
    {
        public int id { get; set; }
        public string mesurement { get; set; }
        public messure()
        {
            id = 0;
            mesurement = "";
        }
        public DataTable InvItemListToDataTable(List<messure> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("mesurement", typeof(string));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["id"] = item.id;
                _acc["mesurement"] = item.mesurement;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }

    public class g_sizes
    {
        public int m_id { get; set; }
        public int sizes_id { get; set; }
        public string sizes_name { get; set; }
        public decimal gsizes { get; set; }
        public g_sizes()
        {
            m_id = 0;
            sizes_id = 0;
            sizes_name = "";
            gsizes = 0;
        }
        public DataTable InvItemListToDataTable(List<g_sizes> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("m_id", typeof(int));
            dt1.Columns.Add("sizes_id", typeof(int));
            dt1.Columns.Add("gsizes", typeof(decimal));
            dt1.Columns.Add("sizes_name", typeof(string));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["m_id"] = item.m_id;
                _acc["sizes_id"] = item.sizes_id;
                _acc["gsizes"] = item.gsizes;
                _acc["sizes_name"] = item.sizes_name;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }

    public class sizes_mesure
    {
        public Guid idx { get; set; }
        public decimal gsizes { get; set; }
        public sizes_mesure()
        {
            idx = new Guid();
            gsizes = 0;
        }
        public DataTable InvItemListToDataTable(List<sizes_mesure> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("idx", typeof(Guid));
            dt1.Columns.Add("gsizes", typeof(decimal));

            foreach (var item in lst)
            {
                DataRow _acc = dt1.NewRow();
                _acc["idx"] = item.idx;
                _acc["gsizes"] = item.gsizes;
                dt1.Rows.Add(_acc);
            }
            return dt1;
        }
    }
}

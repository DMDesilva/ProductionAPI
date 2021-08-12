using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class PatternCreate
    {
        public Guid pattern_id { get; set; } 
        public string pattern_name { get; set; } 
        public string pattern_des { get; set; } 
        public string origin_ref { get; set; } 
        public string corr_pattern { get; set; } 
        public string consum { get; set; } 
        public string keyword { get; set; } 
        public string specil_att { get; set; } 
        public string fact_des { get; set; } 
        public string print_typ_id { get; set; } 
        public string prod_line { get; set; } 
        public string note { get; set; } 
        public string fac_note { get; set; } 
        public string mark_desc { get; set; } 
        public string conv_fact { get; set; } 
        public double smv { get; set; } 
        public Guid suplier_id { get; set; } 
        public int isCore { get; set; } 
        public int isActive { get; set; }
        private string connection { get; set; }

        public PatternCreate()
        {
            pattern_id = new Guid();
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
            suplier_id = new Guid();
            isCore = 0;
            isActive = 0;
        }


    }
}

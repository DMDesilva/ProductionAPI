using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionPrint.models;

namespace ProductionPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BincardApiController : ControllerBase
    {
        [HttpGet("loadItem")]
        public DataTable LoadItem()
        {
            Bincard bin = new Bincard();
            return bin.LoadItems();
        }

        [HttpGet("loadSubCat")]
        public DataSet LoadSubCat()
        {
            QntyChange sub = new QntyChange(CommonData.ConStr());
            return sub.LoadSubCat();
        }
        [HttpPost("loadsubItem")]
        public DataTable LoadsubItem(ClsPrm prm)
        {
            Bincard bin = new Bincard();
            return bin.LoadSubItems(prm.iPram1);
        }

        [HttpPost("loadBincard")]
        public DataSet LoadBincard(ClsPrm prm)
        {
            Bincard bin = new Bincard();
            return bin.LoadBincard(prm.iPram1);
        }

        //---------
        [HttpPost("saveSubCat")]
        public DataTable SaveSubCat(QntyChange sub)
        {
           
            return sub.SaveSubliCat();
        }

    }
}
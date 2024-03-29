﻿using System;
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
    public class DevelopmentApiController : ControllerBase
    {
        [HttpGet("getPatten")]
        public DataTable GetPatten()
        {
            DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.LoadingPatten();
        }
        [HttpGet("getAllData")]
        public DataSet GetAllData()
        {
            DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.LoadAllData();
        }

        [HttpGet("getOrderForFab")]
        public DataTable GetOrderForFab()
        {
            DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.LoadFabForPO();
        }

        [HttpPost("saveFabConsum")]
        public DataTable SaveFabConsum(DevelopmentDeprtment dev)
        {
            //DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.SaveFabConsum();
        }
        [HttpGet("loadFabByPttn")]
        public DataSet LoadFabByPttn()
        {
            DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.LoadFabByPttn();
        }

        [HttpPost("sendEmailsFab")]
        public DataTable SendEmailsFab(EmailSend emil)
        {
            //DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return emil.SendEmails();
        }

        //-----
        [HttpPost("fabTransfer")]
        public DataTable FabTransfer(DevelopmentDeprtment dev)
        {
           // DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.FabTransPo();
        }

        ///--------------
        [HttpGet("loadPttn")]
        public DataTable LoadPttn()
        {
            Quality qua = new Quality();
            return qua.Loadpatterns();
        }

        [HttpPost("itmCat_Save")]
        public DataTable ItmCat_Save(DevelopmentDeprtment dev)
        {
            // DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.ItmCatSave();
        }

        [HttpPost("save_itmsCat")]
        public DataTable save_itmsCat(DevelopmentDeprtment dev)
        {
            // DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.save_itmsCat();
        }

        [HttpPost("itemPriceChange")]
        public DataTable ItemPriceChange(DevelopmentDeprtment dev)
        {
            // DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.ItemPriceChange();
        }

        [HttpGet("getMastItmsCat")]
        public DataSet GetMastItmsCat()
        {
            DevelopmentDeprtment dev = new DevelopmentDeprtment(CommonData.ConStr());
            return dev.SelectMastItmsCat();
        }

    }
}
﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.HubConfig
{
    public class InventoryHub:Hub
    {
        public async Task askServer(int msg)
        {
            int tempString;

            if (msg == 1)
            {
                tempString = 1;
            }
            else
            {
                tempString =0;
            }
            //Client(this.Context.ConnectionId)
            await Clients.All.SendAsync("askServerResponse", tempString);
        }
    }
}

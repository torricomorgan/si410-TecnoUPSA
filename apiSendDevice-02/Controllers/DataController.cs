using apiSendDevice_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiSendDevice_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            ServiceClient serviceClient;
            string connectionString = "HostName=IoTHub-TecnoUpsa.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=CHxqYdFUTnka1cnW3dpobRnpxnohNm+m+oYBQBgtk+E=";
            string targetDevice = "esp-01";
            string connectionString2 = "HostName=IoTHub-TecnoUpsa.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=CHxqYdFUTnka1cnW3dpobRnpxnohNm+m+oYBQBgtk+E=";
            string targetDevice2 = "esp-02";

            if (data.NameDevice.Equals("ESP-01")) {
                string mensaje = data.Mensaje;
                serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
                var commandMessage = new Message(Encoding.ASCII.GetBytes(mensaje));
                await serviceClient.SendAsync(targetDevice, commandMessage);
            }
            else if(data.NameDevice.Equals("ESP-02"))
            {
                string mensaje = data.Mensaje;
                serviceClient = ServiceClient.CreateFromConnectionString(connectionString2);
                var commandMessage = new Message(Encoding.ASCII.GetBytes(mensaje));
                await serviceClient.SendAsync(targetDevice2, commandMessage);
            }
            
            return true;
        }
    }
}

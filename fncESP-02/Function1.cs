using System;
using System.Threading.Tasks;
using fncESP_02.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncESP_02
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
            [ServiceBusTrigger("queue-esp02", Connection = "MyConn")] string myQueueItem,
            [CosmosDB(databaseName: "dbTelemetria", collectionName: "esp02", ConnectionStringSetting = "strCosmos")] IAsyncCollector<object> datos,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Datos>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception e)
            {
                log.LogError($"No fue posible insertar datos: {e.Message}");
            }
        }
    }
}

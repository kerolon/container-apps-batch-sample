using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run([QueueTrigger("myqueue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            var rand = new Random();
            var r = rand.Next(0, 1);

            log.LogInformation($"{myQueueItem} start.");
            log.LogInformation($"{myQueueItem} initialize start. wait about 3sec....");
            await Task.Delay(3 * r * 1000);
            log.LogInformation($"{myQueueItem} initialize end. wait about 3sec....");

            var r2 = rand.Next(0, 1);

            log.LogInformation($"{myQueueItem} execute. wait about 30sec....");
            await Task.Delay(30 * r2 * 1000);
            log.LogInformation($"{myQueueItem} execute. wait about 30sec....");

            log.LogInformation($"{myQueueItem} complete.");
        }
    }
}

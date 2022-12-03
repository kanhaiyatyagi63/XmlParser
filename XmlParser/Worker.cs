using System.Xml.Serialization;
using XmlParser.Models;

namespace XmlParser
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // convert your xml to class type
                XmlSerializer serializer = new XmlSerializer(typeof(Sports));
                using (StringReader reader = new StringReader(xml))
                {
                    var test = (Sports)serializer.Deserialize(reader);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //every 60 second
                await Task.Delay(60000, stoppingToken);
            }
        }

        private async Task StoreIntoDatabaseAsync(Sports sports)
        {
            // store data into database
        }
    }
}
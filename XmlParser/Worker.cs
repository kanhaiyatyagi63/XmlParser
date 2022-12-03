using System.Xml.Serialization;
using XmlParser.Models;

namespace XmlParser
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string xml = @"<XmlSports CreateDate=""2022-12-03T14:19:44.7683754Z"">
 <Sport Name=""eSports"" ID=""2357"">
  <Event Name=""NBA2K, NBA League"" ID=""66838"" IsLive=""false"" CategoryID=""9357"">
   <Match Name=""Boston Celtics (ADONIS)"" ID=""2710124"" StartDate=""2022-12-03T13:52:00"" MatchType=""Live"">
    <Bet Name=""Spread"" ID=""43825125"" IsLive=""true"">
     <Odd Name=""1"" ID=""297296222"" Value=""1.90"" SpecialBetValue=""5.5""/>
     <Odd Name=""2"" ID=""297296223"" Value=""1.83"" SpecialBetValue=""5.5""/>
     <Odd Name=""1"" ID=""297294470"" Value=""1.83"" SpecialBetValue=""6.5""/>
     <Odd Name=""2"" ID=""297294469"" Value=""1.90"" SpecialBetValue=""6.5""/>
    </Bet>
   </Match>
   <Match Name=""Phoenix Suns (ADONIS)"" ID=""2710163"" StartDate=""2022-12-03T14:24:00"" MatchType=""PreMatch"">
    <Bet Name=""Money Line"" ID=""43825684"" IsLive=""false"">
     <Odd Name=""1"" ID=""297292684"" Value=""1.43""/>
     <Odd Name=""2"" ID=""297292685"" Value=""2.65""/>
    </Bet>
    <Bet Name=""Spread"" ID=""43825682"" IsLive=""false"">
     <Odd Name=""1"" ID=""297295228"" Value=""1.83"" SpecialBetValue=""-4.5""/>
     <Odd Name=""2"" ID=""297295227"" Value=""1.89"" SpecialBetValue=""-4.5""/>
    </Bet>
    <Bet Name=""Total"" ID=""43825683"" IsLive=""false"">
     <Odd Name=""Over"" ID=""297292687"" Value=""1.83"" SpecialBetValue=""119.5""/>
     <Odd Name=""Under"" ID=""297292686"" Value=""1.89"" SpecialBetValue=""119.5""/>
    </Bet>
   </Match>
  </Event>
 </Sport>
</XmlSports>";

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
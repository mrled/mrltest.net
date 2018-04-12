using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace mrltest.net
{
    using System.Configuration;
    using Microsoft.ApplicationInsights.Extensibility;

    class Program
    {
        private static log4net.ILog _log;
        private static bool _appInsightsEnabled;
        private static TelemetryClient _appInsights;
        private static DateTime _startupTime;
        private static string _logPrefix;
        static void Main(string[] args)
        {
            _startupTime = DateTime.Now;
            _logPrefix = $"[mrltest.net] [{_startupTime}] [{String.Join(" ", args)}]";
            _appInsights = new TelemetryClient();

            _appInsightsEnabled = false;
            if (ConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"] != null)
            {
                _appInsightsEnabled = true;
                Console.WriteLine("ApplicationInsights is enabled");
                //TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"];
            }
            else
            {
                Console.WriteLine("ApplicationInsights is disabled");
            }

            log4net.Config.BasicConfigurator.Configure();
            _log = log4net.LogManager.GetLogger(typeof(Program));

            _log.Info($"{_logPrefix}: minima deify runagate cadence benzoin digitate");
            if (_appInsightsEnabled)
            {
                var aiMsg = $"{_logPrefix}: wingmen pice careful hexagon assured usurp";
                Console.WriteLine($"_appInsights.TrackEvent({aiMsg})");
                _appInsights.TrackEvent(aiMsg);
            }

            _appInsights.TrackEvent($"{_logPrefix}: (.TrackEvent()) mosaic mire wane irvin must gt agnew hubbub");

            var trace = new TraceTelemetry($"{_logPrefix}: (.Track()) elgin deus clarke feign clap soy infra velar");
            _appInsights.Track(trace);

            _appInsights.Flush();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}

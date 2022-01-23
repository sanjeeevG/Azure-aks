using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using App.Metrics.Formatters.Prometheus;


namespace AS_WebAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseMetricsWebTracking()
                .UseMetricsEndpoints(options =>
                {
                    options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                    options.EnvironmentInfoEndpointEnabled = false;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

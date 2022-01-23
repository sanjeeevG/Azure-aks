# POC
Shows how to add observability using app.metrics Prometheus and Grafana

## Steps
- Add followig packages 
	- app.metrics.aspnetcore
	- app.metrics.aspnetcore.endpoints
	- app.metrics.aspnetcore.tracking
	- app.metrics.formatters.prometheus

- Update following souce files
	- add following in configureservice in startup.cs 
	services.AddMetrics();
	- chain following in Host.CreateDefaultBuilder()
		.UseMetricsWebTracking()
        .UseMetricsEndpoints(options =>
            {
                options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                options.EnvironmentInfoEndpointEnabled = false;
            })
		

- Update Prometheus prometheus.yml file
	- job_name: "weatherapi"
	  static_configs: 
		- targets: ["localhost:5000"]
	  metrics_path: "/metrics-text"
- Run Prometheus 
	- Open Prometheus in the browser using localhost:9090 or whatever default address is mentioned 
	in prometheus.yml file
	- Select required metrics (in this case 'application_httprequests_active') and click execute button. 
- Run Graphan
	- Open Graphana using localhost:3000 
	- Add prometheus as data source and confure
	- create or import dashboard to see the metrics
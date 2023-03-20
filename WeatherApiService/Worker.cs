using DbLayer.Models;

namespace WeatherApiService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public WeatherService _rs { get; set; }
        string[] cities =
        {
            "Karachi", "Lahore", "Faisalabad", "Islamabad", "Abbottabad",//Pakistan
            "Delhi", "Mumbai", "Bangalore", "Chennai", "Pune",//India
            "Sydney", "Melbourne", "Brisbane", "Perth", "Adelaide",//Australia 
            "Casablanca", "Sale", "Rabat", "Kenitra", "Nador",//Morocco
            "Dubai", "Sharjah", "Yalah", "Sinnah", "Thoban",//UAE
            "Shanghai", "Guangzhou", "Beijing", "Shenzhen", "Nanyang",//China
            "Johannesburg", "Durban", "Welkom", "Randburg", "Pretoria",//SouthAfrica
            "Dhaka", "Chattogram", "Khulna", "Barishal", "Sylhet",//Bangladesh
            "London", "Birmingham", "Manchester", "Birstall", "Liverpool",//UK
            "Auckland", "Christchurch", "Waitakere", "Northcote", "Hamilton",//Newzeland
        };

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _rs = new WeatherService(_logger);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var city in cities)
                {
                    string prova = "https://api.openweathermap.org/data/2.5/weather?q=+"+ city + "&units=metric&appid=54880c125693096ed43dc2fd0f5ceba4";
                    WeatherData results = _rs.GetWeatherData(prova).Result;

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
namespace AggregationService.Models
{
    public class WeatherResponse
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherInfo> List { get; set; }
        public CityInfo City { get; set; }
        public WeatherResponse()
        {
            if(Cod == null)
            {
                Cod = "";
            }
            if(List == null)
            {
                List = [];
            }
            if(City == null)
            {
                City = new CityInfo();
            }
        }
    }

    public class WeatherInfo
    {
        public int Dt { get; set; }
        public MainInfo Main { get; set; }
        public List<WeatherDescription> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Rain Rain { get; set; }
        public SysInfo Sys { get; set; }
        public string DtTxt { get; set; }
        public WeatherInfo()
        {
            if(Main == null)
            {
                Main = new MainInfo();
            }
            if(Weather == null)
            {
                Weather = [];
            }
            if(Clouds == null)
            {
                Clouds = new Clouds();
            }
            if(Wind == null)
            {
                Wind = new Wind();
            }
            if(Rain == null)
            {
                Rain = new Rain();
            }
            if(Sys == null)
            {
                Sys = new SysInfo();
            }
            if(DtTxt == null)
            {
                DtTxt = "";
            }
        }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }

    public class WeatherDescription
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public WeatherDescription()
        {
            if(Main == null)
            {
                Main = "";
            }
            if(Description == null)
            {
                Description = "";
            }
            if(Icon == null)
            {
                Icon = "";
            }
        }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Rain
    {
        public double? ThreeH { get; set; } 
    }

    public class SysInfo
    {
        public string Pod { get; set; }
        public SysInfo()
        {
            if(Pod == null)
            {
                Pod = "";
            }
        }
    }

    public class CityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public CityInfo()
        {
            if(Name == null)
            {
                Name = "";
            }
            if(Country == null)
            {
                Country = "";
            }
            if(Coord == null)
            {
                Coord = new Coord();
            }
        }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

}
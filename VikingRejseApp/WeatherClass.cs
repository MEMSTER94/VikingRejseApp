using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace VikingRejseApp
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Weather
    {
        public string City { get; set; }
        public string Gennemsnit { get; set; }
        public string Mininum { get; set; }
        public string Maxinum { get; set; }
        public string Hastighed { get; set; }
        public string Unit { get; set; }
        public string Retning { get; set; }
        public string Where { get; set; }
    }
    public class WeatherForecast
    {
        public string Day { get; set; }
        public string Mouth { get; set; }
        public string Clock { get; set; }
        public string View { get; set; }
        public string Temperature { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
    }
    class WeatherClass
    {
        string CurrentURL;
        private const string APIKEY = "c4da3dc1a82cc251f0a83647cb836961";
        public Weather ChoosedCity { get; set; } = new Weather();
        public List<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();

        void GetForecast(string by)
        {
            XDocument xDocument;
            CurrentURL = "http://api.openweathermap.org/data/2.5/forecast?q=" + by + "&mode=xml&units=metric&APPID=c4da3dc1a82cc251f0a83647cb836961";
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                xDocument = XDocument.Parse(xmlContent);
            }

            WeatherForecasts.Clear();
            XElement forecast = xDocument.Descendants("forecast").First();
            foreach (XElement time in forecast.Elements("time"))
            {

                AddForecast(time);
            }
        }
        XDocument GetWeather(string by)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + by + "&mode=xml&units=metric&APPID=c4da3dc1a82cc251f0a83647cb836961";
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XDocument xDocument = XDocument.Parse(xmlContent);
                return xDocument;
            }
        }

        XElement Gettemparature(XDocument doc)
        {
            return doc.Descendants("temperature").First();
        }
        XElement GetWind(XDocument doc)
        {
            return doc.Descendants("wind").First();
        }

        private void AddForecast(XElement timeElement)
        {
            WeatherForecast forecast = new WeatherForecast()
            {
                Day = timeElement.Attribute("from").Value.Substring(8, 2),
                Mouth = timeElement.Attribute("from").Value.Substring(5, 2),
                Clock = timeElement.Attribute("from").Value.Substring(11, 8),
                View = timeElement.Element("symbol").Attribute("name").Value,
                Temperature = timeElement.Element("temperature").Attribute("value").Value,
                Min = timeElement.Element("temperature").Attribute("min").Value,
                Max = timeElement.Element("temperature").Attribute("max").Value,
            };
            WeatherForecasts.Add(forecast);
        }

        public Weather CityWeather(string city)
        {
            GetForecast(city);
            XDocument calledWeather = GetWeather(city);
            XElement temp = Gettemparature(calledWeather);

            ChoosedCity.Gennemsnit = temp.Attribute("value").Value;
            ChoosedCity.Mininum = temp.Attribute("min").Value;
            ChoosedCity.Maxinum = temp.Attribute("max").Value;
            XElement wind = GetWind(calledWeather);
            XElement speed = wind.Element("speed");
            ChoosedCity.Hastighed = speed.Attribute("value").Value;
            ChoosedCity.Unit = speed.Attribute("name").Value;
            XElement direction = wind.Element("direction");
            ChoosedCity.Retning = direction.Attribute("value").Value;
            ChoosedCity.Where = direction.Attribute("name").Value;

            return ChoosedCity;
        }
    }
}

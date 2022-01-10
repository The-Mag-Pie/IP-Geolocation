using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace IP_Geolocation
{
    public static class GeoApi
    {
        private static string APIUrl = "http://ip-api.com/json/{query}?fields=status,message,continent,country,regionName,city,district,zip,lat,lon,isp,org,asname,mobile,proxy,hosting,query";

        private static string GET(string query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIUrl.Replace("{query}", query));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            response.Close();

            return result;
        }

        public static GeoApiObject GetObject(string query)
        {
            string json = GET(query);

            System.Windows.MessageBox.Show(json
                .Replace("{", "{\n    ")
                .Replace("}", "\n}")
                .Replace(",", ",\n    ")
                );

            return JsonConvert.DeserializeObject<GeoApiObject>(json);
        }
    }

    public class GeoApiObject
    {
        public string status;
        public string message;
        public string continent;
        public string country;
        public string regionName;
        public string city;
        public string district;
        public string zip;
        public float lat;
        public float lon;
        public string isp;
        public string org;
        public string asname;
        public bool mobile;
        public bool proxy;
        public bool hosting;
        public string query;
    }
}

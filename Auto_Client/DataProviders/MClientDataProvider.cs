using Auto_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Client.DataProviders
{
    class MClientDataProvider
    {
        private const string _url = "http://localhost:5000/api/mclient";
        //sdadsasdasdasdasd
        public static IEnumerable<MClient> MClient()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var mclients = JsonConvert.DeserializeObject<IEnumerable<MClient>>(rawData);
                    return mclients;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateMClient(MClient mclient)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(mclient);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateMClient(MClient mclient)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(mclient);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteMClient(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}

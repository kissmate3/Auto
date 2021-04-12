using Auto_Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auto_Server.Repositories
{
    public static class MClientRepository
    {
        private const string filename = "MClient.json";

        public static IEnumerable<MClient> GetMClients() {

            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var mclients = JsonSerializer.Deserialize<IEnumerable<MClient>>(rawData);
                return mclients;
            }

            return new List<MClient>();
        }
        public static void StoreMClient(IEnumerable<MClient> mclients)
        {
            var rawData = JsonSerializer.Serialize(mclients);
            File.WriteAllText(filename, rawData);
        }
    }
}

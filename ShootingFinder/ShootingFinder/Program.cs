using DirectOne.RogueOne.Data.Mongo;
using MongoDB.Driver;
using Newtonsoft.Json;
using ShootingFinder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingFinder
{
    class Program
    {
        private static List<string> _notFoundList;
        private static ITenantDataContext _context;
        private static IMongoCollection<DbShooting> _collection;
        private static string _tenantId = "5bf56c8f028c3e0890d9188a";
        private static DateTime _start = DateTime.Parse("2021-09-01T00:00:00Z").AddHours(3);
        private static DateTime _end = DateTime.Parse("2021-09-30T00:00:00Z").AddHours(3);

        static Program()
        {
            Environment.SetEnvironmentVariable("Environment", "Release");
            Environment.SetEnvironmentVariable("RougueOneKeyVaultUrl", "https://do-ant-prd.vault.azure.net/");

            _notFoundList = new List<string>();
            _context = new TenantDataContext(_tenantId, ContextType.Settings);
            _collection = _context.GetCollection<DbShooting>();
        }

        static async Task Main(string[] args)
        {
            var dbShootings = await GetDbShootingsAsync();
            var bqShootings = GetShootings();
            var total = 0;

            foreach (var shooting in dbShootings)
            {

                var exists = bqShootings.Any(x => x.ShootingId == shooting.Id);
                if (!exists)
                {
                    total++;
                    _notFoundList.Add(shooting.Id);
                    var msg = $"{total.ToString().PadLeft(4, '0')} | NOT FOUND > {shooting.Id} - {shooting.Created.ToString("dd-MM-yyyy")}";
                    Console.WriteLine(msg);
                }
            }

            SaveFile();
        }

        private static async Task<IEnumerable<DbShooting>> GetDbShootingsAsync()
        {
            var filter = Builders<DbShooting>.Filter.Gte(s => s.Created, _start) &
                Builders<DbShooting>.Filter.Lte(s => s.Created, _end);

            var result = await _collection.FindAsync(filter);
            return result.ToEnumerable();
        }

        private static IList<Shooting> GetShootings()
        {
            using (var sr = new StreamReader("shootings.json"))
            {
                string json = sr.ReadToEnd();
                var shootings = JsonConvert.DeserializeObject<List<Shooting>>(json);
                return shootings;
            }
        }

        private static void SaveFile()
        {
            var path = $"{Environment.CurrentDirectory}/shootings/not_found.txt";
            var folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            File.WriteAllLines(path, _notFoundList);
        }
    }
}
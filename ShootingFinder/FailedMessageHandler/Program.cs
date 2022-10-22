using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FailedMessageHandler
{
    [BsonIgnoreExtraElements]
    public class FailedMessage
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
    }

    class Program
    {
        private static readonly IMongoCollection<FailedMessage> _collection;
        private static readonly ICollection<string> _shootings;

        static Program()
        {
            var client = new MongoClient("mongodb://usr_appd1_gateway:4PRglCJUHaMGIrCpbkp1xQdheZT8M9hKH4@domongogatewaya1prd.d1.cx:29078/admin?readPreference=primary");
            var db = client.GetDatabase("appd1_gateway");
            _collection = db.GetCollection<FailedMessage>("failedMessage");
            _shootings = new List<string> { "6172ed8b880f64ccc06672b1", "6172edc17445b3040a1a004f", "6172edc8eb7248bbee37a555", "6172ed4c7445b3040a1a001b", "6172ed559a0d78e273a303c5", "6172ed67f85b1cbe509049a6", "6172ed689a0d78e273a303cd", "6172ed83ce79e7d45279a556", "6172ed9ceb7248bbee37a542", "6172edb89a0d78e273a303f2", "6172edc4ce79e7d45279a574", "6172edceeb7248bbee37a558", "6172ed04f94d109b4e06d48e", "6172ed07c21aa990257a4bc9", "6172ed14c21aa990257a4bcf", "6172ed157445b3040a1a0004", "6172ed162b01b23fb5a3220e", "6172ed1bce79e7d45279a528", "6172ed1ec21aa990257a4bd4", "6172ed1ff85b1cbe50904986", "6172ed27880f64ccc0667285", "6172ed2b9a0d78e273a303b3", "6172ed379a0d78e273a303b8", "6172ed38b27734c6d1df1ae5", "6172ed38f85b1cbe50904991", "6172ed4f162a46c952f5d3f3", "6172ed5d2b01b23fb5a3222e", "6172ed77880f64ccc06672aa", "6172ed79162a46c952f5d406", "6172ed96b27734c6d1df1b0f", "6172eda0162a46c952f5d417", "6172eda5b27734c6d1df1b16", "6172eda6162a46c952f5d41a", "6172edb47445b3040a1a0049", "6172edb6880f64ccc06672c2", "6172edc4162a46c952f5d427", "6172edc8f85b1cbe509049d3", "6172ec7d9a0d78e273a30366", "6172ec7eb27734c6d1df1a93", "6172ec7ec21aa990257a4b8d", "6172ec7e7445b3040a19ffbf", "6172ec7f880f64ccc0667238", "6172ec80f85b1cbe5090493e", "6172ec812b01b23fb5a321cd", "6172ec82ce79e7d45279a4e3", "6172ec852b01b23fb5a321cf", "6172ec89880f64ccc066723d", "6172ec8ceb7248bbee37a4c8", "6172ec8df94d109b4e06d457", "6172ec8d162a46c952f5d399", "6172ec8dc21aa990257a4b94", "6172ec8e880f64ccc066723f", "6172ec8eeb7248bbee37a4c9", "6172ec8ece79e7d45279a4e9", "6172ec909a0d78e273a3036e", "6172ec94eb7248bbee37a4cc", "6172ec95f85b1cbe50904947", "6172ec95ce79e7d45279a4ec", "6172ec95162a46c952f5d39d", "6172ec967445b3040a19ffca", "6172ec98880f64ccc0667243", "6172ec99f94d109b4e06d45d", "6172ec9a7445b3040a19ffcc", "6172ec9beb7248bbee37a4ce", "6172ec9bf85b1cbe5090494a", "6172ec9dce79e7d45279a4f0", "6172ec9df94d109b4e06d45f", "6172ec9e162a46c952f5d3a1", "6172ec9e880f64ccc0667246", "6172ec9ff85b1cbe5090494c", "6172eca0162a46c952f5d3a2", "6172eca2162a46c952f5d3a3", "6172eca2880f64ccc0667248", "6172eca37445b3040a19ffcf", "6172eca3b27734c6d1df1aa1", "6172eca3eb7248bbee37a4d2", "6172eca3ce79e7d45279a4f3", "6172eca42b01b23fb5a321dd", "6172eca4162a46c952f5d3a4", "6172eca7f85b1cbe50904950", "6172eca8f94d109b4e06d464", "6172eca89a0d78e273a3037a", "6172ecacf85b1cbe50904952", "6172ecacce79e7d45279a4f7", "6172ecac2b01b23fb5a321e1", "6172ecac162a46c952f5d3a8", "6172ecad9a0d78e273a3037c", "6172ecaeeb7248bbee37a4d7", "6172ecaf162a46c952f5d3a9", "6172ecaf880f64ccc066724e", "6172ecb19a0d78e273a3037e", "6172ecb2f85b1cbe50904955", "6172ecb39a0d78e273a3037f", "6172ecb3c21aa990257a4ba4", "6172ecb4f85b1cbe50904956", "6172ecb4ce79e7d45279a4fb", "6172ecb52b01b23fb5a321e5", "6172ecb59a0d78e273a30380", "6172ecb5162a46c952f5d3ac", "6172ecb5880f64ccc0667251", "6172ecb8880f64ccc0667252", "6172ecb87445b3040a19ffd9", "6172ecbb162a46c952f5d3af", "6172ecbc880f64ccc0667254", "6172ecbcb27734c6d1df1aad", "6172ecbdce79e7d45279a4ff", "6172ecbdf94d109b4e06d46e", "6172ecc0ce79e7d45279a500", "6172ecc0f85b1cbe5090495b", "6172ecc0f94d109b4e06d46f", "6172ecc09a0d78e273a30385", "6172ecc0c21aa990257a4baa", "6172ecc1b27734c6d1df1aaf", "6172ecc39a0d78e273a30386", "6172ecc52b01b23fb5a321ec", "6172ecc77445b3040a19ffdf", "6172ecc7b27734c6d1df1ab1", "6172ecc7ce79e7d45279a503", "6172ecc8f94d109b4e06d472", "6172eccbc21aa990257a4bae", "6172ecce2b01b23fb5a321f0", "6172ecd09a0d78e273a3038c", "6172ecd5880f64ccc066725f", "6172ecd57445b3040a19ffe6", "6172ecd5b27734c6d1df1ab8", "6172ecd7880f64ccc0667260", "6172ecd8f85b1cbe50904965", "6172ecdaf85b1cbe50904966", "6172ecdb162a46c952f5d3bd", "6172ecdceb7248bbee37a4ec", "6172ecdff94d109b4e06d47d", "6172ecdf9a0d78e273a30393", "6172ece07445b3040a19ffeb", "6172ece27445b3040a19ffec", "6172ece2b27734c6d1df1abe", "6172ece2f85b1cbe50904969", "6172ece4eb7248bbee37a4f0", "6172ece4f85b1cbe5090496a", "6172ece6c21aa990257a4bba", "6172ece7ce79e7d45279a510", "6172ece72b01b23fb5a321fb", "6172ece8c21aa990257a4bbb", "6172ecea7445b3040a19fff0", "6172ecebf85b1cbe5090496d", "6172ecec880f64ccc066726a", "6172eceec21aa990257a4bbe", "6172ecefeb7248bbee37a4f5", "6172ecefce79e7d45279a514", "6172ecf0162a46c952f5d3c7", "6172ecf2162a46c952f5d3c8", "6172ecf6162a46c952f5d3ca", "6172ecf69a0d78e273a3039b", "6172ecf9b27734c6d1df1ac8", "6172ecf9f85b1cbe50904974", "6172ecfa2b01b23fb5a32203", "6172ecfa880f64ccc0667271", "6172ecfb7445b3040a19fff8", "6172ecfcc21aa990257a4bc4", "6172ecfdeb7248bbee37a4fc", "6172ecfece79e7d45279a51b", "6172ecfef94d109b4e06d48b", "6172ed01c21aa990257a4bc6", "6172ed03162a46c952f5d3d0", "6172ed057445b3040a19fffd", "6172ed08f94d109b4e06d490", "6172ed0ace79e7d45279a520", "6172ed0ceb7248bbee37a503", "6172ed0ff94d109b4e06d493", "6172ed13f94d109b4e06d495", "6172ed149a0d78e273a303a9", "6172ed16162a46c952f5d3d9", "6172ed169a0d78e273a303aa", "6172ed18162a46c952f5d3da", "6172ed19880f64ccc066727e", "6172ed1beb7248bbee37a509", "6172ed1e162a46c952f5d3dd", "6172ed209a0d78e273a303af", "6172ed21880f64ccc0667282", "6172ed21eb7248bbee37a50c", "6172ed28ce79e7d45279a52d", "6172ed29880f64ccc0667286", "6172ed29b27734c6d1df1ade", "6172ed2bb27734c6d1df1adf", "6172ed2cce79e7d45279a52f", "6172ed2cf94d109b4e06d4a1", "6172ed2d7445b3040a1a000e", "6172ed307445b3040a1a000f", "6172ed30b27734c6d1df1ae1", "6172ed30eb7248bbee37a513", "6172ed312b01b23fb5a3221a", "6172ed32f85b1cbe5090498e", "6172ed35162a46c952f5d3e8", "6172ed35f94d109b4e06d4a5", "6172ed36162a46c952f5d3e9", "6172ed39c21aa990257a4bdf", "6172ed3d2b01b23fb5a32220", "6172ed48eb7248bbee37a51d", "6172ed4fce79e7d45279a53e", "6172ed54eb7248bbee37a522", "6172ed5a880f64ccc066729c", "6172ed5aeb7248bbee37a525", "6172ed5deb7248bbee37a526", "6172ed5ff94d109b4e06d4b8", "6172ed609a0d78e273a303ca", "6172ed60c21aa990257a4bf0", "6172ed66f94d109b4e06d4bb", "6172ed67b27734c6d1df1afa", "6172ed69eb7248bbee37a52c", "6172ed6bb27734c6d1df1afc", "6172ed6d162a46c952f5d400", "6172ed7b162a46c952f5d407", "6172ed7bc21aa990257a4bfd", "6172ed7dce79e7d45279a553", "6172ed84162a46c952f5d40b", "6172ed8af85b1cbe509049b6", "6172ed8af94d109b4e06d4cb", "6172ed8eb27734c6d1df1b0b", "6172ed90ce79e7d45279a55c", "6172ed902b01b23fb5a32245", "6172ed91880f64ccc06672b3", "6172ed98880f64ccc06672b6", "6172ed98b27734c6d1df1b10", "6172ed9ab27734c6d1df1b11", "6172ed9bf85b1cbe509049be", "6172ed9d162a46c952f5d416", "6172ed9ec21aa990257a4c0d", "6172ed9fce79e7d45279a563", "6172eda0c21aa990257a4c0e", "6172eda4f85b1cbe509049c2", "6172eda59a0d78e273a303e9", "6172eda5eb7248bbee37a546", "6172eda7880f64ccc06672bb", "6172edac7445b3040a1a0045", "6172edaf162a46c952f5d41e", "6172edb0ce79e7d45279a56b", "6172edb19a0d78e273a303ef", "6172edb5f85b1cbe509049ca", "6172edb5f94d109b4e06d4df", "6172edb6b27734c6d1df1b1e", "6172edbac21aa990257a4c19", "6172edba880f64ccc06672c4", "6172edbbce79e7d45279a570", "6172edbbf94d109b4e06d4e2", "6172edbc9a0d78e273a303f4", "6172edbcc21aa990257a4c1a", "6172edc0162a46c952f5d425", "6172edc1ce79e7d45279a573", "6172edc5880f64ccc06672c9", "6172edc5b27734c6d1df1b24", "6172edc77445b3040a1a0052", "6172edca2b01b23fb5a32260", "6172edcd162a46c952f5d42b", "6172edceb27734c6d1df1b28", "6172edd07445b3040a1a0056", "6172edd2c21aa990257a4c24" };
        }

        static async Task Main(string[] args)
        {
            int found = 0;
            int notFound = 0;

            foreach (var shooting in _shootings)
            {
                var query = Builders<FailedMessage>.Filter.Text(shooting);
                var result = await _collection.FindAsync(query);
                var fm = await result.FirstOrDefaultAsync();

                if (fm == null)
                {
                    notFound++;
                    Console.WriteLine($"SHOOTING NOT FOUND - {shooting}");
                }
                else
                {
                    found++;
                }
            }

            Console.WriteLine($"TOTAL FOUND: {found}");
            Console.WriteLine($"TOTAL NOT FOUND: {notFound}");
        }
    }
}

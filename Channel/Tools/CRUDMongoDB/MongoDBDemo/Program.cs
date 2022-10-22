using MongoDB.Driver;
using MongoDBDemo;

string connectionString = "mongodb://localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000";
string databaseName = "simple_db";
string collectionName = "people";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<PersonalModel>(collectionName);

var person = new PersonalModel { FirstName = "Tim", LastName = "Corey" };

await collection.InsertOneAsync(person);

var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())
{
    Console.WriteLine(value: $"{result.Id}: {result.FirstName} {result.LastName}");
}
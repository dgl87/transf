using DirectOne.RogueOne.Model.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace ShootingFinder.Models
{
    [BsonDiscriminator("shooting")]
    [BsonIgnoreExtraElements]
    public class DbShooting : Entity
    {

    }
}

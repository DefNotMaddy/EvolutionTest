using System;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.Dto
{
    public class AddressDto
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("geo")]
        public GeoDto Geo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            AddressDto other = (AddressDto)obj;

            return Street == other.Street &&
                   Suite == other.Suite &&
                   City == other.City &&
                   Zipcode == other.Zipcode &&
                   Equals(Geo, other.Geo);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Street);
            hash.Add(Suite);
            hash.Add(City);
            hash.Add(Zipcode);
            hash.Add(Geo);
            return hash.ToHashCode();
        }
    }
}

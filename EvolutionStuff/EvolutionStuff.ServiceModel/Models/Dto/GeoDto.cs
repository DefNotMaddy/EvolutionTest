using System;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.Dto
{
    public class GeoDto
    {
        [JsonPropertyName("lat")]
        public decimal? Lat { get; set; }

        [JsonPropertyName("lng")]
        public decimal? Lng { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            GeoDto other = (GeoDto)obj;

            return Lat == other.Lat &&
                   Lng == other.Lng;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Lat);
            hash.Add(Lng);
            return hash.ToHashCode();
        }
    }

}

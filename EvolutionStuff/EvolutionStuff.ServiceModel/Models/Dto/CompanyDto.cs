using System;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.Dto
{
    public class CompanyDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CompanyDto other = (CompanyDto)obj;

            return Name == other.Name &&
                   CatchPhrase == other.CatchPhrase &&
                   Bs == other.Bs;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Name);
            hash.Add(CatchPhrase);
            hash.Add(Bs);
            return hash.ToHashCode();
        }
    }
}

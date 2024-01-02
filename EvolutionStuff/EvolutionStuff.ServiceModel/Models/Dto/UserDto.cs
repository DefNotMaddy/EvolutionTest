using System;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.Dto
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("company")]
        public CompanyDto Company { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            UserDto other = (UserDto)obj;

            return Id == other.Id &&
                   Name == other.Name &&
                   Username == other.Username &&
                   Email == other.Email &&
                   Equals(Address, other.Address) &&
                   Phone == other.Phone &&
                   Website == other.Website &&
                   Equals(Company, other.Company);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Username);
            hash.Add(Email);
            hash.Add(Address);
            hash.Add(Phone);
            hash.Add(Website);
            hash.Add(Company);
            return hash.ToHashCode();
        }
    }
}

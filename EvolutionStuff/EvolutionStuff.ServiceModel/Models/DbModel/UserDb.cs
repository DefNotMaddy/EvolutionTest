using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.DbModel;

public class UserDb
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string Username { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; }

    [JsonPropertyName("address")]
    public AddressDb Address { get; set; }

    [Column("phone")]
    [StringLength(255)]
    public string Phone { get; set; }

    [Column("website")]
    [StringLength(255)]
    public string Website { get; set; }

    [JsonIgnore]
    [Column("AdditionalColumn")]
    [StringLength(255)]
    public string AdditionalColumn
    {
        get => SetAdditionalColumn(Name);
        set { }
    }

    [JsonPropertyName("company")]
    public CompanyDb Company { get; set; }
    private static string SetAdditionalColumn(string name)
    {
        string[] parts = name.Split(' ');
        if (parts.Length >= 2)
        {
            char firstCharacter = parts[0][0];
            string surname = parts[1];
            return $"{firstCharacter}{surname}@ibsat.com";
        }
        else
        {
            return $"{name}@ibsat.com";
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.DbModel;


public partial class AddressDb : BaseEntity
{
#nullable enable
    [JsonIgnore]
    public virtual UserDb? User { get; } = null;
#nullable disable
    [JsonIgnore]
    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("street")]
    [StringLength(255)]
    public string Street { get; set; }

    [Column("suite")]
    [StringLength(255)]
    public string Suite { get; set; }

    [Column("city")]
    [StringLength(255)]
    public string City { get; set; }

    [Column("zipcode")]
    [StringLength(255)]
    public string Zipcode { get; set; }
    [JsonPropertyName("geo")]
    public GeoDb Geo { get; set; }
}

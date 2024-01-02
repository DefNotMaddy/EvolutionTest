using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.DbModel;

public class GeoDb : BaseEntity
{
    [JsonIgnore]
    [Column("address_id")]
    public int? AddressId { get; set; }

    [Column("lat", TypeName = "decimal(10, 4)")]
    public decimal? Lat { get; set; }

    [Column("lng", TypeName = "decimal(10, 4)")]
    public decimal? Lng { get; set; }

    [JsonIgnore]
    public virtual AddressDb Address { get; set; }

}

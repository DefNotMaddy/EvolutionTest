using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.DbModel;

public class CompanyDb : BaseEntity
{
    [JsonIgnore]
    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("catchPhrase")]
    [StringLength(255)]
    public string CatchPhrase { get; set; }

    [Column("bs")]
    [StringLength(255)]
    public string Bs { get; set; }
    [JsonIgnore]
    public virtual UserDb User { get; set; }
}

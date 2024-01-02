using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvolutionStuff.ServiceModel.Models.DbModel
{
    public class BaseEntity
    {
        [JsonIgnore]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public virtual void SetIds(UserDb user)
        {
            this.Id = user.Id;
        }
    }
}

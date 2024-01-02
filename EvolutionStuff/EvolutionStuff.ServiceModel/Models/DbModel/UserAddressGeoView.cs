

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolutionStuff.ServiceModel.Models.DbModel;

[Keyless]
public class UserAddressGeoView
{
    public int UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string UserName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UserUsername { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string UserEmail { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string UserPhone { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string UserWebsite { get; set; }

    public int AddressId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string AddressStreet { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string AddressSuite { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AddressCity { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string AddressZipcode { get; set; }

    public int GeoId { get; set; }

    [Column(TypeName = "decimal(10, 7)")]
    public decimal? GeoLat { get; set; }

    [Column(TypeName = "decimal(10, 7)")]
    public decimal? GeoLng { get; set; }
}

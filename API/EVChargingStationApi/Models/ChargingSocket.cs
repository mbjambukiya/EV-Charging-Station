using System;
using System.Collections.Generic;

namespace EVChargingStationApi.Models;

public partial class ChargingSocket
{
    public int ChargingSocketId { get; set; }

    public int SiteId { get; set; }

    public bool? IsLocked { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual EvSite Site { get; set; } = null!;

    public virtual ICollection<UserCharging> UserChargings { get; set; } = new List<UserCharging>();
}

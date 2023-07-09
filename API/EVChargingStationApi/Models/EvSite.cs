using System;
using System.Collections.Generic;

namespace EVChargingStationApi.Models;

public partial class EvSite
{
    public int SiteId { get; set; }

    public string? SiteName { get; set; }

    public decimal? ChargesPerHr { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ChargingSocket> ChargingSockets { get; set; } = new List<ChargingSocket>();
}

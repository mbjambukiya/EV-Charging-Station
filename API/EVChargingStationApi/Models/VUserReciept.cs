using System;
using System.Collections.Generic;

namespace EVChargingStationApi.Models;

public partial class VUserReciept
{
    public int TransactionId { get; set; }

    public string? Username { get; set; }

    public int ChargingSocketId { get; set; }

    public string? SiteName { get; set; }

    public decimal? ChargesPerHr { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? Duration { get; set; }

    public decimal? TotalAmount { get; set; }
}

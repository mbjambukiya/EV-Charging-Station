using System;
using System.Collections.Generic;

namespace EVChargingStationApi.Models;

public partial class UserCharging
{
    public int UserChargingId { get; set; }

    public int ChargingSocketId { get; set; }

    public int UserId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ChargingSocket ChargingSocket { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

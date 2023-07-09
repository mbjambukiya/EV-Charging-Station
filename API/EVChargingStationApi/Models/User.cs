using System;
using System.Collections.Generic;

namespace EVChargingStationApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<UserCharging> UserChargings { get; set; } = new List<UserCharging>();
}

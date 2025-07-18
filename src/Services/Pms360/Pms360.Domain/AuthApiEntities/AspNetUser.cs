﻿namespace Pms360.Infrastructure.AuthApiData;

public partial class AspNetUser
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string EmpCode { get; set; }

    public string UserName { get; set; }

    public string NormalizedUserName { get; set; }

    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string ConcurrencyStamp { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }

}

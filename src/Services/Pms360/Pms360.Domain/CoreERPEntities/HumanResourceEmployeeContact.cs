using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class HumanResourceEmployeeContact
{
    public long EmpId { get; set; }

    public string Mobile { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string EmailOffice { get; set; }

    public string Pabx { get; set; }

    public string EmergContact { get; set; }

    public string EmergContactName { get; set; }

    public string EmergContactAddress { get; set; }

    public string RelationWith { get; set; }

    public string Fax { get; set; }

    public string SocialMediaId { get; set; }

    public string PreVillage { get; set; }

    public string PerVillage { get; set; }

    public string PreRoad { get; set; }

    public string PerRoad { get; set; }

    public int? PreDivisionId { get; set; }

    public int? PerDivisionId { get; set; }

    public int? PreThanaId { get; set; }

    public int? PerThanaId { get; set; }

    public int? PreDistrictId { get; set; }

    public int? PerDistrictId { get; set; }

    public string PrePostOffice { get; set; }

    public string PerPostOffice { get; set; }

    public string PrePostCode { get; set; }

    public string PerPostCode { get; set; }

    public string PreVillageBan { get; set; }

    public string PerVillageBan { get; set; }

    public string PreRoadBan { get; set; }

    public string PerRoadBan { get; set; }

    public string PrePostOfficeBan { get; set; }

    public string PerPostOfficeBan { get; set; }

    public string BusStop { get; set; }

    public int? PreUpazilaId { get; set; }

    public int? PerUpazilaId { get; set; }

    public int? PreUnionId { get; set; }

    public int? PerUnionId { get; set; }

    public string MobileOffice { get; set; }
}

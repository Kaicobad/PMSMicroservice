using System;
using System.Collections.Generic;

namespace Pms360.Domain.CoreERPEntities;

public partial class HumanResourceEmployeeBasic
{
    public long EmpId { get; set; }

    public string EmpCode { get; set; }

    public int PunchNo { get; set; }

    public string Title { get; set; }

    public string Name { get; set; }

    public string TitleBan { get; set; }

    public string NameBan { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public DateOnly? ProbationDate { get; set; }

    public int DesignationId { get; set; }

    public int? PositionId { get; set; }

    public int? DesignationSpecId { get; set; }

    public int UnitId { get; set; }

    public int DepartmentId { get; set; }

    public int? SectionId { get; set; }

    public int? WingId { get; set; }

    public int? TeamId { get; set; }

    public int? JobLocationId { get; set; }

    public int? EmpStatusId { get; set; }

    public int? EmpTypeId { get; set; }

    public int? EmpCategoryId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string FathersName { get; set; }

    public string MothersName { get; set; }

    public string SpouseName { get; set; }

    public int? GenderId { get; set; }

    public int? ReligionId { get; set; }

    public int? MaritalStatusId { get; set; }

    public int? BloodGroupId { get; set; }

    public string Nidno { get; set; }

    public string BirthCertificateNo { get; set; }

    public int? CountryId { get; set; }

    public int? NationalityId { get; set; }

    public string InsertUserId { get; set; }

    public string TerminalId { get; set; }

    public DateTime InsertDate { get; set; }

    public string UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string PrevEmpId { get; set; }

    public string PrevPunchNo { get; set; }

    public string Bgmeaid { get; set; }

    public int? TaxPayeeCategoryId { get; set; }

    public bool? IsFinalSubmit { get; set; }

    public long? FinalSubmitBy { get; set; }

    public DateOnly? FinalSubmitDate { get; set; }

    public bool? IsApproved { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public bool IsFixed { get; set; }

    public bool IsCompOtfixed { get; set; }

    public bool? IsRollBack { get; set; }

    public long? RollBackBy { get; set; }

    public DateTime? RollBackDate { get; set; }

    public string DocumentNid { get; set; }

    public string DocOfferLetter { get; set; }
}

namespace Pms360.Infrastructure.CoreERPData;

public partial class CoreERPDbContext : DbContext
{
    public CoreERPDbContext()
    {
    }

    public CoreERPDbContext(DbContextOptions<CoreERPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CommonCompany> CommonCompanies { get; set; }

    public virtual DbSet<CommonDepartment> CommonDepartments { get; set; }

    public virtual DbSet<CommonSection> CommonSections { get; set; }

    public virtual DbSet<CommonTeam> CommonTeams { get; set; }

    public virtual DbSet<CommonUnit> CommonUnits { get; set; }

    public virtual DbSet<CommonWing> CommonWings { get; set; }

    public virtual DbSet<HumanResourceEmployeeBasic> HumanResourceEmployeeBasics { get; set; }

    public virtual DbSet<HumanResourceEmployeeContact> HumanResourceEmployeeContacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommonCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_Common.Company");

            entity.ToTable("Common_Company");

            entity.HasIndex(e => e.CompanyShortName, "IX_Common_Company").IsUnique();

            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CompanyAddressBan).HasMaxLength(250);
            entity.Property(e => e.CompanyContact).HasMaxLength(250);
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyNameBan).HasMaxLength(100);
            entity.Property(e => e.CompanyShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
        });

        modelBuilder.Entity<CommonDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Common.Department");

            entity.ToTable("Common_Department");

            entity.HasIndex(e => e.DepartmentName, "IX_Common_Department").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentNameBan).HasMaxLength(150);
            entity.Property(e => e.DepartmentShortName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CommonSection>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Common.Section");

            entity.ToTable("Common_Section");

            entity.HasIndex(e => e.SectionName, "IX_Common_Section").IsUnique();

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsLine).HasDefaultValue(0);
            entity.Property(e => e.LineCategory)
                .HasDefaultValue(0)
                .HasComment("If this section is a Line then Line Category= StandardLine=1,MiniLine=2");
            entity.Property(e => e.SectionName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SectionNameBan).HasMaxLength(50);
            entity.Property(e => e.SectionShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CommonTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK_Commom.Team");

            entity.ToTable("Common_Team");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsLine).HasDefaultValue(0);
            entity.Property(e => e.LineCategory)
                .HasDefaultValue(0)
                .HasComment("If this section is a Line then Line Category= StandardLine=1,MiniLine=2");
            entity.Property(e => e.TeamName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamNameBan).HasMaxLength(50);
        });

        modelBuilder.Entity<CommonUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK_Common.Unit");

            entity.ToTable("Common_Unit");

            entity.HasIndex(e => e.UnitName, "IX_Common_Unit").IsUnique();

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Dmcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DMCode");
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsHrmunit).HasColumnName("IsHRMUnit");
            entity.Property(e => e.MigrationDateApparel).HasColumnType("datetime");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UnitContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitFullName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UnitFullNameBan).HasMaxLength(250);
            entity.Property(e => e.UnitName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UnitNameBan).HasMaxLength(150);
            entity.Property(e => e.UnitShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitTypeId).HasComment("");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
        });

        modelBuilder.Entity<CommonWing>(entity =>
        {
            entity.HasKey(e => e.WingId).HasName("PK_Common.Wing");

            entity.ToTable("Common_Wing");

            entity.HasIndex(e => e.WingName, "IX_Common_Wing").IsUnique();

            entity.Property(e => e.WingId).HasColumnName("WingID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsLine).HasDefaultValue(0);
            entity.Property(e => e.LineCategory)
                .HasDefaultValue(0)
                .HasComment("If this section is a Line then Line Category= StandardLine=1,MiniLine=2");
            entity.Property(e => e.WingName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WingNameBan).HasMaxLength(50);
        });

        modelBuilder.Entity<HumanResourceEmployeeBasic>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("HumanResource_EmployeeBasic");

            entity.HasIndex(e => new { e.EmpStatusId, e.IsApproved }, "HumanResource_EmployeeBasic_EmpStatusID_IsApproved_EmpCode_Name,DesignationID,DepartmentID");

            entity.HasIndex(e => new { e.IsFixed, e.EmpTypeId }, "HumanResource_EmployeeBasic_IsFixed_EmpTypeID");

            entity.HasIndex(e => e.EmpCode, "_dta_index_HumanResource.EmployeeBasic_5_1394820031__K2_1").IsUnique();

            entity.HasIndex(e => new { e.UnitId, e.SectionId, e.EmpId, e.EmpCategoryId, e.EmpTypeId, e.EmpStatusId, e.CountryId, e.DesignationId, e.DepartmentId, e.DesignationSpecId, e.WingId, e.TeamId }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K13_K15_K1_K21_K20_K19_K32_K10_K14_K12_K16_K17_2_3_5_8_9_11_22_26_30_31_");

            entity.HasIndex(e => new { e.UnitId, e.EmpStatusId, e.EmpId, e.EmpCategoryId, e.EmpTypeId, e.TeamId, e.WingId, e.SectionId, e.DesignationSpecId, e.DepartmentId, e.DesignationId, e.CountryId }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K13_K19_K1_K21_K20_K17_K16_K15_K12_K14_K10_K32_2_3_5_8_9_11_22_26_30_31_");

            entity.HasIndex(e => new { e.UnitId, e.EmpId, e.DesignationId, e.DesignationSpecId, e.EmpCategoryId, e.EmpTypeId, e.TeamId, e.WingId, e.SectionId, e.DepartmentId, e.EmpStatusId, e.EmpCode, e.Name, e.PrevEmpId }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K13_K1_K10_K12_K21_K20_K17_K16_K15_K14_K19_K2_K5_K39_3_8_9_40_46");

            entity.HasIndex(e => new { e.UnitId, e.ReligionId, e.BloodGroupId, e.TeamId, e.PositionId, e.JobLocationId, e.EmpTypeId, e.EmpCategoryId, e.EmpStatusId, e.DepartmentId, e.DesignationId, e.EmpId, e.DesignationSpecId, e.SectionId, e.WingId, e.CountryId }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K13_K27_K29_K17_K11_K18_K20_K21_K19_K14_K10_K1_K12_K15_K16_K32_2_3_5_7_8_");

            entity.HasIndex(e => new { e.EmpStatusId, e.UnitId, e.EmpId, e.DesignationSpecId, e.EmpCategoryId, e.EmpTypeId, e.TeamId, e.WingId, e.SectionId, e.DepartmentId, e.DesignationId, e.IsApproved }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K19_K13_K1_K12_K21_K20_K17_K16_K15_K14_K10_K46_2_3_5_8_9_39_40");

            entity.HasIndex(e => new { e.EmpStatusId, e.IsApproved, e.EmpCode, e.Name, e.EmpId, e.DesignationSpecId, e.JobLocationId, e.TeamId, e.WingId, e.SectionId, e.DepartmentId, e.UnitId, e.DesignationId }, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K19_K46_K2_K5_K1_K12_K18_K17_K16_K15_K14_K13_K10");

            entity.HasIndex(e => e.PunchNo, "_dta_index_HumanResource_EmployeeBasic_12_951830603__K3_40");

            entity.HasIndex(e => new { e.UnitId, e.EmpStatusId, e.DesignationId, e.EmpId, e.GenderId, e.JobLocationId, e.ReligionId, e.EmpCategoryId, e.EmpTypeId, e.TeamId, e.WingId, e.SectionId, e.DesignationSpecId, e.DepartmentId }, "_dta_index_HumanResource_EmployeeBasic_5_1666261141__K13_K19_K10_K1_K26_K18_K27_K21_K20_K17_K16_K15_K12_K14_2_3_4_5_6_7_8_9_11_");

            entity.HasIndex(e => new { e.UnitId, e.EmpStatusId, e.EmpTypeId, e.EmpId, e.JobLocationId, e.EmpCategoryId, e.TeamId, e.WingId, e.SectionId, e.DesignationSpecId, e.DepartmentId, e.DesignationId }, "_dta_index_HumanResource_EmployeeBasic_5_1666261141__K13_K19_K20_K1_K18_K21_K17_K16_K15_K12_K14_K10_2_3_4_5_6_7_8_9_11_22_23_");

            entity.HasIndex(e => new { e.EmpStatusId, e.UnitId, e.IsApproved, e.JobLocationId, e.EmpId }, "_dta_index_HumanResource_EmployeeBasic_5_1666261141__K19_K13_K46_K18_K1");

            entity.HasIndex(e => new { e.EmpStatusId, e.EmpId, e.JobLocationId, e.EmpCategoryId, e.EmpTypeId, e.TeamId, e.WingId, e.SectionId, e.DesignationSpecId, e.DepartmentId, e.UnitId, e.DesignationId }, "_dta_index_HumanResource_EmployeeBasic_5_1666261141__K19_K1_K18_K21_K20_K17_K16_K15_K12_K14_K13_K10_2_3_4_5_6_7_8_9_11_22_23_");

            entity.HasIndex(e => new { e.EmpCode, e.EmpId }, "_dta_index_HumanResource_EmployeeBasic_6_592825274__K2_K1");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Bgmeaid)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("BGMEAID");
            entity.Property(e => e.BirthCertificateNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DesignationId).HasColumnName("DesignationID");
            entity.Property(e => e.DocOfferLetter).IsUnicode(false);
            entity.Property(e => e.DocumentNid)
                .IsUnicode(false)
                .HasColumnName("DocumentNID");
            entity.Property(e => e.EmpCategoryId).HasColumnName("EmpCategoryID");
            entity.Property(e => e.EmpCode)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.EmpStatusId).HasColumnName("EmpStatusID");
            entity.Property(e => e.EmpTypeId).HasColumnName("EmpTypeID");
            entity.Property(e => e.FathersName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InsertUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("InsertUserID");
            entity.Property(e => e.IsCompOtfixed).HasColumnName("IsCompOTFixed");
            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.MothersName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameBan).HasMaxLength(100);
            entity.Property(e => e.NationalityId).HasColumnName("NationalityID");
            entity.Property(e => e.Nidno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIDNo");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.PrevEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PrevEmpID");
            entity.Property(e => e.PrevPunchNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReligionId).HasColumnName("ReligionID");
            entity.Property(e => e.RollBackDate).HasColumnType("datetime");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.SpouseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TerminalID");
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TitleBan).HasMaxLength(50);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UpdateUserID");
            entity.Property(e => e.WingId).HasColumnName("WingID");
        });

        modelBuilder.Entity<HumanResourceEmployeeContact>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK_HumanResource.EmployeeContact");

            entity.ToTable("HumanResource_EmployeeContact");

            entity.HasIndex(e => e.EmpId, "_dta_index_HumanResource_EmployeeContact_12_1725301256__K1_13_14_17_18_19_20_21_22_23_24");

            entity.HasIndex(e => e.EmpId, "_dta_index_HumanResource_EmployeeContact_12_1725301256__K1_34_35_36_37");

            entity.HasIndex(e => new { e.EmpId, e.PerDivisionId, e.PreDivisionId, e.PreDistrictId, e.PerDistrictId, e.PreThanaId, e.PerThanaId }, "_dta_index_HumanResource_EmployeeContact_12_1725301256__K1_K18_K17_K21_K22_K19_K20_2_4_5_7_8_9_13_14_23_24_27_28_31_32");

            entity.HasIndex(e => new { e.EmpId, e.Mobile }, "_dta_index_HumanResource_EmployeeContact_12_1725301256__K1_K2_3_5");

            entity.HasIndex(e => e.EmpId, "_dta_index_HumanResource_EmployeeContact_5_1725301256__K1_2_13_14_19_20_21_22_23_24");

            entity.HasIndex(e => e.EmpId, "_dta_index_HumanResource_EmployeeContact_5_1725301256__K1_4_5_7");

            entity.HasIndex(e => e.EmpId, "_dta_index_HumanResource_EmployeeContact_5_1725301256__K1_4_5_7_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("EmpID");
            entity.Property(e => e.BusStop).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.EmailOffice).HasMaxLength(50);
            entity.Property(e => e.EmergContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergContactAddress)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmergContactName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileOffice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pabx)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PABX");
            entity.Property(e => e.PerDistrictId).HasColumnName("PerDistrictID");
            entity.Property(e => e.PerDivisionId).HasColumnName("PerDivisionID");
            entity.Property(e => e.PerPostCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerPostOffice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerPostOfficeBan).HasMaxLength(50);
            entity.Property(e => e.PerRoad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerRoadBan).HasMaxLength(50);
            entity.Property(e => e.PerThanaId).HasColumnName("PerThanaID");
            entity.Property(e => e.PerUnionId).HasColumnName("PerUnionID");
            entity.Property(e => e.PerUpazilaId).HasColumnName("PerUpazilaID");
            entity.Property(e => e.PerVillage).IsUnicode(false);
            entity.Property(e => e.PerVillageBan).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreDistrictId).HasColumnName("PreDistrictID");
            entity.Property(e => e.PreDivisionId).HasColumnName("PreDivisionID");
            entity.Property(e => e.PrePostCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrePostOffice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrePostOfficeBan).HasMaxLength(50);
            entity.Property(e => e.PreRoad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreRoadBan).HasMaxLength(50);
            entity.Property(e => e.PreThanaId).HasColumnName("PreThanaID");
            entity.Property(e => e.PreUnionId).HasColumnName("PreUnionID");
            entity.Property(e => e.PreUpazilaId).HasColumnName("PreUpazilaID");
            entity.Property(e => e.PreVillage)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.PreVillageBan)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.RelationWith)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SocialMediaId)
                .HasMaxLength(50)
                .HasColumnName("SocialMediaID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

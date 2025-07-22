namespace Pms360.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly ICurrentUserService _userService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService userService)
        : base(options)
    {
        _userService = userService;
    }

    public virtual DbSet<AssessorMaster> AssessorMasters => Set<AssessorMaster>();

    public virtual DbSet<AssessorType> AssessorTypes => Set<AssessorType>();

    public virtual DbSet<AssessorTypeMap> AssessorTypeMaps => Set<AssessorTypeMap>();

    public virtual DbSet<AssessorUserMap> AssessorUserMaps => Set<AssessorUserMap>();

    public virtual DbSet<CriteriaScale> CriteriaScales => Set<CriteriaScale>();

    public virtual DbSet<EvaluationCriterion> EvaluationCriteria => Set<EvaluationCriterion>();

    public virtual DbSet<EvaluationResponse> EvaluationResponses => Set<EvaluationResponse>();

    public virtual DbSet<EvaluationSummary> EvaluationSummaries => Set<EvaluationSummary>();

    public virtual DbSet<Pmscycle> Pmscycles => Set<Pmscycle>();

    public virtual DbSet<PmscycleDetail> PmscycleDetails => Set<PmscycleDetail>();

    public virtual DbSet<PmscycleDetailsWithCriteriaMapping> PmscycleDetailsWithCriteriaMappings => Set<PmscycleDetailsWithCriteriaMapping>();

    public virtual DbSet<PmsdurationType> PmsdurationTypes => Set<PmsdurationType>();

    public virtual DbSet<Pmstype> Pmstypes => Set<Pmstype>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssessorMaster>(entity =>
        {
            entity.HasKey(e => e.AssessorMasterId).HasName("PK__Assessor__9B3F9E0C66992810");

            entity.Property(e => e.AssessorMasterId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<AssessorType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Assessor__516F03B5CA3185B0");

            entity.Property(e => e.TypeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<AssessorTypeMap>(entity =>
        {
            entity.HasKey(e => e.AssessorTypeMapId).HasName("PK__Assessor__C56DBFD3302218FE");

            entity.Property(e => e.AssessorTypeMapId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.AssessorMaster).WithMany(p => p.AssessorTypeMaps)
                .HasForeignKey(d => d.AssessorMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssessorT__Asses__3E52440B");

            entity.HasOne(d => d.AssessorType).WithMany(p => p.AssessorTypeMaps)
                .HasForeignKey(d => d.AssessorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssessorT__Asses__3F466844");
        });

        modelBuilder.Entity<AssessorUserMap>(entity =>
        {
            entity.HasKey(e => e.AssessorUserMapId).HasName("PK__Assessor__FB16357D03E13FED");

            entity.Property(e => e.AssessorUserMapId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.AssessorTypeMap).WithMany(p => p.AssessorUserMaps)
                .HasForeignKey(d => d.AssessorTypeMapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssessorU__Asses__4316F928");
        });

        modelBuilder.Entity<CriteriaScale>(entity =>
        {
            entity.HasKey(e => e.ScaleId).HasName("PK__Criteria__27D59566C895B1B4");

            entity.ToTable("CriteriaScale");

            entity.Property(e => e.ScaleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Label).HasMaxLength(100);

            entity.HasOne(d => d.Criteria).WithMany(p => p.CriteriaScales)
                .HasForeignKey(d => d.CriteriaId)
                .HasConstraintName("FK__CriteriaS__Crite__693CA210");
        });

        modelBuilder.Entity<EvaluationCriterion>(entity =>
        {
            entity.HasKey(e => e.CriteriaId).HasName("PK__Evaluati__FE6ADBCDCECC6B44");

            entity.Property(e => e.CriteriaId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<EvaluationResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__Evaluati__1AAA646C1982E5DE");

            entity.ToTable("EvaluationResponse");

            entity.Property(e => e.ResponseId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Comment).HasMaxLength(500);

            entity.HasOne(d => d.AssessorUserMap).WithMany(p => p.EvaluationResponses)
                .HasForeignKey(d => d.AssessorUserMapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluatio__Asses__60A75C0F");

            entity.HasOne(d => d.Criteria).WithMany(p => p.EvaluationResponses)
                .HasForeignKey(d => d.CriteriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluatio__Crite__619B8048");
        });

        modelBuilder.Entity<EvaluationSummary>(entity =>
        {
            entity.HasKey(e => e.SummaryId).HasName("PK__Evaluati__DAB10E2F0B0B47A7");

            entity.ToTable("EvaluationSummary");

            entity.Property(e => e.SummaryId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AverageScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalRatingPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalizedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cycle).WithMany(p => p.EvaluationSummaries)
                .HasForeignKey(d => d.CycleId)
                .HasConstraintName("FK__Evaluatio__Cycle__656C112C");
        });

        modelBuilder.Entity<Pmscycle>(entity =>
        {
            entity.HasKey(e => e.CycleId).HasName("PK__PMSCycle__077B24F938781B05");

            entity.ToTable("PMSCycles");

            entity.Property(e => e.CycleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PmsdurationTypeId).HasColumnName("PMSDurationTypeId");
            entity.Property(e => e.PmstypeId).HasColumnName("PMSTypeId");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.PmsdurationType).WithMany(p => p.Pmscycles)
                .HasForeignKey(d => d.PmsdurationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSCycles__PMSDu__4D94879B");

            entity.HasOne(d => d.Pmstype).WithMany(p => p.Pmscycles)
                .HasForeignKey(d => d.PmstypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSCycles__PMSTy__4CA06362");
        });

        modelBuilder.Entity<PmscycleDetail>(entity =>
        {
            entity.HasKey(e => e.CycleDetailsId).HasName("PK__PMSCycle__AFFF537D01F02891");

            entity.ToTable("PMSCycleDetails");

            entity.Property(e => e.CycleDetailsId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.AssessorMaster).WithMany(p => p.PmscycleDetails)
                .HasForeignKey(d => d.AssessorMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSCycleD__Asses__52593CB8");

            entity.HasOne(d => d.Cycle).WithMany(p => p.PmscycleDetails)
                .HasForeignKey(d => d.CycleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSCycleD__Cycle__5165187F");
        });

        modelBuilder.Entity<PmscycleDetailsWithCriteriaMapping>(entity =>
        {
            entity.HasKey(e => e.CycleDetailsCriteriaMappingId).HasName("PK__PMSCycle__03D18BD1BB1BFC75");

            entity.ToTable("PMSCycleDetailsWithCriteriaMapping");

            entity.Property(e => e.CycleDetailsCriteriaMappingId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Criteria).WithMany(p => p.PmscycleDetailsWithCriteriaMappings)
                .HasForeignKey(d => d.CriteriaId)
                .HasConstraintName("FK__PMSCycleD__Crite__5CD6CB2B");

            entity.HasOne(d => d.CycleDetails).WithMany(p => p.PmscycleDetailsWithCriteriaMappings)
                .HasForeignKey(d => d.CycleDetailsId)
                .HasConstraintName("FK__PMSCycleD__Cycle__5BE2A6F2");
        });

        modelBuilder.Entity<PmsdurationType>(entity =>
        {
            entity.HasKey(e => e.DurationTypeId).HasName("PK__PMSDurat__86AED33B91117DB8");

            entity.ToTable("PMSDurationTypes");

            entity.Property(e => e.DurationTypeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Pmstype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__PMSTypes__516F03B565EBC1CF");

            entity.ToTable("PMSTypes");

            entity.Property(e => e.TypeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Detached:
                    entry.State = EntityState.Modified;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.CreatedById = _userService.UserId;
                    entry.Entity.UpdatedBy = _userService.UserId;
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _userService.UserId;
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedOn = DateTime.UtcNow;
                    entry.Entity.DeletedById = _userService.UserId;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

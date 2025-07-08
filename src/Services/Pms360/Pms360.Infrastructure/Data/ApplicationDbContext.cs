namespace Pms360.Infrastructure.Data;
public class ApplicationDbContext : DbContext , IApplicationDbContext
{
    private readonly ICurrentUserService _userService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService userService) : base(options)
    {
        _userService = userService;
    }
    public DbSet<PMSType> PMSTypes => Set<PMSType>();
    public DbSet<PMSDurationType> PMSDurationTypes => Set<PMSDurationType>();
    public DbSet<AssessorType> AssessorTypes => Set<AssessorType>();
    public DbSet<CriteriaScale> CriteriaScales => Set<CriteriaScale>();
    public DbSet<EvaluationCriteria> EvaluationCriteria => Set<EvaluationCriteria>();
    public DbSet<EvaluationResponse> EvaluationResponses => Set<EvaluationResponse>();
    public DbSet<EvaluationSummary> EvaluationSummaries => Set<EvaluationSummary>();
    public DbSet<PMSAssessor> PMSAssessors => Set<PMSAssessor>();
    public DbSet<PMSCycle> PMSCycles => Set<PMSCycle>();
    public DbSet<PMSCycleDetails> PMSCycleDetails => Set<PMSCycleDetails>();
    public DbSet<PMSCycleDetailsWithCriteriaMapping> PMSCycleDetailsWithCriteriaMappings => Set<PMSCycleDetailsWithCriteriaMapping>();
    public DbSet<AssessorMaster> AssessorMasters => Set<AssessorMaster>();
    public DbSet<AssessorTypeMap> AssessorTypeMaps => Set<AssessorTypeMap>();
    public DbSet<AssessorUserMap> AssessorUserMaps => Set<AssessorUserMap>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<AssessorTypeMap>()
       .HasOne(x => x.AccessorMaster)
       .WithMany(x => x.AssessorTypeMaps)
       .HasForeignKey(x => x.AssessorMasterId)
       .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        modelBuilder.Entity<AssessorUserMap>()
            .HasOne(x => x.AccessorMaster)
            .WithMany(x => x.AssessorUserMaps)
            .HasForeignKey(x => x.AssessorMasterId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        modelBuilder.Entity<AssessorUserMap>()
            .HasOne(x => x.AssessorTypeMap)
            .WithMany(x => x.AssessorUserMaps)
            .HasForeignKey(x => x.AssessorTypeMapId)
            .OnDelete(DeleteBehavior.Restrict);
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
}

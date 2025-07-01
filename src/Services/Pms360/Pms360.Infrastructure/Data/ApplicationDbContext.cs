namespace Pms360.Infrastructure.Data;
public class ApplicationDbContext : DbContext , IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
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
                    //entry.Entity.ModifiedById = _loggedInUser.Id;
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    //entry.Entity.ModifiedById = _loggedInUser.Id;
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedOn = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

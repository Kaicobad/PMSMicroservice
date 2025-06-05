namespace Pms360.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
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
}

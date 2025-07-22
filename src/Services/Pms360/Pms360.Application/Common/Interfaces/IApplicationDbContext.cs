using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Pmstype> Pmstypes { get; }
    DbSet<PmsdurationType> PmsdurationTypes { get; }
    DbSet<AssessorType> AssessorTypes { get; }
    DbSet<CriteriaScale> CriteriaScales { get; }
    DbSet<EvaluationCriterion> EvaluationCriteria { get; }
    DbSet<EvaluationResponse> EvaluationResponses { get; }
    DbSet<EvaluationSummary> EvaluationSummaries { get; }
    DbSet<Pmscycle> Pmscycles { get; }
    DbSet<PmscycleDetail> PmscycleDetails { get; }
    DbSet<PmscycleDetailsWithCriteriaMapping> PmscycleDetailsWithCriteriaMappings { get; }
    DbSet<AssessorMaster> AssessorMasters { get; }
    DbSet<AssessorTypeMap> AssessorTypeMaps { get; }
    DbSet<AssessorUserMap> AssessorUserMaps { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

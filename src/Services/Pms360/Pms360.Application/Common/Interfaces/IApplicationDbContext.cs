using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<PMSType> PMSTypes { get; }
    DbSet<PMSDurationType> PMSDurationTypes { get; }
    DbSet<AssessorType> AssessorTypes { get; }
    DbSet<CriteriaScale> CriteriaScales { get; }
    DbSet<EvaluationCriteria> EvaluationCriteria { get; }
    DbSet<EvaluationResponse> EvaluationResponses { get; }
    DbSet<EvaluationSummary> EvaluationSummaries { get; }
    DbSet<PMSAssessor> PMSAssessors { get; }
    DbSet<PMSCycle> PMSCycles { get; }
    DbSet<PMSCycleDetails> PMSCycleDetails { get; }
    DbSet<PMSCycleDetailsWithCriteriaMapping> PMSCycleDetailsWithCriteriaMappings { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

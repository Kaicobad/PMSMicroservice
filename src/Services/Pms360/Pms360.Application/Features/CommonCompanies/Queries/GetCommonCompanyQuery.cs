using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Features.CommonCompanies.Queries;
public class GetCommonCompanyQuery  : IRequest<IResponse<List<CommonCompany>>>
{
}
public class GetCommonCompanyQueryHandler(ICommonCompanyService service) : IRequestHandler<GetCommonCompanyQuery, IResponse<List<CommonCompany>>>
{
    private readonly ICommonCompanyService _service = service;

    public async Task<IResponse<List<CommonCompany>>> Handle(GetCommonCompanyQuery request, CancellationToken cancellationToken)
    {
        var companies = await _service.GetAllAsync(cancellationToken).ConfigureAwait(false);

        if (companies.Count > 0)
        {
            return Response<List<CommonCompany>>.Success(companies);
        }
        return Response<List<CommonCompany>>.Fail("No Companies exists !");
    }
}

using MediatR;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.Queries
{
    public class GetKalaGorohHandler : IRequestHandler<KalaGorohInputViewModel, IEnumerable<KalaGorohOutput>>
    {
        private readonly IKalaGorohServiceCaller _KalaGorohServiceCaller;

        public GetKalaGorohHandler(IKalaGorohServiceCaller kalaGorohServiceCaller)
        {
            _KalaGorohServiceCaller = kalaGorohServiceCaller;
        }

        public async Task<IEnumerable<KalaGorohOutput>> Handle(KalaGorohInputViewModel request, CancellationToken cancellationToken)
        {
            var result = await _KalaGorohServiceCaller.GetKalaGoroh(request);
            return result;
        }
    }
}

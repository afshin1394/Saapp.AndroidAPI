using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Inputs ;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.ViewModels.Inputs;

namespace Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.Queries
{
    public class GetSellCenterHandler : IRequestHandler<SellCenterInputViewModel, IEnumerable<SellCenterOutput>>
    {
        private readonly ISellCenterServiceCaller _SellCenterServiceCaller;
        public GetSellCenterHandler(ISellCenterServiceCaller sellCenterServiceCaller)
        {
            _SellCenterServiceCaller = sellCenterServiceCaller;
        }


       
        public async Task<IEnumerable<SellCenterOutput>> Handle(SellCenterInputViewModel request, CancellationToken cancellationToken)
        {
            var result = await _SellCenterServiceCaller.GetSellCenter(request);
            return result;
        }
    }
}

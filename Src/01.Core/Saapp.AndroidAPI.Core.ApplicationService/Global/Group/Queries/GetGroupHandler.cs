using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Saapp.AndroidAPI.Core.ApplicationService.Global.Group.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;

namespace Saapp.AndroidAPI.Core.ApplicationService.Global.Group.Queries
{
    public class GetGroupHandler : IRequestHandler<GroupInputViewModel, IEnumerable<GroupOutput>>
    {
        private readonly IGroupServiceCaller _GorohServiceCaller;
        public GetGroupHandler(IGroupServiceCaller gorohServiceCaller)
        {
            _GorohServiceCaller = gorohServiceCaller;
        }
        public async Task<IEnumerable<GroupOutput>> Handle(GroupInputViewModel request, CancellationToken cancellationToken)
        {
            var result = await _GorohServiceCaller.GetGoroh(request);
            return result;
        }
    }
}

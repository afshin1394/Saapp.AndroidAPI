using MediatR;
using Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.Queries
{
    public class GetPlaceByCenterIDHandler : IRequestHandler<PlaceByCenterIDInputViewModel, IEnumerable<PlaceByCenterIDOutput>>
    {

        private readonly IPlaceByCenterIDServiceCaller _PlaceServiceCaller;

        public GetPlaceByCenterIDHandler(IPlaceByCenterIDServiceCaller placeServiceCaller)
        {
            _PlaceServiceCaller = placeServiceCaller;
        }

        public async Task<IEnumerable<PlaceByCenterIDOutput>> Handle(PlaceByCenterIDInputViewModel request, CancellationToken cancellationToken)
        {
            var result = await _PlaceServiceCaller.GetPlacesByCenterID(request);
            return result;
        }
    }
}

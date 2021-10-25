using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.ViewModels.Inputs;
using Saapp.AndroidAPI.Endpoints.GRPC.Amargar.PlaceByCenterID.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Endpoints.GRPC.Amargar.PlaceByCenterID.Protos
{
    public class PlaceByCenterIDService : PlaceByCenterID.PlaceByCenterIDBase
    {

        private readonly ILogger<PlaceByCenterIDService> _logger;
        private readonly IMediator mediator;


        public PlaceByCenterIDService(ILogger<PlaceByCenterIDService> logger, IMediator mediator)
        {

            _logger = logger;
            this.mediator = mediator;
        }

        public override async Task<PlaceByCenterIDReplyList> GetPlacesByCenterID(PlaceByCenterIDRequest request, ServerCallContext context)
        {
            var model = new PlaceByCenterIDInputViewModel
            {

            };

            var placeReplies = (await mediator.Send(model)).Select(m =>
               new PlaceByCenterIDReply
               {
                   PlaceID = m.ccMahal,
                   PlaceName = m.NameMahal,
                   PlaceTypeCode = m.CodeNoeMahal,
                   LinkPlaceID = m.ccMahalLink,
                   AreaCode = m.PishShomareh,

               }).ToList();

            if (placeReplies == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, " is Not Found"));
            }
            var result = new PlaceByCenterIDReplyList();
            result.PlacesByCenterId.AddRange(placeReplies);

            return result;
        }

    }
}

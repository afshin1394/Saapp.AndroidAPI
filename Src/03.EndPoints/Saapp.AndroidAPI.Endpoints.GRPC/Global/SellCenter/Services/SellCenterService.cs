using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.Queries;
using Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;

namespace Saapp.AndroidAPI.Endpoints.GRPC.Global.SellCenter.Protos
{
    public class SellCenterService : SellCenter.SellCenterBase
    {

        private readonly ILogger<SellCenterService> _logger;
        private readonly IMediator mediator;


        public SellCenterService(ILogger<SellCenterService> logger, IMediator mediator)
        {

            _logger = logger;
            this.mediator = mediator;
        }

        public override async Task<SellCenterReplyList> GetSellCenters (SellCenterRequest request, ServerCallContext context)
        {
            var model = new SellCenterInputViewModel
            {
            };

            var sellCenterReplies = (await mediator.Send(model)).Select(m =>
               new SellCenterReply
               {
                   CenterID = m.ccMarkaz,
                   CenterCode = m.CodeMarkaz,
                   CenterName = m.NameMarkaz,
                   Latitude = m.latitude_y,
                   Longitude = m.longitude_x,
                  
               }).ToList();

            if (sellCenterReplies == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $" is Not Found"));
            }
            var result = new SellCenterReplyList();
            result.SellReplies.AddRange(sellCenterReplies);

            return result;
        }


    }

}

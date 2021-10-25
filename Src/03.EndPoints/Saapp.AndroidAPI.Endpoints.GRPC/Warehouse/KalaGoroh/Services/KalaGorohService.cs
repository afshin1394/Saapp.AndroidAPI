using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.Queries;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Saapp.AndroidAPI.Endpoints.GRPC
{
    public class KalaGorohService : KalaGoroh.KalaGorohBase
    {
        private readonly ILogger<KalaGorohService> _logger;
        private readonly IMediator mediator;
        

        public KalaGorohService(ILogger<KalaGorohService> logger, IMediator mediator)
        {
            
            _logger = logger;
            this.mediator = mediator;
        }

        public override async Task<KalaGorohReplyList> GetKalaGoroh(KalaGorohRequest request, ServerCallContext context)
        {
            var model = new KalaGorohInputViewModel
            {
                ccGoroh = request.CcKalaGoroh
            };

            var KalaGorohReplys = (await mediator.Send(model)).Select(m =>
               new KalaGorohReply
               {
                   GroupId = m.ccGoroh,
                   ParentId = m.ccGorohLink,
                   GoodsId = m.ccKalaCode,
                   RootId = m.ccRoot,
                   GroupCode = m.CodeGoroh,
                   GroupTypeCode = m.CodeNoeGoroh,
                   GroupName = m.NameGoroh,
                   GoodsName = m.NameKala
               }).ToList();

            if (KalaGorohReplys == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"ID = {request.CcKalaGoroh} is Not Found"));
            }
            var result = new KalaGorohReplyList();
            result.KalaGorohs.AddRange(KalaGorohReplys);

            return result;
        }

    }
}

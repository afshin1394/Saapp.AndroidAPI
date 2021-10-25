using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Saapp.AndroidAPI.Core.ApplicationService.Global.Group.Queries;
using Saapp.AndroidAPI.Core.ApplicationService.Global.Group.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;

 namespace Saapp.AndroidAPI.Endpoints.GRPC.Global.Group.Protos
{
    public class GroupService  : Group.GroupBase
    {

        private readonly ILogger<GroupService> _logger;
        private readonly IMediator mediator;


        public GroupService(ILogger<GroupService> logger, IMediator mediator)
        {

            _logger = logger;
            this.mediator = mediator;
        }

       public override async Task<GroupReplyList> GetGroup (GroupRequest request, ServerCallContext context)
       {
            var model = new GroupInputViewModel
            {

            };

            var GroupReplys = (await mediator.Send(model)).Select(m =>
               new GroupReply
               {
                   GroupID = m.ccGoroh,
                   GroupName = m.NameGoroh,
                   LinkGroupID = m.ccGorohLink,
                   RootID = m.ccRoot,
                   GroupTypeCode = m.CodeNoeGoroh,

               }).ToList();

            if (GroupReplys == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, " is Not Found"));
            }
            var result = new GroupReplyList();
            result.Groups.AddRange(GroupReplys);

            return result;
        }
    }
}

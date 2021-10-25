using MediatR;
using System.Collections.Generic;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;
namespace Saapp.AndroidAPI.Core.ApplicationService.Global.Group.ViewModels.Inputs
{
    public class GroupInputViewModel : IRequest<IEnumerable<GroupOutput>>, IGroupInput
    {
      
    }
}

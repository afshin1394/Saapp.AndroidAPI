using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;

namespace Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels
{
    public interface IGroupServiceCaller
    {
        Task<IEnumerable<GroupOutput>> GetGoroh(IGroupInput input);

    }
}

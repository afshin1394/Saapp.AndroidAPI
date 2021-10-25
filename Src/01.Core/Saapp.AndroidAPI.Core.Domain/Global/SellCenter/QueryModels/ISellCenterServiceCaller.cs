using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels
{
    public interface ISellCenterServiceCaller
    {
        Task<IEnumerable<SellCenterOutput>> GetSellCenter(ISellCenterInput input);
    }
}

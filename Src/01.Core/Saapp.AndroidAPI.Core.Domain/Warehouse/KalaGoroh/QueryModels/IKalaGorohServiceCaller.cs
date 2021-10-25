using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels
{
    public interface IKalaGorohServiceCaller
    {
        Task<IEnumerable<KalaGorohOutput>> GetKalaGoroh(IKalaGorohInput input);

    }
}

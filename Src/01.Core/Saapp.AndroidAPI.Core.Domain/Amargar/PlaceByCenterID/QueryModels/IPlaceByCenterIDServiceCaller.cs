using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels
{
    public interface IPlaceByCenterIDServiceCaller
    {
        Task<IEnumerable<PlaceByCenterIDOutput>> GetPlacesByCenterID(IPlaceByCenterIDInput input);
    }
}

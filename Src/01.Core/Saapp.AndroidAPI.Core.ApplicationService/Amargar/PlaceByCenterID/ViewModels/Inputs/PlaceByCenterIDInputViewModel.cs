using MediatR;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.ViewModels.Inputs
{
    public class PlaceByCenterIDInputViewModel : IRequest<IEnumerable<PlaceByCenterIDOutput>>, IPlaceByCenterIDInput
    {
        public int ccMarkaz { get; set; }

    }
}

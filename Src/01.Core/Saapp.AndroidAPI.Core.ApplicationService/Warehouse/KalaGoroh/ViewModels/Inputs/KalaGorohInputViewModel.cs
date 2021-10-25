using MediatR;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using System.Collections.Generic;

namespace Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Inputs
{
    public class KalaGorohInputViewModel : IRequest <IEnumerable<KalaGorohOutput>>, IKalaGorohInput
    {
        public string ccGoroh { get; set; } = "1357";
    }
}

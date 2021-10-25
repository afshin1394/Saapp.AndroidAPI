using MediatR;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.ViewModels.Inputs
{
    public class StatisticGoodsInputViewModel : IRequest<IEnumerable<StatisticGoodsOutput>>, IGoodsStatisticInput
    {
    }
}

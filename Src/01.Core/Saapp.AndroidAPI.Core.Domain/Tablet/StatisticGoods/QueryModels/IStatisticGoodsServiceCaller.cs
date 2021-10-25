using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels
{
    public interface IStatisticGoodsServiceCaller
    {

        Task<IEnumerable<StatisticGoodsOutput>> GetGoodsStatistic(IGoodsStatisticInput input);
    }
}

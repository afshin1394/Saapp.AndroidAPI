using MediatR;
using Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.Queries
{
    public class GetStatisticGoodsHandler : IRequestHandler<StatisticGoodsInputViewModel, IEnumerable<StatisticGoodsOutput>>
    {

        private readonly IStatisticGoodsServiceCaller _GoodsStatisticServiceCaller;
        public GetStatisticGoodsHandler(IStatisticGoodsServiceCaller goodsStatisticServiceCaller)
        {
            _GoodsStatisticServiceCaller = goodsStatisticServiceCaller;
        }



        public async Task<IEnumerable<StatisticGoodsOutput>> Handle(StatisticGoodsInputViewModel request, CancellationToken cancellationToken)
        {
            var result = await _GoodsStatisticServiceCaller.GetGoodsStatistic(request);
            return result;
        }
    }
}

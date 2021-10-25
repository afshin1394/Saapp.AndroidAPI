using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Endpoints.GRPC.Tablet.StatisticGoods.Protos
{
    public class StatisticGoodsService : StatisticGoods.StatisticGoodsBase
    {
        private readonly ILogger<StatisticGoodsService> _logger;
        private readonly IMediator mediator;


        public StatisticGoodsService(ILogger<StatisticGoodsService> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public override async Task<StatisticGoodsReplyList> GetStatisticGoods(StatisticGoodsRequest request, ServerCallContext context)
        {
            var model = new StatisticGoodsInputViewModel
            {
            };

            var statisticGoodsViewModel = (await mediator.Send(model)).Select(m =>
               new StatisticGoodsReply
               {

                   Width =m.Arz,
                   Heigth = m.Ertefa,
                   Length = m.Tol,
                   BrandID = m.ccBrand,
                   BrandName = m.NameBrand,
                   GoodsCodeID = m.ccKalaCode,
                   GoodsGroupName = m.NameGorohKala,
                   GoodsGroupID = m.ccGorohKala,
                   GoodsName = m.NameKala,
                   BoxWeigth = m.VaznKarton,
                   WeightUnitID = m.ccVahedVazn,
                   NonPureWeight = m.VaznNaKhales,
                   PureWeight = m.VaznKhales,
                   SizeUnitID = m.ccVahedSize,
                   Count1 = m.Tedad1,
                   Count2 = m.Tedad2,
                   Count3 = m.Tedad3
                   


                   //GoodsCodeID = m.ccKalaCode,
                   //GoodsGroupName = m.NameGorohKala,

                   //GoodsCode = m.CodeKala,
                   //Barcode = m.BarCode,
                   //CodeGoodsID = m.ccKalaCode,
                   //BuyPrice = m.MablaghKharid,
                   //SellPrice = m.MablaghForosh,
                   //BatchNumber = m.ShomarehBach,
                   //BoxWeigth = m.VaznKarton,
                   //BrandID = m.ccBrand,
                   //BrandName = m.NameBrand,
                   //ConsumerPrice = m.MablaghMasrafKonandeh,
                   //CountUnitID = m.ccVahedVazn,
                   //CountUnitName = m.NameVahedVazn,
                   //ExpirationDate = m.TarikhEngheza,
                   //OrginalSellPrice = m.GheymatForoshAsli,
                   //GoodsGroupID = m.ccGorohKala,
                   //GoodsName = m.NameKala,
                   //Heigth = m.Ertefa,
                   //IsTaxable = m.MashmolMaliatAvarez,
                   //NonPureWeight = m.VaznNaKhales,
                   //PureWeight = m.VaznKhales,

                   //OrginalConsumerPrice = m.GheymatMasrafKonandehAsli,
                   //PastSellAmount = m.LastMablaghForosh,
                   //ProductionDate = m.TarikhTolid,
                   //Quantity = m.Adad,
                   //QuantityInBox = m.TedadDarKarton,
                   //QuantityInPack = m.TedadDarBasteh,
                   //Row = m.Radif,
                   //SaleableInventoryQuantity = m.MashmolMaliatAvarez,
                   //SortCode = m.CodeSort,
                   //SizeUnitID = m.ccVahedSize,
                   //SizeUnitName = m.NameVahedSize,
                   //SupplierID = m.ccTaminKonandeh,
                   //Weigth = m.ccVahedVazn,

                   //WeigthUnitName = m.NameVahedVazn,
                   //Width = m.Arz,
                   //Length = m.Tol,
                   //Count1 = m.Tedad1,
                   //Count2 = m.Tedad2,
                   //Count3 = m.Tedad3,


               }).ToList();


            if (statisticGoodsViewModel == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $" is Not Found"));
            }
            var result = new StatisticGoodsReplyList();
            result.StatisticGoods.AddRange(statisticGoodsViewModel);

            return result;
        }

    }
}

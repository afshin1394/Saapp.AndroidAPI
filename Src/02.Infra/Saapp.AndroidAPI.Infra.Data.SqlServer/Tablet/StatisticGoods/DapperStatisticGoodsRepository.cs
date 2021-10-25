using Dapper;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Outputs;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Tablet.StatisticGoods
{
    public class DapperStatisticGoodsRepository : DapperBaseRepository, IStatisticGoodsServiceCaller
    {
        public DapperStatisticGoodsRepository(DatabaseOptions databaseOptions) : base(databaseOptions)
        {

        }



        public async Task<IEnumerable<StatisticGoodsOutput>> GetGoodsStatistic(IGoodsStatisticInput input)
        {


            var query = $" EXEC [Tablet].[Get_Amargar_Kala] ";
            var result = await dbConnection.QueryAsync<StatisticGoodsOutput>(query, input);
            return result;


        }
    }
}

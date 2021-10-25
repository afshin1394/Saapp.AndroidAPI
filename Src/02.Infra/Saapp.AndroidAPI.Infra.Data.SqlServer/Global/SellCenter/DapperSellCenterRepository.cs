using Dapper;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Global.SellCenter
{
    public class DapperSellCenterRepository : DapperBaseRepository , ISellCenterServiceCaller
    {

        public DapperSellCenterRepository(DatabaseOptions databaseOptions) : base(databaseOptions)
        {

        }

        public async Task<IEnumerable<SellCenterOutput>> GetSellCenter(ISellCenterInput input)
        {


            var query = $" select * from  [Global].[Markaz] ";
            var result = await dbConnection.QueryAsync<SellCenterOutput>(query, input);

            return result;


        }
    }
}

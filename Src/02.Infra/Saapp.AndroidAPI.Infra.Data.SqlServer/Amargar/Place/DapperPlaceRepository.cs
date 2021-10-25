using Dapper;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Amargar.Place
{
    public class DapperPlaceRepository : DapperBaseRepository, IPlaceByCenterIDServiceCaller
    {

        public DapperPlaceRepository(DatabaseOptions databaseOptions) : base(databaseOptions)
        {


        }

        public async Task<IEnumerable<PlaceByCenterIDOutput>> GetPlacesByCenterID(IPlaceByCenterIDInput input)
        {


            var query = $" EXEC [Global].[GetParentOfAllMahalMarkazPakhsh] @ccmarkaz";
            var result = await dbConnection.QueryAsync<PlaceByCenterIDOutput>(query, input);


            return result;


        }

       
    }
}

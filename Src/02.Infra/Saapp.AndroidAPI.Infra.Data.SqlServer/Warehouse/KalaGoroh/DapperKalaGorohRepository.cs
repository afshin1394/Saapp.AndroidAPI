using Dapper;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Warehouse.KalaGoroh
{
    public class DapperKalaGorohRepository : DapperBaseRepository, IKalaGorohServiceCaller
    {

        public DapperKalaGorohRepository(DatabaseOptions databaseOptions) : base(databaseOptions)
        {

        }
        public async Task<IEnumerable<KalaGorohOutput>> GetKalaGoroh(IKalaGorohInput input)
        {


            var query = $" EXEC [Tablet].[Get__KalaGoroh] @ccGoroh";
            var result =  await dbConnection.QueryAsync<KalaGorohOutput>(query, input);
            return result;
          

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saapp.AndroidAPI.Core.Domain;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using Dapper;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Warehouse.Goroh
{
    public class DapperGroupRepository : DapperBaseRepository,IGroupServiceCaller
    {
        public DapperGroupRepository(DatabaseOptions databaseOptions) : base(databaseOptions)
        {

        }

        public async Task<IEnumerable<GroupOutput>> GetGoroh(IGroupInput input)
        {


            var query = $" EXEC [Tablet].[Get_Goroh] ";
            var result = await dbConnection.QueryAsync<GroupOutput>(query, input);
            
            return result;


        }
    }
}

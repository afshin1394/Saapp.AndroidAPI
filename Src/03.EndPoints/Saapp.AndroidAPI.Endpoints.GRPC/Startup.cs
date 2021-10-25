using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.Queries;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.ApplicationService.Warehouse.KalaGoroh.ViewModels.Inputs;
using System.Collections.Generic;
using Saapp.AndroidAPI.Core.Domain.Warehouse.KalaGoroh.QueryModels;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Warehouse.KalaGoroh;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Common;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Warehouse.Goroh;
using Saapp.AndroidAPI.Core.ApplicationService.Global.Group.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels.Outputs;

using Saapp.AndroidAPI.Core.Domain.Global.Group.QueryModels;
using Saapp.AndroidAPI.Core.ApplicationService.Global.Group.Queries;
using Saapp.AndroidAPI.Endpoints.GRPC.Global.Group.Protos;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Global.SellCenter;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels;
using Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.Queries;
using Saapp.AndroidAPI.Core.Domain.Global.SellCenter.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.ApplicationService.Global.SellCenter.ViewModels.Inputs;
using Saapp.AndroidAPI.Endpoints.GRPC.Global.SellCenter.Protos;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Amargar.Place;
using Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.ApplicationService.Tablet.StatisticGoods.Queries;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.Domain.Tablet.StatisticGoods.QueryModels;
using Saapp.AndroidAPI.Endpoints.GRPC.Tablet.StatisticGoods.Protos;
using Saapp.AndroidAPI.Infra.Data.SqlServer.Tablet.StatisticGoods;
using Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.Queries;
using Saapp.AndroidAPI.Core.ApplicationService.Amargar.PlaceByCenterID.ViewModels.Inputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels.Outputs;
using Saapp.AndroidAPI.Core.Domain.Amargar.PlaceByCenterID.QueryModels;
using Saapp.AndroidAPI.Endpoints.GRPC.Amargar.PlaceByCenterID.Protos;

namespace Saapp.AndroidAPI.Endpoints.GRPC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(opt =>
            {
                opt.EnableDetailedErrors = true;
            });
            
            var dbOptions = new DatabaseOptions();
            services.AddSingleton(dbOptions);
            services.AddMediatR(typeof(Startup));

            services.AddTransient<IRequestHandler<KalaGorohInputViewModel, IEnumerable<KalaGorohOutput>>, GetKalaGorohHandler>();
            services.AddTransient<IRequestHandler<GroupInputViewModel, IEnumerable<GroupOutput>>, GetGroupHandler>();
            services.AddTransient<IRequestHandler<SellCenterInputViewModel, IEnumerable<SellCenterOutput>>, GetSellCenterHandler>();
            services.AddTransient<IRequestHandler<PlaceByCenterIDInputViewModel, IEnumerable<PlaceByCenterIDOutput>>, GetPlaceByCenterIDHandler>();
            services.AddTransient<IRequestHandler<StatisticGoodsInputViewModel, IEnumerable<StatisticGoodsOutput>>, GetStatisticGoodsHandler>();



            services.AddScoped<IKalaGorohServiceCaller, DapperKalaGorohRepository>();
            services.AddScoped<IGroupServiceCaller, DapperGroupRepository>();
            services.AddScoped<ISellCenterServiceCaller, DapperSellCenterRepository>();
            services.AddScoped<IPlaceByCenterIDServiceCaller, DapperPlaceRepository>();
            services.AddScoped<IStatisticGoodsServiceCaller, DapperStatisticGoodsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<KalaGorohService>();
                endpoints.MapGrpcService<GroupService>();
                endpoints.MapGrpcService<SellCenterService>();
                endpoints.MapGrpcService<PlaceByCenterIDService>();
                endpoints.MapGrpcService<StatisticGoodsService>();


                endpoints.MapGet("/Grpc/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

        
        }
    }
}

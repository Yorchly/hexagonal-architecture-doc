﻿using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IGetAllVehiclePresenter, GetAllVehiclesPresenter>();
            services.AddScoped<ICreateVehiclePresenter, CreateVehiclePresenter>();
            services.AddScoped<IRentVehiclePresenter, RentVehiclePresenter>();

            return services;
        }
    }
}

﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLLInitializer
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddSingleton<UserManager>();
            return services;
        }
    }
}

using System;
using FirebaseApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WhatsTroll.Api.Authorization;
using WhatsTroll.Api.Configuration;
using WhatsTroll.Api.Hubs.PlayerHub;
using WhatsTroll.Api.Services;
using WhatsTroll.Api.Services.SPlaylistMedia;
using WhatsTroll.Data.Context;
using WhatsTroll.Data.Model;
using YoutubeDataApi;

namespace WhatsTroll.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        ILogger<Startup> _logger;

        public Startup(IHostingEnvironment env, IConfiguration config,
            ILogger<Startup> logger)
        {
            _env = env;
            _config = config;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            ConfigureAuth(services);
            ConfigureCors(services);

            services.AddSignalR();

            services.AddDbContext<DataContext>();
            services.AddDbContext<PlaylistMediaContext>();

            services.AddSingleton<FirebaseController>();
            services.AddSingleton<YoutubeDataService>();
            services.AddSingleton<YoutubeManager>();
            //services.AddSingleton<StorageService>();

            services.AddSingleton<MediaService>();
            services.AddSingleton<PlaylistMediaService>();

            //services.AddHostedService<ChannelWorkerHostedService>();
            services.AddSingleton<ChannelWorkerService>();
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();

            app.UseSignalR(route =>
            {
                route.MapHub<PlayerHub>("/PlayerHub");
            });
        }



        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(_config.GetValue<string>("APP_HOST"));
                    });
            });
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                //paramsValidation.ValidAudience = tokenConfigurations.Audience;
                //paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateAudience = false;
                paramsValidation.ValidateIssuer = false;

                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ChannelManage", policy =>
                    policy.Requirements.Add(new ChannelManageRequirement()));
            });
            services.AddSingleton<IAuthorizationHandler, ChannelManageAuthorizationHandler>();

        }

    }
}

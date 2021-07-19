using Amazon;
using Amazon.SQS;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitSimpleExample
{
    public static class Extensions
    {
        public static void AddMassTransitBus(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingAmazonSqs((context, cfg) =>
                {
                    cfg.Host("us-east-2", h =>
                    {
                        h.AccessKey("your-iam-access-key");
                        h.SecretKey("your-iam-secret-key");
                    });
                });
            });
        }
    }
}

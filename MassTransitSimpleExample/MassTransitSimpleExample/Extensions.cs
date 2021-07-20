using Amazon.SQS;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

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
                    //// Yandex Message Queue
                    //AmazonSQSConfig _sqsConfig = new AmazonSQSConfig
                    //{
                    //    ServiceURL = "https://message-queue.api.cloud.yandex.net",
                    //    AuthenticationRegion = "ru-central1"
                    //};
                    //cfg.Host("ru-central1", h =>
                    //{
                    //    h.Config(_sqsConfig);
                    //    h.AccessKey("your-iam-access-key");
                    //    h.SecretKey("your-iam-secret-key");
                    //});

                    // Mail.ru Cloud Solutions
                    AmazonSQSConfig _sqsConfig = new AmazonSQSConfig
                    {
                        ServiceURL = "https://sqs.mcs.mail.ru"
                    };
                    cfg.Host("ru-central1", h =>
                    {
                        h.Config(_sqsConfig);
                        h.AccessKey("your-iam-access-key");
                        h.SecretKey("your-iam-secret-key");
                    });

                    //// Amazon SQS
                    //cfg.Host("us-east-2", h =>
                    //{
                    //    h.AccessKey("your-iam-access-key");
                    //    h.SecretKey("your-iam-secret-key");
                    //});
                });
            });
        }
    }
}

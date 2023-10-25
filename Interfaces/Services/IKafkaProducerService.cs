using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace POC.Service.Interfaces.Services
{
    public interface IKafkaProducerService : IHostedService, IDisposable
    {
        Task<bool>SenderMessageKafka(string message, string topic = null);
    }
}
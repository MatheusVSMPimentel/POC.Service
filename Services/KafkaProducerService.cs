using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using POC.Service.Interfaces.Services;

using Confluent.Kafka;

namespace POC.Service.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly string kafkaBroker = "localhost"; // Substitua pelo endereço do seu broker Kafka
        private readonly int kafkaPort = 9092; // Porta padrão do Kafka
        private readonly ILogger<KafkaProducerService> _logger;
        private IProducer<Null, string> _producer;

        public KafkaProducerService(/* ILogger<KafkaProducerService> logger */)
        {
            /* _logger = logger; */

            var config = new ProducerConfig
            {
                BootstrapServers = $"{kafkaBroker}:{kafkaPort}"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task<bool> SenderMessageKafka(string message, string topic = null)
        {

            try
            {
                var deliveryReport = await _producer.ProduceAsync(topic ?? "TestTopic", new Message<Null, string> { Value = message });
                Console.WriteLine($"Mensagem entregue em: {deliveryReport.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Erro: {e.Error.Reason}");
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return false;
            }
            finally
            {
                Dispose();
            }
            return true;

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Iniciar o serviço de produtor (se necessário)
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fechando o produtor Kafka...");
            _producer?.Dispose();
            _logger.LogInformation("Produtor Kafka fechado.");
        }


        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}

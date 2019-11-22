using log4net;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace BusinessObjects.Supports
{
    public class RabbitHelper
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IModel queueChannel;
        private EventingBasicConsumer consumer;
        public int Worker;

        public void Initialize()
        {
            try
            {
                queueChannel = (new ConnectionFactory() { Uri = new Uri(AppConfig.RABBIT_CONNECTION) }).CreateConnection().CreateModel();

                queueChannel.CreateBasicProperties().Persistent = true;
                queueChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_SUCCESS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_ERROR, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_INCOM, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_NEO, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_SOUTH, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VIETGUYS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VIVAS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VMG, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VNPT, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_IRIS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_MFS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VIETTEL, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VMG_AMS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_SOUTH_AMS, durable: true, exclusive: false, autoDelete: false, arguments: null);
                queueChannel.QueueDeclare(queue: AppConfig.QUEUE_PARTNER_VIETGUYS_AMS, durable: true, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                logger.Error("Initialize", ex);
                throw ex;
            }
        }

        public void PublishMessage(string queueName, string message)
        {
            try
            {
                queueChannel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(message));
            }
            catch (Exception ex)
            {
                logger.Error("PublishMessage", ex);
            }
        }

        public void ReceiveMessage(string queueName)
        {
            try
            {
                consumer = new EventingBasicConsumer(queueChannel);
                consumer.Received += EventReceiveSMS;
                queueChannel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
            }
            catch (Exception ex)
            {
                logger.Error("ReceiveMessage", ex);
            }
        }

        private void EventReceiveSMS(object sender, BasicDeliverEventArgs ea)
        {
            OnReceiveEventHandler(ea);
            queueChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }

        public delegate void ReceiveEventHandler(string message, int worker);
        public event ReceiveEventHandler ReceiveEvent;
        protected void OnReceiveEventHandler(EventArgs args)
        {
            try
            {
                var ea = (BasicDeliverEventArgs)args;
                var message = Encoding.UTF8.GetString(ea.Body);
                if (ReceiveEvent != null)
                {
                    ReceiveEvent(message, this.Worker);
                }
            }
            catch (Exception ex)
            {
                logger.Error("OnReceiveEventHandler", ex);
            }
        }

        public void StopEventReceiveSMS()
        {
            consumer.Received -= EventReceiveSMS;
        }
    }
}

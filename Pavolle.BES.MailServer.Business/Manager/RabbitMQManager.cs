using log4net;
using Newtonsoft.Json;
using Pavolle.BES.MailServer.ViewModels.Request;
using Pavolle.Core.Utils;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager
{
    public class RabbitMQManager : Singleton<RabbitMQManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(RabbitMQManager));

        ConnectionFactory _connectionFactory;
        IConnection _connection;
        IModel _channel;


        string _username;
        string _password;
        string _hostname;
        string _vhost;
        string _port;
        string _logRoutingKey;
        string _logQueueKey;
        string _logErrorRoutingKey;
        string _logErrorQueueKey;
        string _exchangeName;

        private RabbitMQManager()
        {

            _log.Debug(nameof(RabbitMQManager) + " Initialize");
            _connectionFactory = new ConnectionFactory();
        }

        public bool Initilize(string username, string password, string hostname, string vhost, string port, string exchangeName, string logRoutingKey, string logQueueKey, string logErrorRoutingKey, string logErrorQueueKey)
        {
            _username = username;
            _password = password;
            _hostname = hostname;
            _vhost = vhost;
            _port = port;
            _logRoutingKey = logRoutingKey;
            _logQueueKey = logQueueKey;
            _logErrorRoutingKey = logErrorRoutingKey;
            _logErrorQueueKey = logErrorQueueKey;
            _exchangeName = exchangeName;


            _connectionFactory.UserName = _username;
            _connectionFactory.Password = _password;
            _connectionFactory.HostName = _hostname;
            try
            {
                _connectionFactory.Port = Convert.ToInt32(_port);
            }
            catch (Exception)
            {
                _connectionFactory.Port = 5672;
            }

            if (_vhost == "/")
            {
                _vhost = null;
            }
            else
            {
                _vhost = vhost;
                _connectionFactory.VirtualHost = _vhost;
            }

            bool status = OpenChannel();
            if (status)
            {
                status = DeclareQueue();
            }
            return status;
        }

        public bool ProduceLogMessage(MailRequest request)
        {
            var response = true;
            try
            {
                if (_channel == null || _channel.IsClosed)
                {
                    OpenChannel();
                }

                string messageString = JsonConvert.SerializeObject(request);
                byte[] messageBodyBytes = Encoding.UTF8.GetBytes(messageString);

                IBasicProperties props = _channel.CreateBasicProperties();
                props.ContentType = "javascript/json";
                props.DeliveryMode = 2;
                _channel.BasicPublish(_exchangeName, _logRoutingKey, props, messageBodyBytes);
                _log.Info("Message sended to Rabbit MQ. Message=> " + messageString);
            }
            catch (Exception ex)
            {
                _log.Error("RabbitMQ error: Log Request Message could not write to queue! Message: " + JsonConvert.SerializeObject(request) + " Error: " + ex);
                response = false;
            }

            return response;
        }

        private bool DeclareQueue()
        {
            try
            {
                _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);

                _channel.QueueDeclare(_logQueueKey, false, false, true, null);
                _channel.QueueDeclare(_logErrorQueueKey, false, false, true, null);

                _channel.QueueBind(_logQueueKey, _exchangeName, _logRoutingKey, null);
                _channel.QueueBind(_logErrorQueueKey, _exchangeName, _logErrorRoutingKey, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool OpenChannel()
        {
            try
            {
                if (_connection == null || !_connection.IsOpen)
                {
                    _connection = _connectionFactory.CreateConnection();
                }
                _channel = _connection.CreateModel();
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Rabbit MQ bağlantısında beklenmedik hata oluştu! Hata: " + ex);
                return false;
            }
        }
    }
}

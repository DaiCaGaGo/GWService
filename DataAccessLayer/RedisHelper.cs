using DataAccessLayer.Supports;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RedisHelper
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static ConnectionMultiplexer Connection => LazyConnection.Value;

        private static IDatabase dbRedis => Connection.GetDatabase();

        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(DALConst.REDIS_CONNECTION);
        });

        private static bool CheckConnectionRedis()
        {
            bool isConnected = Connection.IsConnected;
            if (!isConnected) logger.Error(DALConst.A("CheckConnectionRedis", "Not connection!", DALConst.REDIS_CONNECTION));
            return isConnected;
        }

        public static bool Set(string key, string value)
        {
            if (CheckConnectionRedis()) return dbRedis.StringSet(key, value);
            return false;
        }

        public static async Task<bool> SetAsync(string key, string value)
        {
            if (CheckConnectionRedis()) return await dbRedis.StringSetAsync(key, value);
            return false;
        }

        public static string Get(string key)
        {
            if (CheckConnectionRedis()) return dbRedis.StringGet(key);
            return String.Empty;
        }

        public static async Task<string> GetAsync(string key)
        {
            if (CheckConnectionRedis()) return await dbRedis.StringGetAsync(key);
            return String.Empty;
        }

        public static bool Delete(string key)
        {
            if (CheckConnectionRedis()) return dbRedis.KeyDelete(key);
            return false;
        }

        public static bool KeyExists(string key)
        {
            if (CheckConnectionRedis()) return dbRedis.KeyExists(key);
            return false;
        }

        public static void Publish(string chanel, string message)
        {
            if (CheckConnectionRedis())
                Connection.GetSubscriber().Publish(chanel, message);
        }

        public static void Subscribe(string chanel)
        {
            if (CheckConnectionRedis())
                Connection.GetSubscriber().Subscribe(chanel, (channel, message) => OnReceiveEventHandler(message));
        }

        public static void Unsubscribe(string chanel)
        {
            if (CheckConnectionRedis())
                Connection.GetSubscriber().Unsubscribe(chanel);
        }

        public delegate void ReceiveEventHandler(string messages);
        public static event ReceiveEventHandler ReceiveEvent;
        protected static void OnReceiveEventHandler(string message)
        {
            try
            {
                if (ReceiveEvent != null)
                {
                    ReceiveEvent(message);
                }
            }
            catch (Exception ex)
            {
                logger.Error("OnReceiveEventHandler", ex);
            }
        }
    }
}

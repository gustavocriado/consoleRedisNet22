using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisConsoleNet22
{
    class Program
    {
        static void Main(string[] args)
        {
            var coon = ConnectionMultiplexer.Connect("20.225.241.127");

            var db = coon.GetDatabase();

            var sub = coon.GetSubscriber();

            sub.Subscribe("perguntas").OnMessage(m => {
                string sla = m.Message;
                Console.WriteLine(sla);
                string resposta = Console.ReadLine();
                db.HashSet(sla.Substring(0, sla.IndexOf(":")), "Marotos", resposta);
            });
            Task.Delay(2000000000).Wait();
        }
    }
}

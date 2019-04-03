
using BlockchainLib;
using Newtonsoft.Json;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            Blockchain fCoin = new Blockchain();
            fCoin.CreateTransaction(new Transaction("felipe", "bruno", 10));
            fCoin.ProcessPendingTransactions("batata");
            Console.WriteLine(JsonConvert.SerializeObject(fCoin, Formatting.Indented));

            var endTime = DateTime.Now;
            Console.WriteLine($"Duration: {endTime -startTime}");

            //Console.WriteLine($"FCoin is Valid: {fCoin.IsValid()}");
            //fCoin.Chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";
            //Console.WriteLine($"FCoin is Valid: {fCoin.IsValid()}");
            Console.ReadKey();
        }
    }
}

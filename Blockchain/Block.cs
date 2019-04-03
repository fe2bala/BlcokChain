using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainLib
{
    public class Block
    {
        private DateTime now;
        private IList<Transaction> pendingTransactions;

        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public DateTime DateTime { get; set; }
        public int Nonce { get; set; } = 0;

        public string Hash { get; set; }

        public Block(DateTime dateTime, string previousHash, IList<Transaction> pendingTransactions)
        {
            Index = 0;
            DateTime = dateTime;
            this.pendingTransactions = pendingTransactions;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{DateTime}-{PreviousHash ?? ""}-{JsonConvert.SerializeObject(Transactions)}-{Nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }
        public void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (this.Hash == null || this.Hash.Substring(0, difficulty) != leadingZeros)
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
            }
        }
    }
}

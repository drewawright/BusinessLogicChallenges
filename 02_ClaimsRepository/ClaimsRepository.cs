using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claimsQueue = new Queue<Claim>();



        public void AddClaimToQueue(Claim claim)
        {
            _claimsQueue.Enqueue(claim);
        }

        public Queue<Claim> GetClaimsList()
        {
            return _claimsQueue;
        }

        public Claim GetClaimFromQueue()
        {
            Claim claim = _claimsQueue.Peek();
            return claim;
        }

        public void ActOnClaim()
        {
            _claimsQueue.Dequeue();
        }
    }
}

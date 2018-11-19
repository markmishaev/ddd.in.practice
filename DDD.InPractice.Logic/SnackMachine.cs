using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.InPractice.Logic
{
    public sealed class SnackMachine
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }


        public void InsertMoney(Money money)
        {
            MoneyInside += money;
        }

        public void ReturnMoney()
        {
            //should be implemented
        }

        public void BuySnack()
        {
            MoneyInTransaction += MoneyInside;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.InPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set;    }

        public decimal Amount =>
                 OneCentCount * 0.01m +
                    TenCentCount * 0.1m +
                    QuarterCount * 0.25m +
                    OneDollarCount +
                    FiveDollarCount * 5m +
                    TwentyDollarCount * 20m;

        public Money(int oneCentCount, int tenCentCount,
                                int quarterCount, int oneDollarCount,
                                int fiveDollarCount, int twentyDollarCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quarterCount < 0)
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator -(Money money1, Money money2)
        {
            Money difference = new Money(
               money1.OneCentCount -= money2.OneCentCount,
               money1.TenCentCount -= money2.TenCentCount,
               money1.QuarterCount -= money2.QuarterCount,
               money1.OneDollarCount -= money2.OneDollarCount,
               money1.FiveDollarCount -= money2.FiveDollarCount,
               money1.TwentyDollarCount -= money2.TwentyDollarCount
               );

            return difference;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount += money2.OneCentCount,
                money1.TenCentCount += money2.TenCentCount,
                money1.QuarterCount += money2.QuarterCount,
                money1.OneDollarCount += money2.OneDollarCount,
                money1.FiveDollarCount += money2.FiveDollarCount,
                money1.TwentyDollarCount += money2.TwentyDollarCount
                );

            return sum;
        }

        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount
                && QuarterCount == other.QuarterCount
                && OneDollarCount == other.OneDollarCount
                && FiveDollarCount == other.FiveDollarCount
                && TwentyDollarCount == other.TwentyDollarCount;
        }

        public override int GetHashCodeCore()
        {
            int hashCode = OneDollarCount;
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;

            return hashCode;
        }
    }
}

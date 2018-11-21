using DDD.InPractice.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace DDD.InPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void sum_of_two_money_produces_correct_result()
        {
            //Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act
            Money sum = money1 + money2;

            //Assert
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void two_money_instances_are_equal_if_contain_the_same_money_amount()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void two_money_instances_are_not_equal_if_contain_different_amount()
        {
            Money dollar = new Money(0, 0, 0, 10, 0, 0);
            Money hundredCents = new Money(100, 0, 0, 0, 0, 0);

            dollar.Should().NotBe(hundredCents);
            dollar.GetHashCode().Should().NotBe(hundredCents.GetHashCode());
        }

        [Theory]
        [InlineData(-1,0,0,0,0,0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -5, 0)]
        [InlineData(0, 0, 0, 0, 0, -6)]
        public void cannot_create_money_with_negative_value(int oneCentCount, int tenCentCount,
                                int quarterCount, int oneDollarCount,
                                int fiveDollarCount, int twentyDollarCount)
        {
            Action action = () => new Money(
               oneCentCount,
               tenCentCount,
               quarterCount,
               oneDollarCount,
               fiveDollarCount,
               twentyDollarCount
               );

            action.Should().Throw<InvalidOperationException>();
        }
    }
}

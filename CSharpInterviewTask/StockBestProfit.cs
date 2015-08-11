using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpInterviewTask
{
    /// <summary>
    /// I have an array stock_prices_yesterday where:
    /// The indices are the time in minutes past trade opening time, which was 9:30am local time.
    /// The values are the price in dollars of Apple stock at that time.
    /// For example, the stock cost $500 at 10:30am, so stock_prices_yesterday[60] = 500.
    /// Write an efficient algorithm for computing the best profit I could have made from 1 purchase and 1 sale of 1 Apple stock yesterday.
    /// 
    /// No "shorting"—you must buy before you sell. You may not buy and sell in the same time step (at least 1 minute must pass).
    /// </summary>
    /// <remarks>
    /// Gotchas
    /// It is not sufficient to simply take the difference between the highest price and the lowest price, because the highest price may come before the lowest price. You must buy before you sell.
    /// What if the stock value goes down all day? In that case, the best profit will be negative.
    /// 
    /// https://www.interviewcake.com/question/stock-price
    /// </remarks>
    [TestClass]
    public class StockPricesYesterday
    {
        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual(0, CalcBestProfit(new int[] { }));
        }

        [TestMethod]
        public void Single()
        {
            Assert.AreEqual(0, CalcBestProfit(new int[] { 1 }));
        }

        [TestMethod]
        public void NoProfit()
        {
            // You have to buy/sell
            Assert.AreEqual(-1, CalcBestProfit(new int[] { 15, 8, 3, 2, 1 }));
        }

        [TestMethod]
        public void FirstBuyLastSell()
        {
            Assert.AreEqual(4, CalcBestProfit(new int[] { 1, 4, 3, 2, 5 }));
        }

        [TestMethod]
        public void FirstBuySecondSell()
        {
            Assert.AreEqual(3, CalcBestProfit(new int[] { 2, 5, 1, 2, 3 }));
        }

        [TestMethod]
        public void LastBuySell()
        {
            Assert.AreEqual(3, CalcBestProfit(new int[] { 3, 5, 4, 2, 5 }));
        }

        public int CalcBestProfit(int[] data)
        {
            if (data.Length < 2) return 0;
            int minBuy = data[0];
            int maxProfit = int.MinValue;
            for (int i = 1; i < data.Length; i++)
            {
                int curProfit = data[i] - minBuy;
                if (curProfit > maxProfit)
                    maxProfit = curProfit;
                if (minBuy > data[i])
                    minBuy = data[i];
            }
            return maxProfit;
        }
    }
}

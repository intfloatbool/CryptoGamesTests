using EthWebPoker.Games.Dices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoGamesTests.Games.Dices
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void DiceReturnsCorrectValues()
        {
            var dice = new DiceCubes();
            var checkingCount = 1000;
            var winningValuesOfFirstDice = new List<int>();
            var winningValuesOfSecondDice = new List<int>();

            for (int i = 0; i < checkingCount; i++)
            {
                var result = dice.Throw();

                if (!winningValuesOfFirstDice.Contains(result.X))
                    winningValuesOfFirstDice.Add(result.X);
                if (!winningValuesOfSecondDice.Contains(result.Y))
                    winningValuesOfSecondDice.Add(result.Y);
            }

            Assert.IsTrue(winningValuesOfFirstDice.Contains(1));
            Assert.IsTrue(winningValuesOfFirstDice.Contains(2));
            Assert.IsTrue(winningValuesOfFirstDice.Contains(3));
            Assert.IsTrue(winningValuesOfFirstDice.Contains(4));
            Assert.IsTrue(winningValuesOfFirstDice.Contains(5));
            Assert.IsTrue(winningValuesOfFirstDice.Contains(6));

            Assert.IsTrue(winningValuesOfSecondDice.Contains(1));
            Assert.IsTrue(winningValuesOfSecondDice.Contains(2));
            Assert.IsTrue(winningValuesOfSecondDice.Contains(3));
            Assert.IsTrue(winningValuesOfSecondDice.Contains(4));
            Assert.IsTrue(winningValuesOfSecondDice.Contains(5));
            Assert.IsTrue(winningValuesOfSecondDice.Contains(6));
        }
    }
}

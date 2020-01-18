using EthWebPoker.Games;
using EthWebPoker.Games.Dices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void DiceGameResultPlayer1_Win()
        {
            var diceGame = new DiceGame();
            var player1 = diceGame.GetPlayerByType(PlayerType.PLAYER_1);
            var player2 = diceGame.GetPlayerByType(PlayerType.PLAYER_2);

            player1.DiceCubes.ExternalResult = new DiceCubes.DiceResult(6, 4);
            player2.DiceCubes.ExternalResult = new DiceCubes.DiceResult(3, 1);
            diceGame.Start();

            var winners = diceGame.Winners.ToList();
            Assert.AreEqual(10, player1.GetSum());
            Assert.AreEqual(4, player2.GetSum());
            Assert.AreEqual(1, winners.Count);
            Assert.IsTrue(winners.Contains(player1));
        }

        [TestMethod]
        public void DiceGameResultPlayer2_Win()
        {
            var diceGame = new DiceGame();
            var player1 = diceGame.GetPlayerByType(PlayerType.PLAYER_1);
            var player2 = diceGame.GetPlayerByType(PlayerType.PLAYER_2);

            player1.DiceCubes.ExternalResult = new DiceCubes.DiceResult(2, 1);
            player2.DiceCubes.ExternalResult = new DiceCubes.DiceResult(4, 5);
            diceGame.Start();

            var winners = diceGame.Winners.ToList();
            Assert.AreEqual(3, player1.GetSum());
            Assert.AreEqual(9, player2.GetSum());
            Assert.AreEqual(1, winners.Count);
            Assert.IsTrue(winners.Contains(player2));
        }

        [TestMethod]
        public void DiceGameResultBothPlayers_Win()
        {
            var diceGame = new DiceGame();
            var player1 = diceGame.GetPlayerByType(PlayerType.PLAYER_1);
            var player2 = diceGame.GetPlayerByType(PlayerType.PLAYER_2);

            player1.DiceCubes.ExternalResult = new DiceCubes.DiceResult(4, 4);
            player2.DiceCubes.ExternalResult = new DiceCubes.DiceResult(3, 5);
            diceGame.Start();

            var winners = diceGame.Winners.ToList();
            Assert.AreEqual(8, player1.GetSum());
            Assert.AreEqual(8, player2.GetSum());
            Assert.AreEqual(2, winners.Count);
            Assert.IsTrue(winners.Contains(player1));
            Assert.IsTrue(winners.Contains(player2));
        }
    }
}

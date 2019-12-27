using EthWebPoker.Games.CardGames;
using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoGamesTests.Games.Poker
{
    [TestClass]
    public class HoldemHelperTests
    {
        [TestMethod]
        public void PairsSearcherTest()
        {
            //Arrange
            var tableCards = new List<Card>()
            {
                //player cards
                new Card(Rank.ACE, Suit.CLUBS), //<< part of the Ace pair: 1
                new Card(Rank.FOUR, Suit.SPADES), //<< part of the Four pair: 1

                //table
                new Card(Rank.JACK, Suit.SPADES),
                new Card(Rank.EIGHT, Suit.DIAMONDS),
                new Card(Rank.TWO, Suit.CLUBS),
                new Card(Rank.FOUR, Suit.HEARTS), //<< part of the Four pair: 2
                new Card(Rank.ACE, Suit.DIAMONDS) //<< part of the Ace pair: 2
            };

            var countOfPairs = 2;

            //Act
            var pairs = HoldemHelper.GetPairsFromCollection(tableCards).ToList();

            //Assert
            Assert.IsNotNull(pairs);
            Assert.AreEqual(countOfPairs, pairs.Count);
        }
    }
}

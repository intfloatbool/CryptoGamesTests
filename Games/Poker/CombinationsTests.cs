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
    public class CombinationsTests
    {
        [TestMethod]
        public void HighCardCombo()
        {
            var playerCard1 = new Card(Rank.KING, Suit.SPADES);
            var playerCard2 = new Card(Rank.FOUR, Suit.HEARTS);

            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1, // << Kicker
                playerCard2,

                //Table
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.JACK, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.SIX, Suit.DIAMONDS)
            };

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);


            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(comboCards.Cards.Contains(playerCard1));
            Assert.AreEqual<Combo>(Combo.HIGH_CARD, comboCards.Combo);
        }

        [TestMethod]
        public void OnePairCombo()
        {
            var playerCard1 = new Card(Rank.KING, Suit.SPADES);
            var playerCard2 = new Card(Rank.FOUR, Suit.HEARTS);

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.JACK, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.CLUBS),
                new Card(Rank.KING, Suit.DIAMONDS) // << pair of cards
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1, // << Kicker
                playerCard2,          
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);


            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.AreEqual<Combo>(Combo.ONE_PAIR, comboCards.Combo);
        }

    }
}

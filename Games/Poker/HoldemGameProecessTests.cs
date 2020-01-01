using EthWebPoker.Games.CardGames.CardBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoGamesTests.Games.Poker
{
    [TestClass]
    public class HoldemGameProecessTests
    {
        [TestMethod]
        public void DeckOfCardsCorrectGenerationTests()
        {
            //Arrange
            var deckOfCards = DeckOfCards.CreateDefault();
            var cards = deckOfCards.DeckCards;

            var suitsCount = 4;
            var ranksCount = 13;
            var cardsCount = ranksCount * suitsCount;

            //Act
            deckOfCards.RefershDeck(false);

            var spadesCards = cards.Where(c => c.Suit == Suit.SPADES);
            var heartsCards = cards.Where(c => c.Suit == Suit.HEARTS);
            var diamondsCards = cards.Where(c => c.Suit == Suit.DIAMONDS);
            var clubsCards = cards.Where(c => c.Suit == Suit.CLUBS);

            //Assert
            Assert.IsNotNull(deckOfCards);
            Assert.IsNotNull(cards);
            Assert.AreEqual(cardsCount, cards.Count);
            Assert.AreEqual(ranksCount, spadesCards.Count());
            Assert.AreEqual(ranksCount, heartsCards.Count());
            Assert.AreEqual(ranksCount, diamondsCards.Count());
            Assert.AreEqual(ranksCount, clubsCards.Count());
        }
    }
}

using EthWebPoker.Games.CardGames;
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
            
            var suitsCount = 4;
            var ranksCount = 13;
            var cardsCount = ranksCount * suitsCount;

            //Act
            deckOfCards.RefershDeck();
            var cards = deckOfCards.DeckCards;

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

        [TestMethod]
        public void CardPlayerTest()
        {
            var player1 = new CardPlayer();
            var player2 = new CardPlayer();

            var card1 = new Card(Rank.ACE, Suit.HEARTS);
            var card2 = new Card(Rank.TWO, Suit.SPADES);

            player1.AddCard(card1);
            player1.AddCard(card2);

            player2.AddCard(new Card(Rank.SEVEN, Suit.CLUBS));
            player2.AddCard(new Card(Rank.NINE, Suit.DIAMONDS));
            player2.FoldCards();

            Assert.IsTrue(player1.Cards.Contains(card1));
            Assert.IsTrue(player1.Cards.Contains(card2));
            Assert.IsFalse(player2.Cards.Any());

        }
    }
}

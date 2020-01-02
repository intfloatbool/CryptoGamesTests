using EthWebPoker.Games.CardGames;
using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
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

        [TestMethod]
        public void TableTest()
        {
            var table = new CardTable();
            table.AddCard(new Card(Rank.ACE, Suit.CLUBS));
            table.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            Assert.IsTrue(table.Cards.Any());
            Assert.AreEqual(table.Cards.Count, 2);
        }

        [TestMethod]
        public void CardDealerDealCardsTest()
        {
            var deck = DeckOfCards.CreateDefault();
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var dealer = new CardDealer(deck, new[] { p1, p2 }, tableCards);

            dealer.DealCards();

            Assert.IsNotNull(dealer.TempDeck);
            Assert.AreEqual(2, dealer.Players.Count);
            Assert.AreEqual(2, p1.Cards.Count);
            Assert.AreEqual(2, p2.Cards.Count);
            Assert.AreEqual(5, tableCards.Cards.Count);
        }
    }
}

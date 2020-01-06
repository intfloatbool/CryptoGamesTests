using EthWebPoker.Games.CardGames;
using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using EthWebPoker.Games.CardGames.HoldemPoker.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoGamesTests.Games.Poker
{
    [TestClass]
    public class HoldemMechanicsTests
    {
        [TestMethod]
        public void PlayersHasWinCombinationsAfterGameTest()
        {
            var p1 = new HoldemPlayer();
            var p2 = new HoldemPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            //P2 with four of kind: J-J-J-J
            //P2 with royal-flush: T-J-Q-K-A of Diamonds
            var playerCards = new Card[]
            {
                new Card(Rank.ACE, Suit.DIAMONDS),
                new Card(Rank.KING, Suit.DIAMONDS)
            };
            p1.AddCard(new Card(Rank.JACK, Suit.HEARTS));
            p1.AddCard(new Card(Rank.JACK, Suit.SPADES));

            p2.AddCard(playerCards[0]);
            p2.AddCard(playerCards[1]);
            var cardsOntable = new Card[]
            {
                new Card(Rank.JACK, Suit.DIAMONDS),
                new Card(Rank.QUEEN, Suit.DIAMONDS),
                new Card(Rank.JACK, Suit.CLUBS),
                new Card(Rank.TEN, Suit.DIAMONDS),
                new Card(Rank.TWO, Suit.CLUBS)
            };
            tableCards.AddCard(cardsOntable[0]);
            tableCards.AddCard(cardsOntable[1]);
            tableCards.AddCard(cardsOntable[2]);
            tableCards.AddCard(cardsOntable[3]);
            tableCards.AddCard(cardsOntable[4]);

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            var comboCards = p2.ComboCards;
            var isPlayerComboCardsHasComboCards =
                comboCards.Contains(playerCards[0]) &&
                comboCards.Contains(playerCards[1]) &&
                comboCards.Contains(cardsOntable[0]) &&
                comboCards.Contains(cardsOntable[1]) &&
                comboCards.Contains(cardsOntable[3]);

            var playerCombo = p2.Combination;

            Assert.IsNotNull(comboCards);
            Assert.IsNotNull(playerCombo);
            Assert.IsTrue(isPlayerComboCardsHasComboCards);
            Assert.AreEqual(Combo.ROYAL_FLUSH, playerCombo);
        }
    }
}

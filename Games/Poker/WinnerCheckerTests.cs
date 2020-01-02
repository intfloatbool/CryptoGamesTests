﻿using EthWebPoker.Games.CardGames;
using EthWebPoker.Games.CardGames.CardBase;
using EthWebPoker.Games.CardGames.HoldemPoker;
using EthWebPoker.Games.CardGames.HoldemPoker.Gameplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoGamesTests.Games.Poker
{
    [TestClass]
    public class WinnerCheckerTests
    {
        [TestMethod]
        public void OnePlayerWithHighestCard()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.THREE, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS)); // < HIGHEST CARD ON BOARD
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.NINE, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.HIGH_CARD, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithHighestCard()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.QUEEN, Suit.HEARTS)); // < HIGHEST CARD ON BOARD
            p1.AddCard(new Card(Rank.THREE, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS)); // < SAME HIGHEST CARD ON BOARD
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.NINE, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.HIGH_CARD, winnerContainer.Combination);
        }

        [TestMethod]
        public void OnePlayerWithOnePair()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.NINE, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.ONE_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayerWithOnePair()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p2.AddCard(new Card(Rank.QUEEN, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.NINE, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.ONE_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayerWithSamePair()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.JACK, Suit.SPADES));
            p2.AddCard(new Card(Rank.JACK, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.NINE, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.ONE_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void OnePlayerWithTwoPairs()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.KING, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.JACK, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.HEARTS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.TWO_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithTwoPairs()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.KING, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.QUEEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.JACK, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.HEARTS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.TWO_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithSameTwoPairs()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.JACK, Suit.CLUBS));
            p1.AddCard(new Card(Rank.KING, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.JACK, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.KING, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.QUEEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.JACK, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.CLUBS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.TWO_PAIR, winnerContainer.Combination);
        }

        [TestMethod]
        public void OnePlayerWithThreeOfKind()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.KING, Suit.CLUBS));
            p1.AddCard(new Card(Rank.KING, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.THREE, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.QUEEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.JACK, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.HEARTS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.THREE_OF_A_KIND, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithSameThreeOfKind()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.KING, Suit.CLUBS));
            p1.AddCard(new Card(Rank.FOUR, Suit.DIAMONDS));

            p2.AddCard(new Card(Rank.KING, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.FOUR, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.QUEEN, Suit.DIAMONDS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.HEARTS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.THREE_OF_A_KIND, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithThreeOfKindButOneHasBestKicker()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.KING, Suit.CLUBS));
            p1.AddCard(new Card(Rank.ACE, Suit.DIAMONDS)); // <<best kicker

            p2.AddCard(new Card(Rank.KING, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.FOUR, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.QUEEN, Suit.DIAMONDS));
            tableCards.AddCard(new Card(Rank.TWO, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.SEVEN, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.HEARTS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.THREE_OF_A_KIND, winnerContainer.Combination);
        }

        [TestMethod]
        public void OnePlayerWithStraight()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS)); // <<best kicker

            p2.AddCard(new Card(Rank.KING, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.STRAIGHT, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithStraight()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS)); // <<best kicker

            p2.AddCard(new Card(Rank.KING, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.JACK, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.QUEEN, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.STRAIGHT, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithSameStraight()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS)); // <<best kicker

            p2.AddCard(new Card(Rank.QUEEN, Suit.DIAMONDS));
            p2.AddCard(new Card(Rank.JACK, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.DIAMONDS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.CLUBS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.FOUR, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.STRAIGHT, winnerContainer.Combination);
        }

        [TestMethod]
        public void OnePlayerWithFlush()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.QUEEN, Suit.CLUBS));
            p1.AddCard(new Card(Rank.JACK, Suit.DIAMONDS)); // <<best kicker

            p2.AddCard(new Card(Rank.KING, Suit.HEARTS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.FLUSH, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithFlush()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.ACE, Suit.HEARTS));
            p1.AddCard(new Card(Rank.JACK, Suit.HEARTS)); // <<best kicker

            p2.AddCard(new Card(Rank.KING, Suit.HEARTS));
            p2.AddCard(new Card(Rank.TWO, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(1, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.AreEqual(Combo.FLUSH, winnerContainer.Combination);
        }

        [TestMethod]
        public void TwoPlayersWithSameFlush()
        {
            var p1 = new CardPlayer();
            var p2 = new CardPlayer();
            var tableCards = new CardTable();
            var winnerChecker = new WinnerChecker();

            p1.AddCard(new Card(Rank.THREE, Suit.HEARTS));
            p1.AddCard(new Card(Rank.FOUR, Suit.HEARTS)); // <<best kicker

            p2.AddCard(new Card(Rank.FIVE, Suit.HEARTS));
            p2.AddCard(new Card(Rank.SIX, Suit.HEARTS));

            tableCards.AddCard(new Card(Rank.TEN, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.NINE, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.EIGHT, Suit.HEARTS));
            tableCards.AddCard(new Card(Rank.KING, Suit.SPADES));
            tableCards.AddCard(new Card(Rank.TWO, Suit.DIAMONDS));

            var winnerContainer = winnerChecker.GetWinnerWithCombo(new[]
            {
                p1, p2
            }, tableCards);

            Assert.IsNotNull(winnerContainer);
            Assert.IsNotNull(winnerContainer.Players);
            Assert.IsNotNull(winnerContainer.Combination);
            Assert.AreEqual(2, winnerContainer.Players.Count);
            Assert.IsTrue(winnerContainer.Players.Contains(p1));
            Assert.IsTrue(winnerContainer.Players.Contains(p2));
            Assert.AreEqual(Combo.FLUSH, winnerContainer.Combination);
        }
    }
}
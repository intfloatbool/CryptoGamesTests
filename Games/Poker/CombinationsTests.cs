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
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));

            Assert.AreEqual<Combo>(Combo.HIGH_CARD, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(comboCards.Cards.Contains(playerCard1));
        }

        [TestMethod]
        public void OnePairCombo()
        {
            var countOfPair = 2;

            var playerCard1 = new Card(Rank.KING, Suit.SPADES); 
            var playerCard2 = new Card(Rank.FOUR, Suit.HEARTS); //first card

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.JACK, Suit.HEARTS),
                new Card(Rank.EIGHT, Suit.CLUBS),

                new Card(Rank.FOUR, Suit.DIAMONDS) // << Second Card, so pair
            };

            var pairedCardFromTable = tableCards[4];

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1, 
                playerCard2        
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);

            var isComboCardsContainsPair = comboCards.Cards.Contains(playerCard2) && comboCards.Cards.Contains(pairedCardFromTable);

            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.ONE_PAIR, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.AreEqual(comboCards.Cards.Count, countOfPair);
            Assert.IsTrue(isComboCardsContainsPair);
            
        }

        [TestMethod]
        public void TwoPairsCombo()
        {

            var playerCard1 = new Card(Rank.KING, Suit.SPADES); //first the King part of the pair
            var playerCard2 = new Card(Rank.FOUR, Suit.HEARTS); //first the Four part of the pair

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.JACK, Suit.HEARTS),
                new Card(Rank.KING, Suit.CLUBS), //second the King part of the pair
                new Card(Rank.FOUR, Suit.DIAMONDS) //second the Four part of the pair 
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[3]) &&
                resultCards.Contains(tableCards[4]);

            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.TWO_PAIR, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void ThreeOfAKindCombo()
        {
            var playerCard1 = new Card(Rank.KING, Suit.SPADES); //first the King part of the pair
            var playerCard2 = new Card(Rank.FOUR, Suit.HEARTS); 

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.THREE, Suit.SPADES),
                new Card(Rank.JACK, Suit.HEARTS),
                new Card(Rank.KING, Suit.CLUBS),  //second the Four part of the pair 
                new Card(Rank.KING, Suit.DIAMONDS) //third king
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(tableCards[3]) &&
                resultCards.Contains(tableCards[4]);

            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.THREE_OF_A_KIND, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void StraightCombo()
        {
            // K -> Q -> J -> T -> 9 straight
            var playerCard1 = new Card(Rank.KING, Suit.SPADES); //K
            var playerCard2 = new Card(Rank.QUEEN, Suit.HEARTS); //Q

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.NINE, Suit.SPADES), // 9
                new Card(Rank.TEN, Suit.HEARTS), // T
                new Card(Rank.JACK, Suit.CLUBS),  // J
                new Card(Rank.FOUR, Suit.DIAMONDS) 
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[1]) &&
                resultCards.Contains(tableCards[2]) &&
                resultCards.Contains(tableCards[3]);
            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.STRAIGHT, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void FlushCombo()
        {
            var playerCard1 = new Card(Rank.EIGHT, Suit.SPADES); // Spades 1 
            var playerCard2 = new Card(Rank.QUEEN, Suit.SPADES);  // Spades 2

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.NINE, Suit.SPADES), // Spades 3
                new Card(Rank.TWO, Suit.SPADES),  // Spades 4
                new Card(Rank.JACK, Suit.CLUBS),  
                new Card(Rank.THREE, Suit.SPADES)// Spades 5
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[1]) &&
                resultCards.Contains(tableCards[2]) &&
                resultCards.Contains(tableCards[4]);
            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.FLUSH, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void FullHouseCombo()
        {
            var playerCard1 = new Card(Rank.QUEEN, Suit.HEARTS); // Q 1
            var playerCard2 = new Card(Rank.QUEEN, Suit.SPADES);  // Q 2

            var tableCards = new Card[]
            {
                new Card(Rank.QUEEN, Suit.DIAMONDS), // Q 3
                new Card(Rank.NINE, Suit.CLUBS), 
                new Card(Rank.JACK, Suit.SPADES),  // Jack 1
                new Card(Rank.JACK, Suit.CLUBS),    // Jack 2
                new Card(Rank.THREE, Suit.HEARTS)
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);
            
            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);

            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[0]) &&
                resultCards.Contains(tableCards[2]) &&
                resultCards.Contains(tableCards[3]);

            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.FULL_HOUSE, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void FourOfKindCombo()
        {
            var playerCard1 = new Card(Rank.ACE, Suit.HEARTS); // A 1
            var playerCard2 = new Card(Rank.ACE, Suit.SPADES);  // A 2

            var tableCards = new Card[]
            {
                new Card(Rank.ACE, Suit.DIAMONDS), // A 3
                new Card(Rank.ACE, Suit.CLUBS), // A 4 
                new Card(Rank.JACK, Suit.SPADES),  
                new Card(Rank.EIGHT, Suit.CLUBS),    
                new Card(Rank.THREE, Suit.HEARTS)
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);

            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[0]) &&
                resultCards.Contains(tableCards[1]);

            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.FOUR_OF_A_KIND, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void StraightFlushCombo()
        {
            // K -> Q -> J -> T -> 9 straight flush of SPADES
            var playerCard1 = new Card(Rank.KING, Suit.SPADES); //K
            var playerCard2 = new Card(Rank.QUEEN, Suit.SPADES); //Q

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.NINE, Suit.SPADES), // 9
                new Card(Rank.TEN, Suit.SPADES), // T
                new Card(Rank.JACK, Suit.SPADES),  // J
                new Card(Rank.SEVEN, Suit.HEARTS)
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[1]) &&
                resultCards.Contains(tableCards[2]) &&
                resultCards.Contains(tableCards[3]);
            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.STRAIGHT_FLUSH, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }

        [TestMethod]
        public void RoyalFlushCombo()
        {
            // A -> K -> Q -> J -> T Royal flush of HEARTS
            var playerCard1 = new Card(Rank.ACE, Suit.HEARTS); // A
            var playerCard2 = new Card(Rank.KING, Suit.HEARTS); // K

            var tableCards = new Card[]
            {
                new Card(Rank.FIVE, Suit.DIAMONDS),
                new Card(Rank.TEN, Suit.HEARTS), // T
                new Card(Rank.JACK, Suit.HEARTS), // J
                new Card(Rank.QUEEN, Suit.HEARTS),  // Q
                new Card(Rank.SEVEN, Suit.CLUBS)
            };

            //Arrange
            var fullCardsOfTable = new List<Card>()
            {
                //Player hand
                playerCard1,
                playerCard2
            };

            fullCardsOfTable.AddRange(tableCards);

            //Act
            var comboCards = ComboChecker.Instance.CheckCombo(fullCardsOfTable);
            var resultCards = comboCards.Cards;
            var isComboCardsContainsCorrectly =
                resultCards.Contains(playerCard1) &&
                resultCards.Contains(playerCard2) &&
                resultCards.Contains(tableCards[1]) &&
                resultCards.Contains(tableCards[2]) &&
                resultCards.Contains(tableCards[3]);
            //Assert
            Assert.IsNotNull(comboCards);
            Assert.IsNotInstanceOfType(comboCards, typeof(EmptyCombo));
            Assert.AreEqual<Combo>(Combo.ROYAL_FLUSH, comboCards.Combo);
            Assert.IsTrue(comboCards.Cards.Any());
            Assert.IsTrue(isComboCardsContainsCorrectly);
        }
    }
}

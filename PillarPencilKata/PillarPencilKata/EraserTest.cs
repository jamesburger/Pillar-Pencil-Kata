using NUnit.Framework;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;
using System.Text.RegularExpressions;

namespace PillarPencilKata
{
    public class EraserTest
    {
        private Pencil PeacockQuill;

        private PaperModel Parchment;

        [Test]
        public void RemoveLastInstanceOfGivenWord()
        {
            //Arrange
            PeacockQuill = new Pencil(1);
            Parchment = new PaperModel()
            {
                WrittenContent = "I like coffee wakes me up makes me fast I love coffee"
            };
            var wordToRemove = "coffee";
            var numberOfCoffeesAfterEraser = 1;

            //Act
            PeacockQuill.UseEraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(numberOfCoffeesAfterEraser, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);
        }

        [Test]
        public void ReplaceErasedWordWithWhiteSpace()
        {
            //Arrange
            PeacockQuill = new Pencil(1);
            Parchment = new PaperModel() {
                WrittenContent = "Troll in the dungeon, thought you ought to know"
            };
            
            var wordToRemove = "know";
            var newWhiteSpace = "    ";
            var instancesOfNewWhiteSpace = 1;

            //Act
            PeacockQuill.UseEraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(instancesOfNewWhiteSpace, Regex.Matches(Parchment.WrittenContent, newWhiteSpace).Count);
            Assert.AreNotEqual(instancesOfNewWhiteSpace, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);

        }

        [Test]
        public void ReplaceWordsInTheMiddleOfTheSentence()
        {
            //Arrange
            PeacockQuill = new Pencil(1);
            Parchment = new PaperModel()
            {
                WrittenContent = "Better be Gryffidor"
            };
            var wordToRemove = "be";
            var instancesOfWordAfterRemoval = 0;

            //Act
            PeacockQuill.UseEraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(instancesOfWordAfterRemoval, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);

        }

        [Test]
        public void ErasingTheSameWordTwiceErasesTheLastTwoInstancesOfTheWord()
        {
            //Arrange
            PeacockQuill = new Pencil(1);
            Parchment = new PaperModel()
            {
                WrittenContent = "wizarding world of wizards world"
            };
            var wordToBeRemoved = "world";
            var instacesOfWordAfterTwoRemovals = 0;

            //Act
            PeacockQuill.UseEraser(wordToBeRemoved, Parchment);
            PeacockQuill.UseEraser(wordToBeRemoved, Parchment);

            //Assert
            Assert.AreEqual(instacesOfWordAfterTwoRemovals, Regex.Matches(Parchment.WrittenContent, wordToBeRemoved).Count);
        }

        [Test]
        public void ProgramDoesntBreakIfWordToBeErasedDoesntExist()
        {
            //Arrange
            PeacockQuill = new Pencil(1);
            Parchment = new PaperModel()
            {
                WrittenContent = "wizarding world of wizards world"
            };
            var wordToBeRemoved = "gopher";
            var instacesOfWordAfterTwoRemovals = 0;

            PeacockQuill.UseEraser(wordToBeRemoved, Parchment);

            //Assert
            Assert.AreEqual(instacesOfWordAfterTwoRemovals, Regex.Matches(Parchment.WrittenContent, wordToBeRemoved).Count);
        }

        [Test]
        public void EraserWithZeroDurabilityDoesntErase()
        {
            //Arrange
            PeacockQuill = new Pencil(1, 0);
            Parchment = new PaperModel()
            {
                WrittenContent = "Haha you can't erase me"
            };
            var wordToBeErased = "me";
            var instancesOfWordToBeErased = 1;

            //Act
            PeacockQuill.UseEraser(wordToBeErased, Parchment);

            //Assert
            Assert.AreEqual(instancesOfWordToBeErased, Regex.Matches(Parchment.WrittenContent, wordToBeErased).Count);
        }

        [Test]
        public void EraserWithDurabilityOfTwoErasesTwoLetters()
        {
            //Arrange
            PeacockQuill = new Pencil(1, 2);
            Parchment = new PaperModel()
            {
                WrittenContent = "You don't know me"
            };
            var wordToBeErased = "me";
            var expectedInstancesOfDeletedWord = 0;
            var expectedEraserDurability = 0;
            

            //Act
            PeacockQuill.UseEraser(wordToBeErased, Parchment);

            //Assert
            Assert.AreEqual(expectedInstancesOfDeletedWord, Regex.Matches(Parchment.WrittenContent, wordToBeErased).Count);
            Assert.AreEqual(expectedEraserDurability, PeacockQuill.Eraser.EraserDurability);
        }

        [Test]
        public void VerifyLowDurabilityErasesExpectedLetters()
        {
            //Arrange 
            PeacockQuill = new Pencil(0, 2);
            Parchment = new PaperModel()
            {
              WrittenContent = "You might know me"
            };
            var wordToBeErased = "know";
            var lettersLeftWhenEraserRunsOut = "kn  ";
            var expectedInstancesOfHalfWords = 1;

            //Act
            PeacockQuill.UseEraser(wordToBeErased, Parchment);

            //Assert
            Assert.AreEqual(expectedInstancesOfHalfWords, Regex.Matches(Parchment.WrittenContent, lettersLeftWhenEraserRunsOut).Count);
            Assert.AreNotEqual(expectedInstancesOfHalfWords, Regex.Matches(Parchment.WrittenContent, wordToBeErased).Count);
        }

        [Test]
        public void NoNewWordsMayBeErasedOnceEraserWornOut()
        {
            //Arrange
            PeacockQuill = new Pencil(0, 4);
            Parchment = new PaperModel()
            {
                WrittenContent = "Maple syrup is tree marinade"
            };
            var firstWordToBeDeleted = "tree";
            var secondWordToBeDeleted = "Maple";
            var expectedInstancesOfFirstWord = 0;
            var expectedInstancesOfSecondWord = 1;

            //Act
            PeacockQuill.UseEraser(firstWordToBeDeleted, Parchment);
            PeacockQuill.UseEraser(secondWordToBeDeleted, Parchment);

            //Assert
            Assert.AreEqual(expectedInstancesOfFirstWord, Regex.Matches(Parchment.WrittenContent, firstWordToBeDeleted).Count);
            Assert.AreEqual(expectedInstancesOfSecondWord, Regex.Matches(Parchment.WrittenContent, secondWordToBeDeleted).Count);

        }
    }
}

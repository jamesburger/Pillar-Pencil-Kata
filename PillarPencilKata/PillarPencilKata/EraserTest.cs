using NUnit.Framework;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;
using System.Text.RegularExpressions;

namespace PillarPencilKata
{
    public class EraserTest
    {
        private Pencil PeacockQuil;

        private PaperModel Parchment;

        [Test]
        public void RemoveLastInstanceOfGivenWord()
        {
            //Arrange
            PeacockQuil = new Pencil();
            Parchment = new PaperModel()
            {
                WrittenContent = "I like coffee wakes me up makes me fast I love coffee"
            };
            var wordToRemove = "coffee";
            var numberOfCoffeesAfterEraser = 1;

            //Act
            PeacockQuil.Eraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(numberOfCoffeesAfterEraser, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);
        }

        [Test]
        public void ReplaceErasedWordWithWhiteSpace()
        {
            //Arrange
            PeacockQuil = new Pencil();
            Parchment = new PaperModel() {
                WrittenContent = "Troll in the dungeon, thought you ought to know"
            };
            
            var wordToRemove = "know";
            var newWhiteSpace = "    ";
            var instancesOfNewWhiteSpace = 1;

            //Act
            PeacockQuil.Eraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(instancesOfNewWhiteSpace, Regex.Matches(Parchment.WrittenContent, newWhiteSpace).Count);
            Assert.AreNotEqual(instancesOfNewWhiteSpace, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);

        }

        [Test]
        public void ReplaceWordsInTheMiddleOfTheSentence()
        {
            //Arrange
            PeacockQuil = new Pencil();
            Parchment = new PaperModel()
            {
                WrittenContent = "Better be Gryffidor"
            };
            var wordToRemove = "be";
            var instancesOfWordAfterRemoval = 0;

            //Act
            PeacockQuil.Eraser(wordToRemove, Parchment);

            //Assert
            Assert.AreEqual(instancesOfWordAfterRemoval, Regex.Matches(Parchment.WrittenContent, wordToRemove).Count);

        }
    }
}

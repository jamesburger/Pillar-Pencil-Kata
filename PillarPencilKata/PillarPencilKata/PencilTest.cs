using NUnit.Framework;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;

namespace PillarPencilKata
{
    [TestFixture]
    public class PencilTest
    {

        private Pencil NumberTwoPencil;

        private PaperModel Paper;

        [Test]
        public void PaperContainsTextPencilWrites()
        {
            //Arrange
            var letterToSanta = "Dear Santa, I hope you're well";
            var constructionPaper = new PaperModel();
            NumberTwoPencil = new Pencil();

            //Act
            constructionPaper = NumberTwoPencil.WriteInputOntoPaper(letterToSanta, constructionPaper);

            //Assert
            StringAssert.AreEqualIgnoringCase(letterToSanta, constructionPaper.WrittenContent);
        }

        [Test]
        public void PencilAppendsTextToExistingContentOnPaper()
        {
            //Arrange
            var letterToGrandma = "Thanks so much for the five dollars you sent for my birthday. ";
            var letterContinued = "Dad reassures me you understand what inflation is. I'm not convinced.";
            var collegeRule = new PaperModel();
            NumberTwoPencil = new Pencil();

            //Act
            NumberTwoPencil.WriteInputOntoPaper(letterToGrandma, collegeRule);
            collegeRule = NumberTwoPencil.WriteInputOntoPaper(letterContinued, collegeRule);

            //Assert
            StringAssert.AreEqualIgnoringCase(letterToGrandma += letterContinued, collegeRule.WrittenContent);

        }

        [Test]
        public void PencilIsGivenADurabilityValueUponCreation()
        {
            //Arrange
            var hunkOfGraphite = 50;

            //Act
            var shinyNewMechanicalPencil = new Pencil(hunkOfGraphite);

            //Assert
            Assert.AreEqual(hunkOfGraphite, shinyNewMechanicalPencil.Durability);
        }

        [Test]
        public void PencilDurabilityFunctionReducesDurabilityByOnePerLetter()
        {
            //Arrange
            var backOfEnvelope = new PaperModel();
            var groceryList = "eggs and milk";
            var inkLeft = 7;
            var bicPen = new Pencil(20);

            //Act
            backOfEnvelope = bicPen.WriteInputOntoPaper(groceryList, backOfEnvelope);

            //Assert
            Assert.AreEqual(inkLeft, bicPen.Durability);
        }

        [Test]
        public void WhiteSpacesInGivenInputDoNotReduceDurability()
        {
            //Arrange
            var receipt = new PaperModel();
            var highlighter = new Pencil(20);
            var taxDeductiblePurchase = "office supplies";
            var inkLeft = 6;

            //Act
            receipt = highlighter.WriteInputOntoPaper(taxDeductiblePurchase, receipt);

            //Assert
            Assert.AreEqual(inkLeft, highlighter.Durability);
        }

        [Test]
        public void CapitalLettersReduceDurabilityByTwo()
        {
            //Arrange
            NumberTwoPencil = new Pencil(20);
            var barbaricYawp = "MY YAWPS TOP";
            Paper = new PaperModel();
            var bigWhoppingZero = 0;

            //Act
            Paper = NumberTwoPencil.WriteInputOntoPaper(barbaricYawp, Paper);

            //Assert
            Assert.AreEqual(bigWhoppingZero, NumberTwoPencil.Durability);

        }
    }
}

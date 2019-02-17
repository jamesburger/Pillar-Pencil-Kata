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
            NumberTwoPencil = new Pencil(30);

            //Act
            NumberTwoPencil.WriteInputOntoPaper(letterToSanta, constructionPaper);

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
            NumberTwoPencil = new Pencil(200);

            //Act
            NumberTwoPencil.WriteInputOntoPaper(letterToGrandma, collegeRule);
            NumberTwoPencil.WriteInputOntoPaper(letterContinued, collegeRule);

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
            var inkLeft = 9;
            var bicPen = new Pencil(20);

            //Act
            bicPen.WriteInputOntoPaper(groceryList, backOfEnvelope);

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
            highlighter.WriteInputOntoPaper(taxDeductiblePurchase, receipt);

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
            NumberTwoPencil.WriteInputOntoPaper(barbaricYawp, Paper);

            //Assert
            Assert.AreEqual(bigWhoppingZero, NumberTwoPencil.Durability);
        }

        [Test]
        public void PencilStopsWritingIfDurabilityEqualOrLessThanZero()
        {
            //Arrange
            NumberTwoPencil = new Pencil(5);
            Paper = new PaperModel();
            var mumble = "what if";
            var whatWasHeard = "what i ";

            //Act
            NumberTwoPencil.WriteInputOntoPaper(mumble, Paper);

            //Assert
            StringAssert.AreEqualIgnoringCase(whatWasHeard, Paper.WrittenContent);
        }

        [Test]
        public void IfDurabilityLowerThanTwoPencilDoesNotWriteCapitalLetter()
        {
            //Arrange
            NumberTwoPencil = new Pencil(1);
            Paper = new PaperModel();
            var capitalLetter = "J";

            //Act
            NumberTwoPencil.WriteInputOntoPaper(capitalLetter, Paper);

            //Assert
            Assert.AreNotEqual(capitalLetter, Paper.WrittenContent);
            Assert.AreEqual(Paper.WrittenContent, "j");
        }

        [Test]
        public void OncePencilIsDullRemainingCharactersWrittenAsWhiteSpaces()
        {
            //Arrange
            NumberTwoPencil = new Pencil(1);
            Paper = new PaperModel();
            var twoLetters = "jb";

            //Act
            NumberTwoPencil.WriteInputOntoPaper(twoLetters, Paper);

            //Assert
            Assert.AreEqual("j ", Paper.WrittenContent);
        }

        [Test]
        public void CamelCaseInputStillReplacedByWhiteSpaceOncePencilDull()
        {
            //Arrange
            NumberTwoPencil = new Pencil(3);
            Paper = new PaperModel();
            var myInitials = "Jjb";

            //Act
            NumberTwoPencil.WriteInputOntoPaper(myInitials, Paper);

            //Assert
            Assert.AreEqual("Jj ", Paper.WrittenContent);
        }
    }
}

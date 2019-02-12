using NUnit.Framework;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;

namespace PillarPencilKata
{
    [TestFixture]
    public class PencilTest
    {

        private Pencil NumberTwoPencil;
        private PaperModel PadOfPaper;

       [OneTimeSetUp]
       public void TestSetup()
        {
            NumberTwoPencil = new Pencil();
            PadOfPaper = new PaperModel(); 
        }

        [Test]
        public void PaperContainsTextPencilWrites()
        {
            //Arrange
            var letterToSanta = "Dear Santa, I hope you're well";

            //Act
            PadOfPaper = NumberTwoPencil.WriteInputOntoPaper(letterToSanta);

            //Assert
            StringAssert.AreEqualIgnoringCase(letterToSanta, PadOfPaper.WrittenContent);
        }

        [Test]
        public void PencilAppendsTextToExistingContentOnPaper()
        {
            //Arrange
            var letterToGrandma = "Thanks so much for the five dollars you sent for my birthday. ";
            var letterContinued = "Dad reassures me you understand what inflation is. I'm not convinced.";

            //Act
            NumberTwoPencil.WriteInputOntoPaper(letterToGrandma);
            PadOfPaper = NumberTwoPencil.WriteInputOntoPaper(letterContinued);

            //Assert
            StringAssert.AreEqualIgnoringCase(letterToGrandma += letterContinued, PadOfPaper.WrittenContent);

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
    }
}

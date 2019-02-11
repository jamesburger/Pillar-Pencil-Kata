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
            PadOfPaper.WrittenContent = NumberTwoPencil.Write(letterToSanta).WrittenContent;

            //Assert
            StringAssert.AreEqualIgnoringCase(letterToSanta, PadOfPaper.WrittenContent);
        }
    }
}

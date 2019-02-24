using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;

namespace PillarPencilKata
{
    public class SharpenerClass
    {
        private Pencil Pencil;

        private Pencil HydratedPencil;

        private PaperModel Paper;

        [SetUp]
        public void Setup()
        {
            var pencilLength = 4;
            var pencilDurability = 10;
            var eraserDurability = 10;
            HydratedPencil = new Pencil(pencilDurability, eraserDurability, pencilLength);
        }

        [TearDown]
        public void SharpenerTearDown()
        {
            HydratedPencil.PencilDurability = null;
            HydratedPencil.EraserDurability = null;
            HydratedPencil.PencilLength = null;
        }

        [Test]
        public void PencilRecordsOriginalDurabilityOnConstruction()
        {
            //Arrange
            var inputDurability = 100;

            //Act
            Pencil = new Pencil(inputDurability);

            //Assert
            Assert.AreEqual(inputDurability, Pencil.OriginalSharpness);
        }

        [Test]
        public void SharpenerMethodSetsDurabilityEqualToOriginalSharpeness()
        {
            //Arrange
            var inputDurability = 100;
            var sentenceToBeWritten = "Tip toe through the tulips";
            Pencil = new Pencil(inputDurability);
            Paper = new PaperModel();

            //Act
            Pencil.WriteInputOntoPaper(sentenceToBeWritten, Paper);
            Pencil.Sharpen();

            //Assert
            Assert.AreEqual(inputDurability, Pencil.PencilDurability);
        }

        [Test]
        public void PencilCanBeCreatedWithInitialLengthProperty()
        {
            //Arrange
            var pencilLength = 4;
            var pencilDurability = 10;
            var eraserDurability = 10;

            //Act
            Pencil = new Pencil(pencilDurability, eraserDurability, pencilLength);

            //Assert
            Assert.AreEqual(pencilLength, Pencil.PencilLength);
        }

        [Test]
        public void UsingSharpenMethodDecrementsPencilLengthByOne()
        {
            //Assert
          
            var lengthAfterSharpening = 3;
            var aWord = "A word";
            Paper = new PaperModel();

            //Act
            HydratedPencil.WriteInputOntoPaper(aWord, Paper);
            HydratedPencil.Sharpen();

            //Assert
            Assert.AreEqual(lengthAfterSharpening, HydratedPencil.PencilLength);

        }
    }
}

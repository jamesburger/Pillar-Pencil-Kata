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

        private PaperModel Paper;

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
    }
}

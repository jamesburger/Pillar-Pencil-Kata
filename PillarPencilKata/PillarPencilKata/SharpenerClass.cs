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
    }
}

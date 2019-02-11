using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public PaperModel Write(string input)
        {
            var pieceOfPaper = new PaperModel();
            pieceOfPaper.WrittenContent = input;
           return pieceOfPaper;
        }
    }
}

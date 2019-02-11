using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        private PaperModel Paper = new PaperModel();
         
        public PaperModel WriteInputOntoPaper(string input)
        {
            if(Paper.WrittenContent == null)
            {
                Paper.WrittenContent = input;
            }
            else
            {
                Paper.WrittenContent += input;
            }
            return Paper;
        }
    }
}

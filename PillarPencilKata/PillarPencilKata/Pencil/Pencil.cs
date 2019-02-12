using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int Durability { get; set; }

        private PaperModel Paper = new PaperModel();

        public Pencil()
        {

        }

        public Pencil(int durability)
        {
            Durability = durability;
        }
         
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

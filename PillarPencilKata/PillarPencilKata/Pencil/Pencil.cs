using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int Durability { get; set; }

        public Pencil()
        {

        }

        public Pencil(int durability)
        {
            Durability = durability;
        }
         
        public PaperModel WriteInputOntoPaper(string input, PaperModel Paper)
        {
            if(Paper.WrittenContent == null)
            {
                Paper.WrittenContent = ReducePencilDurability(input);
            }
            else
            {
                Paper.WrittenContent += ReducePencilDurability(input);
            }
            return Paper;
        }

        private string ReducePencilDurability(string input)
        {
            var letterArray = input.ToCharArray();
            foreach(var letter in letterArray)
            {
                if (char.IsWhiteSpace(letter))
                {
                    continue;
                }
                --Durability;
            }
            return input;
        }
    }
}

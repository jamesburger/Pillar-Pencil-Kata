using PillarPencilKata.Models;
using System.Collections.Generic;

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
            var newSentence = "";
            foreach(var letter in letterArray)
            {
                if(Durability > 0)
                {
                     if (char.IsUpper(letter))
                    {
                        if(Durability == 1)
                        {
                             newSentence += char.ToLower(letter);
                            --Durability;
                            continue;
                        }
                        Durability = Durability - 2;
                    }
                    else if (char.IsLower(letter))
                    {
                        --Durability;
                    }
                    newSentence += letter;
                }
                else
                {
                    newSentence += " ";
                }
            }
            return newSentence;
        }
    }
}

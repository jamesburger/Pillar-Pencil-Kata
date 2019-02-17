using PillarPencilKata.Models;
using System.Collections.Generic;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int Durability { get; set; }

        private string NewSentence;

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

            NewSentence = string.Empty;

            return Paper;
        }

        public PaperModel Eraser(string input, PaperModel paper)
        {
           var lastInstanceOfInput = paper.WrittenContent.LastIndexOf(input);
             paper.WrittenContent = paper.WrittenContent.Remove(lastInstanceOfInput, input.Length).Insert(lastInstanceOfInput, new string(' ', input.Length));
            return paper;
        }

        private string ReducePencilDurability(string input)
        {
            var letterArray = input.ToCharArray();
            foreach(var letter in letterArray)
            {
                if(Durability > 0)
                {
                    ParseLettersByCapitalizationOrWhitespace(letter);
                }
                else
                {
                    NewSentence += " ";
                }
            }
            return NewSentence;
        }

        private void ParseLettersByCapitalizationOrWhitespace(char letter)
        {
            if (char.IsUpper(letter))
            {
                UpperCaseLetterHandler(letter);
            }
            else if (char.IsLower(letter))
            {
                LowerCaseHandler(letter);
            }
            else
            {
                NewSentence += letter;
            }
        }

        private void UpperCaseLetterHandler(char letter)
        {
            if (Durability == 1)
            {
                --Durability;
                NewSentence += char.ToLower(letter);
            }
            else
            {
                Durability = Durability - 2;
                NewSentence += letter;
            }
        }

        private void LowerCaseHandler(char letter)
        {
            --Durability;
            NewSentence += letter;
        }
    }
}

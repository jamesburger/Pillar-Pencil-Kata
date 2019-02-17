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

        public PaperModel Eraser(string wordToBeDeleted, PaperModel paper)
        {
           var lastInstanceOfWordBeingDeleted = paper.WrittenContent.LastIndexOf(wordToBeDeleted);
            if(lastInstanceOfWordBeingDeleted >= 0)
            {
                paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, wordToBeDeleted, lastInstanceOfWordBeingDeleted);
            }
            else
            {
                return paper;
            }
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

        public string RemoveSpecifiedWordAndReplaceWithWhiteSpace(string originalSentence, string wordBeingRemoved, int indexPostion)
        {
            return originalSentence.Remove(indexPostion, wordBeingRemoved.Length).Insert(indexPostion, new string(' ', wordBeingRemoved.Length));
        }
    }
}

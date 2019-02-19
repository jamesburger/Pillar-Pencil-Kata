using PillarPencilKata.Models;
using System.Collections.Generic;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int PencilDurability { get; set; }

        public int? EraserDurability { get; set; }

        private string NewSentence;

        public Pencil(int pencilDurability)
        {
            PencilDurability = pencilDurability;
        }

        public Pencil(int pencilDurability, int eraserDurability)
        {
            PencilDurability = pencilDurability;
            EraserDurability = eraserDurability;
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

            if (lastInstanceOfWordBeingDeleted >= 0)
            {
                if(EraserDurability == null)
                {
                    paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, wordToBeDeleted, lastInstanceOfWordBeingDeleted);
                    return paper;
                }
                var newString = "";
                foreach(var letter in wordToBeDeleted.ToCharArray())
                {
                    if (EraserDurability > 0)
                    {
                        newString += letter;
                        if (!char.IsWhiteSpace(letter))
                        {
                            --EraserDurability;
                        }
                    }
                    else
                    {
                        return paper;
                    }
                }
                        paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, newString, lastInstanceOfWordBeingDeleted);

            }
            return paper;
        }

        private string ReducePencilDurability(string input)
        {
            var letterArray = input.ToCharArray();
            foreach(var letter in letterArray)
            {
                if(PencilDurability > 0)
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
            if (PencilDurability == 1)
            {
                --PencilDurability;
                NewSentence += char.ToLower(letter);
            }
            else
            {
                PencilDurability = PencilDurability - 2;
                NewSentence += letter;
            }
        }

        private void LowerCaseHandler(char letter)
        {
            --PencilDurability;
            NewSentence += letter;
        }

        public string RemoveSpecifiedWordAndReplaceWithWhiteSpace(string originalSentence, string wordBeingRemoved, int indexPostion)
        {
            return originalSentence.Remove(indexPostion, wordBeingRemoved.Length).Insert(indexPostion, new string(' ', wordBeingRemoved.Length));
        }
    }
}

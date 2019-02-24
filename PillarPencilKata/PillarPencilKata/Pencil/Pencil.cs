using PillarPencilKata.Models;
using System;
using System.Collections.Generic;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int? PencilDurability { get; set; }

        public int? EraserDurability { get; set; }

        public int? PencilLength { get; set; }

        public int IndexOfLastErasedWord { get; private set; }

        private string NewSentence;

        public readonly int OriginalSharpness;

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
                    IndexOfLastErasedWord = lastInstanceOfWordBeingDeleted;
                    return paper;
                }

                var numberOfLettersToBeReplacedByWhitespace = FindLettersToBeErasedByEraserDurability(wordToBeDeleted);

                var indexAdjustment = wordToBeDeleted.Length - numberOfLettersToBeReplacedByWhitespace;

                var lastIndexPositionAdjustedForDurability = lastInstanceOfWordBeingDeleted + indexAdjustment;

                IndexOfLastErasedWord = lastIndexPositionAdjustedForDurability;

                paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, wordToBeDeleted.Substring(indexAdjustment), lastIndexPositionAdjustedForDurability);

            }
            return paper;
        }

        public void Sharpen()
        {
            if(PencilLength == null)
            {
                PencilDurability = OriginalSharpness;
            }
            else
            {
                if(PencilLength > 0)
                {
                    --PencilLength;
                    PencilDurability = OriginalSharpness;
                }
               
            }
        }

        public PaperModel ReplaceErasedWord(string wordReplacement, PaperModel paper)
        {
            paper.WrittenContent = paper.WrittenContent.Insert(IndexOfLastErasedWord, wordReplacement);
            return paper;
        }

        private string ReducePencilDurability(string input)
        {
            var letterArray = input.ToCharArray();
            if(PencilDurability == null)
            {
                return NewSentence += input;
            }
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

        private string RemoveSpecifiedWordAndReplaceWithWhiteSpace(string originalSentence, string wordBeingRemoved, int indexPostion)
        {
            return originalSentence.Remove(indexPostion, wordBeingRemoved.Length).Insert(indexPostion, new string(' ', wordBeingRemoved.Length));
        }

        private int FindLettersToBeErasedByEraserDurability(string wordBeingErased)
        {
            var counter = 0;
            foreach (var letter in wordBeingErased.ToCharArray())
            {
                if (EraserDurability > 0)
                {
                    ++counter;
                    if (!char.IsWhiteSpace(letter))
                    {
                        --EraserDurability;
                    }
                }
            }
            return counter;
        }

        public Pencil()
        {
        }

        public Pencil(int pencilDurability)
        {
            PencilDurability = pencilDurability;
            OriginalSharpness = pencilDurability;
        }

        public Pencil(int pencilDurability, int eraserDurability)
        {
            PencilDurability = pencilDurability;
            OriginalSharpness = pencilDurability;
            EraserDurability = eraserDurability;
        }

        public Pencil(int pencilDurability, int eraserDurability, int pencilLength)
        {
            PencilDurability = pencilDurability;
            OriginalSharpness = pencilDurability;
            EraserDurability = eraserDurability;
            PencilLength = pencilLength;
        }
    }
}

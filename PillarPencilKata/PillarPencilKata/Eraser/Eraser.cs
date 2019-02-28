using PillarPencilKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillarPencilKata.Eraser_Logic
{
    public class Eraser 
    {

        public int? EraserDurability { get; set; }

        public Eraser(int? eraserDurability)
        {
            EraserDurability = eraserDurability;
        }

        public PaperModel Erase(string wordToBeDeleted, PaperModel paper)
        {
            var lastInstanceOfWordBeingDeleted = paper.WrittenContent.LastIndexOf(wordToBeDeleted);

            if (lastInstanceOfWordBeingDeleted >= 0)
            {
                if (EraserDurability == null)
                {
                    return EraseWithoutDurability(paper, wordToBeDeleted, lastInstanceOfWordBeingDeleted);
                }
                paper = EraseContentAccountingForDurability(paper, wordToBeDeleted, lastInstanceOfWordBeingDeleted);
            }
            return paper;
        }

        private PaperModel EraseContentAccountingForDurability(PaperModel paper, string wordToBeDeleted, int lastInstanceOfWordBeingDeleted)
        {
            var indexAdjustment = wordToBeDeleted.Length - FindNumberOfLettersToBeErasedByEraserDurability(wordToBeDeleted);

            var lastIndexPositionAdjustedForDurability = lastInstanceOfWordBeingDeleted + indexAdjustment;

            paper.SpaceWhereErasedWordWas = lastIndexPositionAdjustedForDurability;

            paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, wordToBeDeleted.Substring(indexAdjustment), lastIndexPositionAdjustedForDurability);

            return paper;

        }

        private PaperModel EraseWithoutDurability(PaperModel paper, string wordToBeDeleted, int lastInstanceOfWordBeingDeleted)
        {
            paper.WrittenContent = RemoveSpecifiedWordAndReplaceWithWhiteSpace(paper.WrittenContent, wordToBeDeleted, lastInstanceOfWordBeingDeleted);
            paper.SpaceWhereErasedWordWas = lastInstanceOfWordBeingDeleted;
            return paper;
        }

        private string RemoveSpecifiedWordAndReplaceWithWhiteSpace(string originalSentence, string wordBeingRemoved, int indexPostion)
        {
            return originalSentence.Remove(indexPostion, wordBeingRemoved.Length).Insert(indexPostion, new string(' ', wordBeingRemoved.Length));
        }

        private int FindNumberOfLettersToBeErasedByEraserDurability(string wordBeingErased)
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

    }
}

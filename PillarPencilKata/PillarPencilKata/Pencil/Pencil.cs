using PillarPencilKata.Eraser_Logic;
using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public class Pencil : IPencil
    {
        public int? PencilDurability { get; set; }

        public int? EraserDurability { get; set; }

        public int? PencilLength { get; set; }

        public int IndexOfLastErasedWord { get; private set; }

        public int? OriginalSharpness { get; private set; }

        public readonly Eraser Eraser;


        public Pencil()
        {
            Eraser = new Eraser(null);
        }

        public Pencil(int? pencilDurability = null, int? eraserDurability = null, int? pencilLength = null)
        {
            PencilDurability = pencilDurability;
            OriginalSharpness = pencilDurability;
            Eraser = new Eraser(eraserDurability);
            PencilLength = pencilLength;
        }

        public PaperModel WriteInputOntoPaper(string input, PaperModel Paper)
        {

         var newSentence = "";

            if(Paper.WrittenContent == null)
            {
                Paper.WrittenContent = DetermineWhatIsWrittenByPencilDurability(input, newSentence);
            }
            else
            {
                Paper.WrittenContent += DetermineWhatIsWrittenByPencilDurability(input, newSentence);
            }

            newSentence = string.Empty;

            return Paper;
        }

        public PaperModel UseEraser(string input, PaperModel paper)
        {
            paper = Eraser.Erase(input, paper);
            IndexOfLastErasedWord = paper.SpaceWhereErasedWordWas;
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
            var spaceBeingFilledByReplacementWord = FindSubstringBeingReplacedByNewWord(paper.WrittenContent, wordReplacement); 

            var replacementWordAccountingForOverlap = BuildReplacementStringAccountingForOverlap(spaceBeingFilledByReplacementWord, wordReplacement);

            paper.WrittenContent = paper.WrittenContent.Remove(IndexOfLastErasedWord, wordReplacement.Length).Insert(IndexOfLastErasedWord, replacementWordAccountingForOverlap);

            return paper;
        }

        private string DetermineWhatIsWrittenByPencilDurability(string input, string newSentence)
        {
            if(PencilDurability == null)
            {
                return newSentence += input;
            }
            foreach(var letter in input.ToCharArray())
            {
                if(PencilDurability > 0)
                {
                   newSentence += ParseLettersByCapitalizationOrWhitespace(letter);
                }
                else
                {
                   return newSentence += " ";
                }
            }
            return newSentence;
        }

        private char ParseLettersByCapitalizationOrWhitespace(char letter)
        {
            if (char.IsUpper(letter))
            {
               return HandleUpperCaseLetterDurabilityReduction(letter);
            }
            else if (char.IsLower(letter))
            {
              return HandleLowerCaseLetterDurabilityReduction(letter);
            }
            else
            {
               return letter;
            }
        }

        private char HandleUpperCaseLetterDurabilityReduction(char letter)
        {
            if (PencilDurability == 1)
            {
                --PencilDurability;
               return char.ToLower(letter);
            }
            else
            {
                PencilDurability = PencilDurability - 2;
               return letter;
            }
        }

        private char HandleLowerCaseLetterDurabilityReduction(char letter)
        {
            --PencilDurability;
            return letter;
        }

        private string FindSubstringBeingReplacedByNewWord(string writtenContent, string wordReplacement)
        {
            return writtenContent.Substring(IndexOfLastErasedWord, wordReplacement.Length);
        }

        private string BuildReplacementStringAccountingForOverlap(string substringBeingReplaced, string wordReplacement)
        {
            var symbol = '@';
            var replacementWordAccountingForOverlap = "";
            for (int i = 0; i < wordReplacement.Length; i++)
            {
                replacementWordAccountingForOverlap += char.IsWhiteSpace(substringBeingReplaced[i]) ? wordReplacement[i] : symbol;
            }
            return replacementWordAccountingForOverlap;
        }
       
    }
}

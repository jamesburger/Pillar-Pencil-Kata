using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public interface IPencil
    {
        PaperModel WriteInputOntoPaper(string input, PaperModel paper);

        PaperModel UseEraser(string input, PaperModel paper);

        PaperModel ReplaceErasedWord(string replacementWord, PaperModel paper);

        void Sharpen(); 
    }
}

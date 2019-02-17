using PillarPencilKata.Models;

namespace PillarPencilKata.Pencil_Logic
{
    public interface IPencil
    {
        PaperModel WriteInputOntoPaper(string input, PaperModel Paper);

        PaperModel Eraser(string input, PaperModel paper);
    }
}

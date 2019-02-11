using PillarPencilKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillarPencilKata.Pencil_Logic
{
    public interface IPencil
    {
        PaperModel Write(string input); 
    }
}

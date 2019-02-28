using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;

namespace PillarPencilKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PaperModel paper = new PaperModel();
            Pencil pencil = CreatePencil();
            Console.WriteLine("Ok, let's try writing something. Type whatever you'd like below!");
            pencil.WriteInputOntoPaper(Console.ReadLine(), paper);
            Console.WriteLine("You wrote " + paper.WrittenContent);
            SelectOptions(pencil, paper);


            Console.ReadLine();

        }

        public static Pencil CreatePencil()
        {
            Console.WriteLine("OK, first you need to create a new pencil. How durable should it be? (enter a number)");
            int.TryParse(Console.ReadLine(), out int durability);
            Console.WriteLine("And how long will the eraser last? (enter a number)");
            int.TryParse(Console.ReadLine(), out int eraserDurability);
            Console.WriteLine("Lastly, how many times can you sharpen it?");
            int.TryParse(Console.ReadLine(), out int pencilLength);
            return new Pencil(durability, eraserDurability, pencilLength);
        }

        public static void SelectOptions(Pencil pencil, PaperModel paper)
        {
            Console.WriteLine("Pick your next action by entering the corresponding number");
            Console.WriteLine("1. Write More");
            Console.WriteLine("2. Erase a Word");
            Console.WriteLine("3. Sharpen Your Pencil");
            Console.WriteLine("4. Exit the Program");
                int.TryParse(Console.ReadLine(), out int userChoice);

            switch (userChoice)
            {
                case 1:
                    WriteMore(pencil, paper);
                    break;
                case 2:
                    EraseAWord(pencil, paper);
                    break;
                case 3:
                    pencil.Sharpen();
                    Console.WriteLine("Remaining sharpens: " + pencil.PencilLength);
                    SelectOptions(pencil, paper);
                    break;
                case 4:
                    Console.WriteLine("Goodbye");
                    break;
            }
        }

        public static void WriteMore(Pencil pencil, PaperModel paper)
        {
            Console.WriteLine(paper.WrittenContent);
            Console.WriteLine("Add whatever you'd like to what you've written!");
            pencil.WriteInputOntoPaper(Console.ReadLine(), paper);
            Console.WriteLine(paper.WrittenContent);
            SelectOptions(pencil, paper);
        }

        public static void EraseAWord(Pencil pencil, PaperModel paper)
        {
            Console.WriteLine(paper.WrittenContent);
            Console.WriteLine("What word would you like to erase?");
            pencil.UseEraser(Console.ReadLine(), paper);
            Console.WriteLine(paper.WrittenContent);
            ReplaceErasedWord(pencil, paper);
        }

        public static void ReplaceErasedWord(Pencil pencil, PaperModel paper)
        {
            Console.WriteLine("Would you like to replace the word you replaced with another word? 1 for yes, 2 for no");
            int.TryParse(Console.ReadLine(), out int input);
            if(input == 1)
            {
                Console.WriteLine("Enter the word you'd like to insert: ");
                pencil.ReplaceErasedWord(Console.ReadLine(), paper);
                Console.WriteLine(paper.WrittenContent);
                SelectOptions(pencil, paper);
            }
            else
            {
                SelectOptions(pencil, paper);
            }
        }
    }

}

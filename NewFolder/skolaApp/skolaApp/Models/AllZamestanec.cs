using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaApp.Models
{
    internal class AllZamestanec
    {
        public ObservableCollection<Zamestanec> Zamestanec { get; set; }
        public AllZamestanec(string o) =>
        LoadZamestanec(o);

        public void LoadZamestanec(string d)
        {
            Zamestanec.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Zamestanec> zamestanecs = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.Zamestanec.txt")

            // Each file name is used to create a new Note
                                        .Select(filename => new Zamestanec()
                                        {
                                            FileName = filename,
                                            Jmeno = File.ReadAllText(filename).Split(',')[0],
                                            Prijmeny = File.ReadAllText(filename).Split(',')[1],
                                            Obor = File.ReadAllText(filename).Split(',')[2],
                                        }); 
                                        

                                        // With the final collection of notes, order them by date
                                       

            // Add each note into the ObservableCollection
            foreach (Zamestanec zamestanec in Zamestanec)
                if (zamestanec.Obor == d || d.Length == 0)
                {
                  Zamestanec.Add(zamestanec);

                }
        }
    }
}

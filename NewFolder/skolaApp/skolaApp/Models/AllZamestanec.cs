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
        public ObservableCollection<Zamestanec> Zamestanecs { get; set; } = new ObservableCollection<Zamestanec>();
        public AllZamestanec(string d) =>
        LoadZamestanec(d);

        public void LoadZamestanec(string d)
        {
            Zamestanecs.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Zamestanec> zamestanecs = Directory

                                        // Select the file names from the directory
                                        .GetFiles(appDataPath, "*")

            // Each file name is used to create a new Note
                                        .Select(fileName => new Zamestanec()
                                        {
                                            FileName = fileName,
                                            Jmeno = File.ReadAllText(fileName).Split(',')[0],
                                            Prijmeny = File.ReadAllText(fileName).Split(',')[1],
                                            Obor = File.ReadAllText(fileName).Split(',')[2],
                                        }); 
                                        
            
                                        // With the final collection of notes, order them by date
                                       

            // Add each note into the ObservableCollection
            foreach (Zamestanec zamestanec in zamestanecs)
                if (zamestanec.Obor == d || d.Length == 0)
                {
                        Zamestanecs.Add(zamestanec);
                    

                }
        }
    }
}

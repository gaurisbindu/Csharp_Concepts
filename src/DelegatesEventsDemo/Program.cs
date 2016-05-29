using System;

namespace DelegatesEventsDemo
{
    public class Program
    {
        public void Main(string[] args)
        {
            GradeBook book = new GradeBook(100, "My Grade Book 1");

            // Initializing new Delegate Instance
            book.NameChanged = new NameChangedDelegate(OnNameChangedUpdateConsole);

            // Adding methods to multicast delegate
            book.NameChanged += OnNameChangedUpdateDB;
            book.NameChanged += OnNameChangedUpdateUI;

            book.Name = "My Grade Book Two";

            // Removing methods from delegate
            book.NameChanged -= OnNameChangedUpdateUI;

            book.Name = "My Garde Book Three";


            // Subscribing to the event
            book.ClassStrengthChanged += ClassStrengthChangedUpdateConsole;
            book.ClassStrengthChanged += ClassStrengthChangedUpdateDB;
            book.ClassStreangth = 125;

            // Unsubscribing from an event
            book.ClassStrengthChanged -= ClassStrengthChangedUpdateDB;
            book.ClassStreangth = 123;

            Console.ReadLine();
        }

        private void ClassStrengthChangedUpdateConsole(object sender, ClassStrengthChangedEventArgs args)
        {
            Console.WriteLine("Updating Console...");

            var gradeBook = sender as GradeBook;
            if (gradeBook != null)
            {
                Console.WriteLine("The class strength for GradeBook {0} has been changed from {1} to {2}", 
                    gradeBook.Name, args.OldClassStrength, args.NewClassStrength);
            }
        }

        private void ClassStrengthChangedUpdateDB(object sender, ClassStrengthChangedEventArgs args)
        {
            Console.WriteLine("Updating DB...");

            var gradeBook = sender as GradeBook;
            if (gradeBook != null)
            {
                Console.WriteLine("The class strength for GradeBook {0} has been changed from {1} to {2}",
                    gradeBook.Name, args.OldClassStrength, args.NewClassStrength);
            }
        }

        private void OnNameChangedUpdateConsole(string oldName, string newName)
        {
            Console.WriteLine("Updating console...");
            Console.WriteLine("The name on the console has been changed from {0} to {1}", oldName, newName);
        }

        private void OnNameChangedUpdateDB(string oldName, string newName)
        {
            Console.WriteLine("Updating DB..."); 
            Console.WriteLine("The Name record in database has been updated from {0} to {1}", oldName, newName);
        }

        private void OnNameChangedUpdateUI(string oldName, string newName)
        {
            Console.WriteLine("Updating UI...");
            Console.WriteLine("Changing color to report name changed from {0} to {1}", oldName, newName);
        }
    }
}

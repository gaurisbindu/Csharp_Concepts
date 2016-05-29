namespace DelegatesEventsDemo
{
    public class GradeBook
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                string oldName = name;
                name = value;
              
                //invoke a delegate to notify name has changed
                if (NameChanged != null)
                {
                    NameChanged(oldName, name);
                }
            }
        }

        private int classStrength;
        public int ClassStreangth
        {
            get
            {
                return classStrength;
            }
            set
            {
                var oldClassStrength = classStrength;
                classStrength = value;
                if(ClassStrengthChanged != null)
                {
                    var classStrengthChangedEventArgs = new ClassStrengthChangedEventArgs
                    {
                        OldClassStrength = oldClassStrength,
                        NewClassStrength = value
                    };

                    ClassStrengthChanged(this,  classStrengthChangedEventArgs);
                }
            }
        }

        public GradeBook(int classStrength, string name)
        {
            this.classStrength = classStrength;
            this.name = name;
        }

        // Creating a new delegate instance
        public NameChangedDelegate NameChanged;

        // Creating new event
        public event ClassStrengthChangedDelegate ClassStrengthChanged;
    }
}

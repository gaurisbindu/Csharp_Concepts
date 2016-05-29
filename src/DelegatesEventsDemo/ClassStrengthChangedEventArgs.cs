using System;

namespace DelegatesEventsDemo
{
    public class ClassStrengthChangedEventArgs : EventArgs
    {
        public int OldClassStrength { get; set; }
        public int NewClassStrength { get; set; }
    }
}
namespace ObserverPattern
{
    public class Subject
    {
        public List<Action<string, string>> Observers { get; set; } = new List<Action<string, string>> { };

        public Subject()
        {
            Observers = new List<Action<string, string>> { };
        }
         
    }
}

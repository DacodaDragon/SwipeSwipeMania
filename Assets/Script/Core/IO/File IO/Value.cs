using System.Collections.Generic;

namespace SwipeSwipeMania
{
    public class Value  
    {
        public List<string> Parameters;

        public Value()
        {
            Parameters = new List<string>(10);
        }

        public string Index(int i)
        {
            if (i >= Parameters.Count)
                return string.Empty;
            else return Parameters[i];
        }
    }
}
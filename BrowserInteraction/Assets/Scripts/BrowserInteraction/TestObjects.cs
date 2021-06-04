using System.Collections.Generic;

namespace BrowserInteraction
{
    public class TestObjects
    {
        
    }

    [System.Serializable]
    public class Box
    {
        public string name;
        public float size;
        public List<Thing> things;
    }

    [System.Serializable]
    public class Thing
    {
        public string name;
        public float size;
    }
}
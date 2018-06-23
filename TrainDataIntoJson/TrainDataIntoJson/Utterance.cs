namespace AddUtterance
{
    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string text { get; set; }
        public string intentName { get; set; }
        public Entitylabel[] entityLabels { get; set; }
    }

    public class Entitylabel
    {
        public string entityName { get; set; }
        public int startCharIndex { get; set; }
        public int endCharIndex { get; set; }
    }
}


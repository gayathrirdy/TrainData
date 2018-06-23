using System.Collections.Generic;

namespace Titlepattern
{
    class IntentPatterns
    {
        List<List<string>> patterns;
        List<string> extraDecorators;
        List<string> intentList;
        public IntentPatterns()
        {
            extraDecorators = new List<string> { "extra", "take", "flat", "save" };
            patterns = new List<List<string>>
            {
                new List<string> { "percentage", "off", "category" },
                new List<string> { "amount", "off", "category"},
                new List<string> { "up", "to", "percentage", "off", "category"},
                new List<string> { "up", "to", "amount", "off", "category"},
                new List<string> { "extra_decorators", "percentage", "off", "category"},
                new List<string> { "save", "percentage", "on", "category"},
                new List<string> { "amount", "flat", "rate", "shipping", "on", "orders", "below", "maximum_purchase" },
                new List<string> { "free", "shipping", "on", "orders", "over", "minimum_purchase" }
            };
            intentList = new List<string> { "percentageoffer", "amountoffer", "uptopercentageoffer", "uptoamountoffer",
                                            "percentageoffer", "percentageoffer", "flatrateshipping", "freeshipping" };
        }
        public List<List<string>> getPatterns()
        {
            return patterns;
        }
        public List<string> getIntentList()
        {
            return intentList;
        }
        public List<string> getExtraDecorators()
        {
            return extraDecorators;
        }
    }
    //class Patterns
    //{
    //    List<string> patternList;
    //    string intentName;
    //    public Patterns(List<string> list,string intentName)
    //    {
    //        this.intentName = intentName;
    //        this.patternList = list;           
    //    }
    //}
}
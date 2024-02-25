namespace SimpleMastermind
{
    public class CheckResult
    {
        public CheckResult() { 
            Value = string.Empty;
        }

        public int GuessIndex { get; set; }
        public int CombinationIndex { get; set; }
        public bool CorrectValue { get; set; }
        public bool CorrentIndex { get; set; }
        public string Value { get; set; }
    }

}
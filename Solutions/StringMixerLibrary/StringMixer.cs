namespace StringMixerLibrary
{
    public class StringMixer
    {
        public string Mix(string input1, string input2)
        {
            string result = string.Empty;
            using (var input1Enumerator = input1.GetEnumerator())
            using (var input2Enumerator = input2.GetEnumerator())
            {
                while (input1Enumerator.MoveNext())
                {
                    if (input2Enumerator.MoveNext())
                    {
                        result += $"{input1Enumerator.Current}{input2Enumerator.Current}";
                    }
                    else
                    {
                        result += input1Enumerator.Current;
                    }
                }
                while (input2Enumerator.MoveNext())
                {
                    result += input2Enumerator.Current;
                }
            }
            return result;
        }
    }
}
using System.Collections.Generic;

namespace ReSharperPlugin.RiderDevExpressPlugin.Rider
{
    public class StringByLengthComparer : IComparer<string>
    {
        public static readonly StringByLengthComparer Comparer = new StringByLengthComparer();

        public int Compare(string x, string y)
        {
            var xLength = x?.Length ?? 0;
            var yLength = y?.Length ?? 0;
            return xLength.CompareTo(yLength);
        }
    }
}
using System;
using System.Linq;

namespace TestTools.Comparators
{
    public class BinaryComparator : IFileComparator
    {
        public BinaryComparator()
        {
        }

        public bool Compare(byte[] reference, byte[] result, float margin, out float diffRatio)
        {
            int diffCount = 0;

            int minLength = Math.Min(result.Length, reference.Length);

            if (minLength == 0)
            {
                diffRatio = 1.0f;
                return true;
            }

            float lengthDiff = Math.Abs(result.Length - reference.Length);
            if (margin < 1.0f)
            {
                lengthDiff /= minLength;
            }

            if (lengthDiff > margin)
            {
                diffRatio = lengthDiff;
                return false;
            }

            for (int i = 0; i < minLength; ++i)
            {
                if (reference[i] != result[i])
                {
                    diffCount++;
                }
            }

            diffRatio = diffCount;
            if (margin < 1.0f)
            {
                diffRatio /= minLength;
            }

            return diffRatio <= margin;
        }

        public bool Compare(byte[] reference, byte[] result)
        {
            bool equal = reference.SequenceEqual(result);

            return equal;
        }
    }
}

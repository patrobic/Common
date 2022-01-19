namespace TestTools.Comparators
{
    public interface IFileComparator
    {
        bool Compare(byte[] reference, byte[] result, float margin, out float diffRatio);
    }
}
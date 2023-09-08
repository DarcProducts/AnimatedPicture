namespace darcproducts
{
    public static class Utils
    {
        public static float Remap(float aValue, float aIn1, float aIn2, float aOut1, float aOut2)
        {
            var t = (aValue - aIn1) / (aIn2 - aIn1);
            if (t > 1f)
                return aOut2;
            if (t < 0f)
                return aOut1;
            return aOut1 + (aOut2 - aOut1) * t;
        }
    }
}

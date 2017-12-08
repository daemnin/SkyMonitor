using System;

namespace SkyMonitor.Commons.Extensions
{
    public static class MathExtensions
    {
        public static double ToRadians(this double value)
        {
            return value * (Math.PI / 180);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Business.Extensions
{
    public static class EnumExtension
    {
        public static T NextValue<T>(this T value) where T : Enum
        {
            var values = ((T[])Enum.GetValues(typeof(T))).ToList();
            var index = values.IndexOf(value) + 1;
            if (index >= values.Count)
                index = 0;

            return values[index];
        }
        public static T PreviousValue<T>(this T value) where T : Enum
        {
            var values = ((T[])Enum.GetValues(typeof(T))).ToList();
            var index = values.IndexOf(value) - 1;
            if (index < 0)
                index = values.Count -1;

            return values[index];
        }
    }
}

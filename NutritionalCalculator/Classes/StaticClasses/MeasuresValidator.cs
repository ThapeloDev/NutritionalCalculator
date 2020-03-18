using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes.StaticClasses
{
    static public class MeasuresValidator
    {
        public static bool CheckIfTheyAreNull(float? MassInGr, float? volumeInMl, float? Units)
        {
            return (MassInGr == 0 || MassInGr == null) &&
                   (volumeInMl == 0 || volumeInMl == null) &&
                   (Units == 0 || Units == null);
        }
    }
}

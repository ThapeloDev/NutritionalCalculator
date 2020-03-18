using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes.StaticClasses
{
    public static class NonNullParametersChecker
    {
        public static void checkObjectTypeParameter(object parameter)
        {
            if(parameter == null)
            {
                throw new ArgumentNullException("Parametro nulo");
            }
        }
    }
}

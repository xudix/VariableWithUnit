using System;
using System.Collections.Generic;

namespace VariableWithUnit
{
    /// <summary>
    /// 
    /// </summary>
    public class VariableWithUnit
    {
        public double Value { get; set; }

        public Unit Unit { get; set; }

        public String Prefix { get; set; }

        /// <summary>
        /// Prefixes for SI unit. Call VariableWithUnit.Prefixes["prefix"] will return the corresponding value (Double)
        /// For example, VariableWithUnit.Prefixes["k"] is 1.0e3.
        /// </summary>
        public static readonly Dictionary<String, Double> Prefixes = new Dictionary<string, double>
        {
            {"Y", 1.0e24 },
            {"Z", 1.0e21 },
            {"E", 1.0e18 },
            {"P", 1.0e15 },
            {"T", 1.0e12 },
            {"G", 1.0e9 },
            {"M", 1.0e6 },
            {"k", 1.0e3 },
            {"h", 1.0e2 },
            {"da", 1.0e1 },
            {"", 1.0 },
            {"d", 1.0e-1 },
            {"c", 1.0e-2 },
            {"m", 1.0e-3 },
            {"mu", 1.0e-6 },
            {"n", 1.0e-9 },
            {"p", 1.0e-12 },
            {"f", 1.0e-15 },
            {"a", 1.0e-18 },
            {"z", 1.0e-21 },
            {"y", 1.0e-24 },
        };

        #region Constructors
        public VariableWithUnit(double value, Unit unit, String prefix = "")
        {
            Value = value;
            Unit = unit;
            Prefix = prefix;
        }



        #endregion

        #region Public Methods

        public VariableWithUnit Convert(Unit new_unit, String new_prefix = "")
        {
            if (Unit.IsSameMeasure(new_unit))
            {
                double new_value = Value * Unit.Multiplier * Prefixes[Prefix] / new_unit.Multiplier / Prefixes[new_prefix];
                return new VariableWithUnit(new_value, new_unit, new_prefix);
            }
            else
                return null;
        }

        #endregion


    }


}

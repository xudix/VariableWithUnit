﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VariableWithUnit
{
    public class Unit : Measure
    {
        #region Public Properties

        /// <summary>
        /// Actual name of the unit.
        /// E.g. meter, pound, mega watts, etc.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Symbol of the unit.
        /// E.g. m, lb, MW, etc.
        /// </summary>
        public string UnitSymbol { get; set; }

        /// <summary>
        /// The Multiplier converts the variable under this specific unit to SI value.
        /// The value of the variable multiply by the Multiplier equals the value under SI unit.
        /// E.g. the unit "kilo meter" has a multiplier of 1000; the unit "feet" has a multiplier of 0.3048.
        /// </summary>
        public double Multiplier { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a Unit object.
        /// </summary>
        /// <param name="multiplier">The Multiplier converts the variable under this specific unit to SI value.
        /// The value of the variable multiply by the Multiplier equals the value under SI unit.
        /// E.g. the unit "kilo meter" has a multiplier of 1000; the unit "feet" has a multiplier of 0.3048.
        /// Multiplier should NOT be zero.</param>
        /// <param name="measure">The measure on which this unit will be based on</param>
        /// <param name="unitName">Actual name of the unit.
        /// E.g. meter, pound, mega watts, etc.</param>
        /// <param name="unitSymbol">Symbol of the unit.
        /// E.g. m, lb, MW, etc.</param>
        public Unit(double multiplier, Measure measure, string unitName = "", string unitSymbol = "")
        {
            Multiplier = multiplier;
            PowerOfLength = measure.PowerOfLength;
            PowerOfCurrent = measure.PowerOfCurrent;
            PowerOfTime = measure.PowerOfTime;
            PowerOfTemperature = measure.PowerOfTemperature;
            PowerOfSubstanceAmount = measure.PowerOfSubstanceAmount;
            PowerOfMass = measure.PowerOfMass;
            PowerOfLuminousIntensity = measure.PowerOfLuminousIntensity;
            MeasureName = measure.MeasureName;
            UnitName = unitName;
            UnitSymbol = unitSymbol;
        }
        public Unit(double multiplier, int powerOfLength, int powerOfTime, int powerOfMass, int powerOfSubstanceAmount,
            int powerOfTemperature, int powerOfCurrent, int powerofLuminousIntensity, string measureName = "", string unitName = "", string unitSymbol = "")
        {
            PowerOfLength = powerOfLength;
            PowerOfCurrent = powerOfCurrent;
            PowerOfTime = powerOfTime;
            PowerOfTemperature = powerOfTemperature;
            PowerOfSubstanceAmount = powerOfSubstanceAmount;
            PowerOfMass = powerOfMass;
            PowerOfLuminousIntensity = powerofLuminousIntensity;
            Multiplier = multiplier;
            MeasureName = measureName;
            UnitName = unitName;
            UnitSymbol = unitSymbol;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Find the unit that corresponds to the product of two units.
        /// </summary>
        /// <param name="unit1"></param>
        /// <param name="unit2"></param>
        /// <returns></returns>
        public static Unit MultiplyUnits(Unit unit1, Unit unit2) =>
            new Unit(unit1.Multiplier * unit2.Multiplier, unit1.PowerOfLength + unit2.PowerOfLength, unit1.PowerOfTime + unit2.PowerOfTime,
                unit1.PowerOfMass + unit2.PowerOfMass, unit1.PowerOfSubstanceAmount + unit2.PowerOfSubstanceAmount,
                unit1.PowerOfTemperature + unit2.PowerOfTemperature, unit1.PowerOfCurrent + unit2.PowerOfCurrent,
                unit1.PowerOfLuminousIntensity + unit2.PowerOfLuminousIntensity);

        public static Unit operator *(Unit left, Unit right) =>
            MultiplyUnits(left, right);

        public static Unit DevideUnits(Unit unit1, Unit unit2) =>
            new Unit(unit1.Multiplier / unit2.Multiplier, unit1.PowerOfLength - unit2.PowerOfLength, unit1.PowerOfTime - unit2.PowerOfTime,
                unit1.PowerOfMass - unit2.PowerOfMass, unit1.PowerOfSubstanceAmount - unit2.PowerOfSubstanceAmount,
                unit1.PowerOfTemperature - unit2.PowerOfTemperature, unit1.PowerOfCurrent - unit2.PowerOfCurrent,
                unit1.PowerOfLuminousIntensity - unit2.PowerOfLuminousIntensity);

        public static Unit operator /(Unit left, Unit right) =>
            DevideUnits(left, right);

        public bool Equals(Unit unit) =>
            PowerOfCurrent == unit.PowerOfCurrent &&
            PowerOfLength == unit.PowerOfLength &&
            PowerOfLuminousIntensity == unit.PowerOfLuminousIntensity &&
            PowerOfMass == unit.PowerOfMass &&
            PowerOfSubstanceAmount == unit.PowerOfSubstanceAmount &&
            PowerOfTemperature == unit.PowerOfTemperature &&
            PowerOfTime == unit.PowerOfTime &&
            Multiplier != 0 &&
            (Multiplier-unit.Multiplier) / Multiplier < 1e-9;

        public static bool operator == (Unit left, Unit right) =>
            left.Equals(right);

        public static bool operator !=(Unit left, Unit right) =>
            !left.Equals(right);

        public static bool IsSameUnit(Unit unit1, Unit unit2) =>
            unit1.Equals(unit2);

        public override bool Equals(object o) =>
            base.Equals(o) && Equals((Unit)o); //Is this OK if o is Measure?

        /// <summary>
        /// Determine if this Unit is of the same measure as another unit or measure.
        /// If true, this unit can be converted to the other unit or measure.
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public bool IsSameMeasure(Measure measure) =>
            this == measure;

        #endregion
    }
}

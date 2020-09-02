﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VariableWithUnit
{
    public class Measure
    {
        #region Public Properties
        /// <summary>
        /// Common name for the quantity with this measure, e.g. length, temperature, force, concentration, etc.
        /// Upper case only.
        /// </summary>
        public string MeasureName
        {
            get => name;
            set {
                name = value.ToUpper();
            }
        }
        private string name;

        /// <summary>
        /// Power of Length. The SI unit for length is meter (m).
        /// </summary>
        public int PowerOfLength { get; set; }

        /// <summary>
        /// Power of Time. The SI unit for time is second (s).
        /// </summary>
        public int PowerOfTime { get; set; }

        /// <summary>
        /// Power of Mass. The SI unit for mass is kilogram (kg).
        /// </summary>
        public int PowerOfMass { get; set; }

        /// <summary>
        /// Power of Substance Amount The SI unit for amount of substance is mole (mol).
        /// </summary>
        public int PowerOfSubstanceAmount { get; set; }

        /// <summary>
        /// Power of Temperature. The SI unit for temperature is kelvin (K).
        /// </summary>
        public int PowerOfTemperature { get; set; }

        /// <summary>
        /// Power of Electric Current. The SI unit for current is amp (A).
        /// </summary>
        public int PowerOfCurrent { get; set; }

        /// <summary>
        /// Power ofLuminous Intensity. The SI unit for luminous intensity is candela (cd)
        /// </summary>
        public int PowerOfLuminousIntensity { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Create a Measure object.
        /// </summary>
        /// <param name="powerOfLength"></param>
        /// <param name="powerOfTime"></param>
        /// <param name="powerOfMass"></param>
        /// <param name="powerOfSubstanceAmount"></param>
        /// <param name="powerOfTemperature"></param>
        /// <param name="powerOfCurrent"></param>
        /// <param name="powerofLightIntensity"></param>
        /// <param name="Name">Common name for the quantity with this measure, e.g. length, temperature, force, concentration, etc.</param>
        public Measure(int powerOfLength, int powerOfTime, int powerOfMass, int powerOfSubstanceAmount,
            int powerOfTemperature, int powerOfCurrent, int powerofLightIntensity, string measureName)
        {
            PowerOfLength = powerOfLength;
            PowerOfCurrent = powerOfCurrent;
            PowerOfTime = powerOfTime;
            PowerOfTemperature = powerOfTemperature;
            PowerOfSubstanceAmount = powerOfSubstanceAmount;
            PowerOfMass = powerOfMass;
            PowerOfLuminousIntensity = powerofLightIntensity;
            MeasureName = measureName;
        }

        /// <summary>
        /// Create a Measure object.
        /// </summary>
        /// <param name="powerOfLength"></param>
        /// <param name="powerOfTime"></param>
        /// <param name="powerOfMass"></param>
        /// <param name="powerOfSubstanceAmount"></param>
        /// <param name="powerOfTemperature"></param>
        /// <param name="powerOfCurrent"></param>
        /// <param name="powerofLightIntensity"></param>
        public Measure(int powerOfLength, int powerOfTime, int powerOfMass, int powerOfSubstanceAmount,
            int powerOfTemperature, int powerOfCurrent, int powerofLightIntensity)
        {
            PowerOfLength = powerOfLength;
            PowerOfCurrent = powerOfCurrent;
            PowerOfTime = powerOfTime;
            PowerOfTemperature = powerOfTemperature;
            PowerOfSubstanceAmount = powerOfSubstanceAmount;
            PowerOfMass = powerOfMass;
            PowerOfLuminousIntensity = powerofLightIntensity;
            MeasureName = ""; // Default name to be added
        }

        public Measure()
        {
            PowerOfCurrent = 0;
            PowerOfLength = 0;
            PowerOfLuminousIntensity = 0;
            PowerOfMass = 0;
            PowerOfSubstanceAmount = 0;
            PowerOfTemperature = 0;
            PowerOfTime = 0;
            MeasureName = "NUMBER";
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Compares whether two measures are the same. They are the same if the power of all quantities are the same.
        /// </summary>
        /// <param name="measure">Another measure to be compared</param>
        /// <returns></returns>
        public bool IsSameMeasure(Measure measure) =>
            this.PowerOfCurrent == measure.PowerOfCurrent &&
            this.PowerOfLength == measure.PowerOfLength &&
            this.PowerOfLuminousIntensity == measure.PowerOfLuminousIntensity &&
            this.PowerOfMass == measure.PowerOfMass &&
            this.PowerOfSubstanceAmount == measure.PowerOfSubstanceAmount &&
            this.PowerOfTemperature == measure.PowerOfTemperature &&
            this.PowerOfTime == measure.PowerOfTime;

        /// <summary>
        /// Compares whether two measures are the same. They are the same if the power of all quantities are the same.
        /// </summary>
        /// <param name="measure1">1st Measure to be compared</param>
        /// <param name="measure2">2nd Measure to be compared</param>
        /// <returns></returns>
        public static bool IsSameMeasure(Measure measure1, Measure measure2) =>
            measure1.IsSameMeasure(measure2);

        public static bool Equals(Measure measure1, Measure measure2)

        #endregion
    }
}

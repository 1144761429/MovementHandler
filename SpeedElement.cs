using StackableElement;

namespace SpeedHandler
{
    /// <summary>
    /// The enum that catagorize the SpeedElement.
    /// </summary>
    public enum SpeedType
    {
        Basic,
        Environmental,
        Buff
    }

    /// <summary>
    /// The basic unit that calculate how the speed of a GameObject should be.
    /// </summary>
    /// <typeparam name="TSpeedElementId">A class used for differentiating each SpeedElement.</typeparam>
    public class SpeedElement<TSpeedElementId> : StackableElement<TSpeedElementId>
    {
        /// <summary>
        /// The type of a SpeedElement
        /// </summary>
        public SpeedType Type { get; private set; }

        /// <summary>
        /// Constructor for a SpeedElment with a initial Stack of 1
        /// </summary>
        /// <param name="name">The Name of a SpeedElement</param>
        /// <param name="value">The Value of a SpeedElement</param>
        /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
        /// <param name="speedType">The type of a SpeedElement.</param>
        public SpeedElement(TSpeedElementId name, float value, bool isExclusive, SpeedType speedType) : base(name, value, isExclusive)
        {
            Type = speedType;
            DefaultMinStack = 0;
            DefaultMaxStack = 99;
        }

        /// <summary>
        /// Calculate the overall value of a SpeedElement, which is Value multiplied by Stack.
        /// </summary>
        /// <returns>The overall value: Value * Stack.</returns>
        public float GetOverallValue()
        {
            return Value * Stack;
        }
    }
}



using StackableElement;
using System.Buffers.Text;

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

        public SpeedElement(TSpeedElementId name, float value, bool isExclusive, SpeedType speedType) : base(name, value, isExclusive)
        {
            Type = speedType;
            DefaultMinStack = 0;
            DefaultMaxStack = 99;
        }
    }
}



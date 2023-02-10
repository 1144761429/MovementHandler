using UnityEngine;


/// <summary>
/// The enum that catagorize the SpeedElement.
/// </summary>
public enum ESpeedType
{
    Basic,
    Environmental,
    Buff
}

/// <summary>
/// The basic unit that calculate how the speed of a GameObject should be.
/// </summary>
public class SpeedElement : FloatStackableElement
{
    /// <summary>
    /// The type of a SpeedElement
    /// </summary>
    private ESpeedType _type;
    /// <summary>
    /// The object that exerts the SpeedElement
    /// </summary>
    private GameObject _source;

    public ESpeedType Type { get { return _type; } }
    public GameObject Source { get { return _source; } }


    /// <summary>
    /// Constructor for a SpeedElment with a initial Stack of 1.
    /// </summary>
    /// <param name="value">The Value of a SpeedElement.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    /// <param name="speedType">The type of a SpeedElement.</param>
    public SpeedElement(float value, bool isExclusive, ESpeedType speedType, GameObject source = null) : base(value, isExclusive)
    {
        _type = speedType;
        _source = source;
        DefaultMinStack = 0;
        DefaultMaxStack = 99;
    }

    /// <summary>
    /// Constructor for a SpeedElment with a specified initial Stack number.
    /// </summary>
    /// <param name="value">The Value of a SpeedElement.</param>
    /// <param name="stack">The initial Stack number.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    /// <param name="speedType">The type of a SpeedElement.</param>
    public SpeedElement(float value, int stack, bool isExclusive, ESpeedType speedType, GameObject source = null) : base(value, stack, isExclusive)
    {
        _type = speedType;
        _source = source;
        DefaultMinStack = -99;
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




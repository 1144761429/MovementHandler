using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDirectionType
{
    Basic,
    Environmental,
    Buff
}

/// <summary>
/// The basic unit that calculate in which direciton a GameObject moves.
/// </summary>
public class DirectionElement : Vector3StackableElement
{
    private EDirectionType _type;
    private GameObject _source;

    public EDirectionType Type { get { return _type; } }
    public GameObject Source { get { return _source; } }

    /// <summary>
    /// Constructor for a DirectionElement with a initial Stack of 1.
    /// </summary>
    /// <param name="value">The Value of a DirectionElement.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    /// <param name="directionType">The type of a DirectionElement.</param>
    public DirectionElement(Vector3 value, bool isExclusive, EDirectionType directionType, GameObject source = null) : base(value, isExclusive)
    {
        _type = directionType;
        _source = source;
        DefaultMinStack = 0;
        DefaultMaxStack = 99;
    }

    /// <summary>
    /// Constructor for a DirectionElement with a specified initial Stack number.
    /// </summary>
    /// <param name="value">The Value of a DirectionElement.</param>
    /// <param name="stack">The initial Stack number.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    /// <param name="directionType">The type of a DirectionElement.</param>
    public DirectionElement(Vector3 value, int stack, bool isExclusive, EDirectionType directionType, GameObject source = null) : base(value, stack, isExclusive)
    {
        _type = directionType;
        _source = source;
        DefaultMinStack = -99;
        DefaultMaxStack = 99;
    }

    /// <summary>
    /// Calculate the overall value of a DirectionElement, which is Value multiplied by Stack.
    /// </summary>
    /// <returns>The overall value: Value * Stack.</returns>
    public Vector3 GetOverallValue()
    {
        return Value * Stack;
    }
}

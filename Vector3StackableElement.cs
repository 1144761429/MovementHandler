using System;
using UnityEngine;

public class Vector3StackableElement : StackableElementBase
{
    private Vector3 _value;

    public Vector3 Value { get { return _value; } protected set { _value = value; } }

    /// <summary>
    /// Constructor for Vector3StackableElement object with a inital stack of 0.
    /// </summary>
    /// <param name="value">The value of a StackableElement.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    public Vector3StackableElement(Vector3 value, bool isExclusive) : base(isExclusive)
    {
        _value = value;
    }

    /// <summary>
    /// Constructor for Vector3StackableElement object with a specified stack.
    /// </summary>
    /// <param name="value">The value of a StackableElement.</param>
    /// <param name="stack">The initial Stack number.</param>
    /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
    public Vector3StackableElement(Vector3 value, int stack, bool isExclusive) : base(stack, isExclusive)
    {
        _value = value;
    }

    #region Public Methods
    /// <summary>
    /// Return the string repesentation of a StackableElement.
    /// </summary>
    /// <returns>The String representation of a StackableElement.</returns>
    public override string ToString()
    {
        return $"Stack: {_stack},  Value: {_value},  IsExclusive: {_isExclusive},  IsFrozen: {_isFrozen},"
            + $"MinStack: {_minStack},  MaxStack: {_maxStack}.";
    }

    /// <summary>
    /// Compare if two StackableElements are equal.
    /// </summary>
    /// <param name="obj">The other comparing object</param>
    /// <returns>True if two StackableElements have the same Value and Stack. False if they do not have the same poperties.</returns>
    public override bool Equals(object obj)
    {
        if (obj is not FloatStackableElement)
        {
            return false;
        }

        return _value == ((Vector3StackableElement)obj)._value && _stack == ((Vector3StackableElement)obj)._stack;
    }

    /// <summary>
    /// Return the HashCode value of a StackableElement.
    /// </summary>
    /// <returns>Return the HashCode value of a StackableElement.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(_value, _stack);
    }
    #endregion
}


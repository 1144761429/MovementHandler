using System;
using UnityEngine;

public struct MovementElement
{
    public float Speed;
    public Vector3 Direction;
    /// <summary>
    /// If true, the MovementElement will be included in the calculation of velocity in a SpeedHandler.
    /// If false, the MovementElement will not be included.
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// Constructor for a MovementElement with a initial IsActive set to true.
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="direction"></param>
    public MovementElement(float speed, Vector3 direction)
    {
        Speed = speed;
        Direction = direction;
        IsActive = true;
    }

    /// <summary>
    /// The velocity of the MovementElement, which is SPeed * Direction;
    /// </summary>
    public Vector3 Velocity
    {
        get { return Speed * Direction; }
    }

    public static Vector3 operator +(MovementElement element1, MovementElement element2)
    {
        Vector3 velocity = element1.Velocity + element2.Velocity;
        return velocity;
    }

    public static Vector3 operator -(MovementElement element1, MovementElement element2)
    {
        Vector3 velocity = element1.Velocity - element2.Velocity;
        return velocity;
    }

    public static bool operator ==(MovementElement element1, MovementElement element2)
    {
        return element1.Speed == element2.Speed && element1.Direction == element2.Direction;
    }

    public static bool operator !=(MovementElement element1, MovementElement element2)
    {
        return element1.Speed != element2.Speed || element1.Direction != element2.Direction;
    }

    public override bool Equals(object obj)
    {
        return obj is MovementElement element &&
               Speed == element.Speed &&
               Direction == element.Direction;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Speed, Direction);
    }
}



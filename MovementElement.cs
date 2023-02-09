using System;
using Unity.VisualScripting;
using UnityEngine;

public struct MovementElement
{
    public float Speed;
    public Vector3 Direction;

    public MovementElement(float speed, Vector3 direction)
    {
        Speed = speed;
        Direction = direction;
    }

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



using System;
using UnityEngine;

//In the first constuctor, ESpeedType will be replaced later by a class of Enum that lists all speed ID.
//In the first constuctor, EDirectionType will be replaced later by a class of Enum that lists all direction ID.

public class MovementElement
{
    private SpeedHandler<ESpeedType> _speedHandler;
    private DirectionHandler<EDirectionType> _directionHandler;
    private bool _isActive;

    /// <summary>
    /// If true, the MovementElement will be included in the calculation of velocity in a SpeedHandler.
    /// If false, the MovementElement will not be included.
    /// </summary>
    public bool IsActive { get { return _isActive; } }
    /// <summary>
    /// The velocity of the MovementElement, which is Speed * Direction;
    /// </summary>
    public Vector3 Velocity
    {
        get { return _speedHandler.CalculateSpeed() * _directionHandler.CalculateDirection(); }
    }

    /// <summary>
    /// Constructor for a MovementElement with initial IsActive set to true, 
    /// and create a SpeedElement with ESpeedType.Basic and Stack of 1 stored in the SpeedHandler.
    /// </summary>
    /// <param name="speed">The speed of a MovementElement.</param>
    /// <param name="direction">The direction of a MovementElement.</param>
    public MovementElement(float speed, Vector3 direction)
    {
        _isActive = true;
        _speedHandler = new SpeedHandler<ESpeedType>();
        _speedHandler.TryAddSpeedElement(ESpeedType.Basic, new SpeedElement(speed, 1, true, ESpeedType.Basic));
        _directionHandler = new DirectionHandler<EDirectionType>();
        _directionHandler.TryAddDirectionElement(EDirectionType.Basic, new DirectionElement(direction, 1, true, EDirectionType.Basic));
    }

    /// <summary>
    /// Constructor for a MovementElement with a initial IsActive set according to parameter isActive,
    /// and create a SpeedElement with ESpeedType.Basic and Stack of 1 stored in the SpeedHandler.
    /// </summary>
    /// <param name="speed">The speed of a MovementElement.</param>
    /// <param name="direction">The direction of a MovementElement.</param>
    /// <param name="isActive">If the MovementElement is active.</param>
    public MovementElement(float speed, Vector3 direction, bool isActive)
    {
        _isActive = isActive;
        _speedHandler = new SpeedHandler<ESpeedType>();
        _speedHandler.TryAddSpeedElement(ESpeedType.Basic, new SpeedElement(speed, 1, true, ESpeedType.Basic));
        _directionHandler = new DirectionHandler<EDirectionType>();
        _directionHandler.TryAddDirectionElement(EDirectionType.Basic, new DirectionElement(direction, 1, true, EDirectionType.Basic));
    }

    /// <summary>
    /// Get a SpeedElement from the SpeedHandler in the MovementHandler.
    /// </summary>
    /// <param name="SpeedType">The ID of the target SpeedType.</param>
    /// <returns>The target SpeedElement。</returns>
    public SpeedElement GetSpeedElement(ESpeedType SpeedType)
    {
        return _speedHandler.GetSpeedElement(SpeedType);
    }

    /// <summary>
    /// Change the IsActive status of a MovementElement.
    /// </summary>
    /// <param name="isActive">The MovementElement will be active if true, and not active if false.</param>
    public void SetActive(bool isActive)
    {
        _isActive = isActive;
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
        return element1._speedHandler.CalculateSpeed() == element2._speedHandler.CalculateSpeed() &&
            element1._directionHandler.CalculateDirection() == element2._directionHandler.CalculateDirection();
    }

    public static bool operator !=(MovementElement element1, MovementElement element2)
    {
        return element1._speedHandler.CalculateSpeed() != element2._speedHandler.CalculateSpeed() ||
            element1._directionHandler.CalculateDirection() != element2._directionHandler.CalculateDirection();
    }

    public override string ToString()
    {
        return $"Speed: {_speedHandler.CalculateSpeed()}, Direction: {_directionHandler.CalculateDirection()}, IsActive: {IsActive}.";
    }

    public override bool Equals(object obj)
    {
        return obj is MovementElement element &&
               _speedHandler.CalculateSpeed() == element._speedHandler.CalculateSpeed() &&
               _directionHandler.CalculateDirection() == element._directionHandler.CalculateDirection();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_speedHandler.CalculateSpeed(), _directionHandler.CalculateDirection());
    }
}



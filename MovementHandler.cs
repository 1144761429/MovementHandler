using System.Collections.Generic;
using UnityEngine;

public class MovementHandler<TMovementElementId>
{
    private Dictionary<TMovementElementId, MovementElement> _dict;

    public MovementHandler()
    {
        _dict = new Dictionary<TMovementElementId, MovementElement>();
    }

    public bool TryAddMovementElement(TMovementElementId movementElementId, MovementElement movementElement)
    {
        return _dict.TryAdd(movementElementId, movementElement);
    }

    public bool TryRemoveMovementElement(TMovementElementId movementElementId)
    {
        return _dict.Remove(movementElementId);
    }

    public Vector3 CalculateVelocity()
    {
        Dictionary<TMovementElementId, MovementElement>.ValueCollection movementElements = _dict.Values;
        Vector3 finalVelocity = new Vector3();

        foreach (MovementElement movementElement in movementElements)
        {
            finalVelocity += movementElement.Velocity;
        }

        return finalVelocity;
    }
}



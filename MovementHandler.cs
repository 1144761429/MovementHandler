using System.Collections.Generic;
using UnityEngine;

public class MovementHandler<TMovementElementId> where TMovementElementId : notnull
{
    /// <summary>
    /// Dictionary that stores the MovementElement as the Value with a ID of it as the Key.
    /// </summary>
    private Dictionary<TMovementElementId, MovementElement> _dict;

    /// <summary>
    /// COnstructor for a MovementHandler that create an empty Dictionary<TMovementElementId, MovementElement>.
    /// </summary>
    public MovementHandler()
    {
        _dict = new Dictionary<TMovementElementId, MovementElement>();
    }

    /// <summary>
    /// Try to add a MovementElement with an ID to the MovementHandler.
    /// </summary>
    /// <param name="movementElementId">A ID of a MovementElement.</param>
    /// <param name="movementElement">A MovementElement.</param>
    /// <returns>True if successfully added a MovementElement to the MovementHandler.
    /// False if addition failed, meaning the ID already exists.</returns>
    public bool TryAddMovementElement(TMovementElementId movementElementId, MovementElement movementElement)
    {
        return _dict.TryAdd(movementElementId, movementElement);
    }

    /// <summary>
    /// Try to remove a MovementElement by an ID from the MovementHandler.
    /// </summary>
    /// <param name="movementElementId">An ID of a MovementElemente.</param>
    /// <returns><True if successfully removed a MovementElement from the MovementHandler.
    /// False if removal failed, meaning the ID does not exist./returns>
    public bool TryRemoveMovementElement(TMovementElementId movementElementId)
    {
        return _dict.Remove(movementElementId);
    }

    /// <summary>
    /// Calculate the Velocity of the MovementHandler which is the sum of all active MovementElements.
    /// </summary>
    /// <returns>The sum of all the MovementELement.</returns>
    public Vector3 CalculateVelocity()
    {
        Vector3 finalVelocity = new Vector3();

        foreach (MovementElement movementElement in _dict.Values)
        {
            if(movementElement.IsActive)
                finalVelocity += movementElement.Velocity;
        }

        return finalVelocity;
    }

    /// <summary>
    /// Get a MovementElment from 
    /// </summary>
    /// <param name="movementElementId"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public MovementElement GetMovementElement(TMovementElementId movementElementId)
    {
        if (!_dict.ContainsKey(movementElementId))
        {
            throw new ArgumentException($"MovementElementId {movementElementId} does not exist in the MovementHandler.");
        }

        return _dict[movementElementId];
    }

    /// <summary>
    /// Remove all the MovementElement from the MovementHandler.
    /// </summary>
    public void Clear()
    {
        _dict.Clear();
    }

}



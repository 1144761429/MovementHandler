using System;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHandler<TDirectionElementId>
{
    private Dictionary<TDirectionElementId, DirectionElement> _dict;

    /// <summary>
    /// The final speed of a DirectionHandler after calculation
    /// </summary>
    public float Speed { get; private set; }
    /// <summary>
    /// The number of DirectionElement in the DirectionHandler.
    /// </summary>
    public int DirectionElementCount { get { return _dict.Count; } }
    /// <summary>
    /// The number of DirectionElement that has a Stack of not 0 in the DirectionHandler.
    /// </summary>
    public int ActiveDirectionElementCount { get; private set; }

    /// <summary>
    /// Constructor for a DirectionHandler
    /// </summary>
    public DirectionHandler()
    {
        _dict = new Dictionary<TDirectionElementId, DirectionElement>();
    }

    /// <summary>
    /// Calculate the Speed of a DirectionHandler by sum up the overall value of each DirectionElement.
    /// </summary>
    /// <returns>The speed of  a DirectionHandler.</returns>
    public Vector3 CalculateSpeed()
    {
        Vector3 finalDirection = Vector3.zero;

        foreach (DirectionElement directionElement in _dict.Values)
        {
            finalDirection += directionElement.GetOverallValue();
        }

        return finalDirection;
    }

    /// <summary>
    /// Get a DirectionElement in the DirectionHandler.
    /// </summary>
    /// <param name="directionElementId">The DirectionElement that is going to get.</param>
    /// <returns>The target DirectionElement.</returns>
    /// <exception cref="ArgumentException">DirectionElement with DirectionElement does not exist in the DirectionHandler.</exception>
    public DirectionElement GetDirectionElement(TDirectionElementId directionElementId)
    {
        if (!_dict.ContainsKey(directionElementId))
        {
            throw new ArgumentException($"DirectionElement {directionElementId} does not exist in the DirectionHandler.");
        }

        return _dict[directionElementId];
    }

    /// <summary>
    /// Add a DirectionElement to the DirectionHandler.
    /// </summary>
    /// <param name="directionElementId">The ID of a DirectionElement.</param>
    /// <param name="directionElement">The actual data of a DirectionElement.</param>
    public bool TryAddDirectionElement(TDirectionElementId directionElementId, DirectionElement directionElement)
    {
        return _dict.TryAdd(directionElementId, directionElement);
    }

    /// <summary>
    /// Remove a DirectionElement from the DirectionHandler.
    /// </summary>
    /// <param name="directionElementId">The ID of a DirectionElement.</param>
    public bool RemoveDirectionElement(TDirectionElementId directionElementId)
    {
        return _dict.Remove(directionElementId);
    }

    /// <summary>
    /// Remove all the TDirectionElement and DirectionElement from a DirectionHandler.
    /// </summary>
    public void Clear()
    {
        _dict.Clear();
    }

    /// <summary>
    /// Change the Stack of a DirectionElement to a specified number.
    /// </summary>
    /// <param name="directionElementId">The ID of the DirectionElement.</param>
    /// <param name="stack">The target Stack number.</param>
    /// <exception cref="ArgumentException">DirectionElement with TSpeedElementId does not exist in the DirectionHandler.</exception>
    public void SetDirectionElementStack(TDirectionElementId directionElementId, int stack)
    {
        if (!_dict.ContainsKey(directionElementId))
        {
            throw new ArgumentException($"DirectionElement {directionElementId} does not exist in the DirectionHandler.");
        }

        _dict[directionElementId].SetStack(stack);
    }
}

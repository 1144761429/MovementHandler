using System;
using System.Collections;
using System.Collections.Generic;
using StackableElement;

namespace SpeedHandler
{
    public class SpeedHandler<TSpeedElementId> where TSpeedElementId :notnull
    {
        private Dictionary<TSpeedElementId, SpeedElement<TSpeedElementId>> _dict;

        /// <summary>
        /// The final speed of a SpeedHandler after calculation
        /// </summary>
        public float Speed { get; private set; }
        /// <summary>
        /// The number of SpeedElement in the SpeedHandler.
        /// </summary>
        public int SpeedElementCount { get { return _dict.Count; } }
        /// <summary>
        /// The number of SpeedElment that has a Stack of not 0 in the SpeedHandler.
        /// </summary>
        public int ActiveSpeedElementCount { get; private set; }

        /// <summary>
        /// Constructor for a SpeedHandler
        /// </summary>
        public SpeedHandler()
        {
            _dict = new Dictionary<TSpeedElementId, SpeedElement<TSpeedElementId>>();
        }

        /// <summary>
        /// Calculate the Speed of a SpeedHandler by sum up the overall value of each SpeedElement.
        /// </summary>
        /// <returns>The speed of  a SpeedHandler.</returns>
        public float CalculateSpeed()
        {
            Dictionary<TSpeedElementId, SpeedElement<TSpeedElementId>>.ValueCollection speedElements = _dict.Values;
            float finalSpeed = 0;

            foreach (SpeedElement<TSpeedElementId> speedElement in _dict.Values)
            {
                finalSpeed += speedElement.GetOverallValue();
            }

            return finalSpeed;
        }

        public SpeedElement<TSpeedElementId> GetSpeedElement(TSpeedElementId speedElementId)
        {
            
        }

        /// <summary>
        /// Add a SpeedElement to the SpeedHandler.
        /// </summary>
        /// <param name="speedElementId">The ID of a SpeedElement.</param>
        /// <param name="speedElement">The actual data of a SpeedElement.</param>
        public bool TryAddSpeedElement(TSpeedElementId speedElementId, SpeedElement<TSpeedElementId> speedElement)
        {
            //return _dict.TryAdd(speedElementId, speedElement);
            return true;
        }

        /// <summary>
        /// Remove a SpeedElement from the SpeedHandler.
        /// </summary>
        /// <param name="speedElementId">The ID of a SpeedElement.</param>
        public bool RemoveSpeedElement(TSpeedElementId speedElementId)
        {
            return _dict.Remove(speedElementId);
        }

        /// <summary>
        /// Remove all the TSpeedElementId and SpeedElement from a SpeedHandler.
        /// </summary>
        public void Clear()
        {
            _dict.Clear();
        }

        /// <summary>
        /// Change the Stack of a SpeedElement to a specified number.
        /// </summary>
        /// <param name="speedElementId">The ID of the SpeedElement.</param>
        /// <param name="stack">The target Stack number.</param>
        /// <exception cref="ArgumentException">SpeedElement with TSpeedElementId does not exist in the SpeedHandler.</exception>
        public void SetSpeedElementStack(TSpeedElementId speedElementId, int stack)
        {
            if (!_dict.ContainsKey(speedElementId))
            {
                throw new ArgumentException($"SpeedElement {speedElementId} does not exist in the SpeedHandler.");
            }

            _dict[speedElementId].SetStack(stack);
        }
    }

}


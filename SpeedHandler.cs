using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StackableElement;

namespace SpeedHandler
{
    public enum SpeedType
    {
        WalkSpeed
    }

    public class SpeedHandler<TSpeedId> : MonoBehaviour
    {
        private Dictionary<TSpeedId, float> dict;
    }

}


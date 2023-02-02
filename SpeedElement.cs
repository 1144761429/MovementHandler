using System;
using System.Collections.Generic;

namespace StackableElement
{

    class StackableElement<TDataId>
    {
        public const int DefaultMaxStack = 999;

        public TDataId Name { get; protected set; }
        public float Value { get; protected set; }
        public int Stack { get; protected set; }
        /// <summary>
        /// If a StackableElement can have multiple(more than 1) stacks.
        /// </summary>
        public bool IsStackable { get; protected set; }
        /// <summary>
        /// The maximum stack a StackableElement can have. This is set to 999 if it is not specified.
        /// </summary>
        public int MaxStack { get; protected set; }

        /// <summary>
        /// Constructor for a StackableElement object with a inital stack of 1 and customized stackability.
        /// </summary>
        /// <param name="name">The name of the StackableElement</param>
        /// <param name="value">The value of the StackableElement</param>
        /// <param name="stackable">If the StackableElement can have multiple stacks</param>
        public StackableElement(TDataId name, float value, bool stackable)
        {
            Value = value;
            Name = name;
            Stack = 1;
            IsStackable = stackable;
            MaxStack = IsStackable ? DefaultMaxStack : 1;
        }


        #region Public Methods
        public void SetStack(int stack)
        {
            if (stack > 1 && IsStackable)
            {
                Stack = stack;
            }
            else
            {

            }
        }
        public float GetOverallValue()
        {
            return Value * Stack;
        }
        #endregion

    }

    class SpeedElement<TSpeedId> : StackableElement<TSpeedId>
    {
        public SpeedElement(TSpeedId name, float value, bool isStackable) : base(name, value, isStackable) { }
        public SpeedElement(TSpeedId name, float value, int stack) : base(name, value, stack) { }

    }
}

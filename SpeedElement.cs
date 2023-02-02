using System;
using System.Collections.Generic;

namespace StackableElement
{

    class StackableElement<TDataId>
    {
        public const int DefaultMaxStack = 999;

        /// <summary>
		/// The name of a StackableElement with a generic type
		/// </summary>
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
        /// <summary>
		/// Try to add specified number of Stacks to a StackableElement.
		/// </summary>
		/// <param name="stack">The number of Stack that will be added.</param>
		/// <returns>True if adding stack is viable, meaning the result Stack is lesser than or equal to MaxStack, and property Stack will be added accordingly.
		/// False if the property Stack is grerater than the MaxStack after calling this method, and no action will be taken</returns>
        public bool TryAddStack(int stack)
        {
            if (!IsStackable)
            {

            }

            if (Stack + stack <= MaxStack)
            {
                Stack += stack;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// Add specified number of Stacks to a StackableElement.
		/// If the result of addition ends up in having more Stacks than MaxStack, trim Stack to equal to MaxStack.
		/// </summary>
		/// <param name="stack">The number of Stack that will be added.</param>
        public void AddStackTrim(int stack)
        {
            Stack = (Stack + stack > MaxStack) ? MaxStack : (Stack + stack);
        }

        /// <summary>
        /// Try to remove specified number of Stacks to a StackableElement.
        /// </summary>
        /// <param name="stack">The number of Stack that will be removed.</param>
        /// <returns>True if the result Stack is greater than or equal to 0, and property Stack will be removed accordingly.
        /// False if the property Stack is negative after calling this method, and no action will be taken.</returns>
        public bool TryRemoveStack(int stack)
        {
            if (Stack + stack <= MaxStack)
            {
                Stack += stack;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// emove specified number of Stacks to a StackableElement.
		/// If the result of addition ends up in having a negative, trim Stack to equal to MaxStack.
		/// </summary>
		/// <param name="stack">The number of Stack that will be removed.</param>
        public void RemoveStackTrim(int stack)
        {
            Stack = (Stack - stack < 0) ? 0 : (Stack - stack);
        }

        /// <summary>
		/// Set the property Stack to ta specified number.
		/// If the parameter stack is greater than the MaxStack, throw a StackOutOfBoundException.
		/// </summary>
		/// <param name="stack">The number of Stack that will be set to.</param>
        public void SetStack(int stack)
        {
            if (stack > MaxStack) {
                throw new StackOutOfBoundException(stack, new int[] { 0, MaxStack }, Name.ToString());
            }
            else
            {
                Stack = stack;
            }
        }

        /// <summary>
        /// Change the property isStackable of a StackableElement.
        /// </summary>
        /// <param name="isStackable">A bool value that determines if a Stackable can have multiple stacks.</param>
        public void SetIsStackble(bool isStackable)
        {
            IsStackable = isStackable;
        }

        /// <summary>
		/// Calculate the overall value of a StackableElement, which is product of property Stack and Value.
		/// </summary>
		/// <returns>The overall value: Value times Stack.</returns>
        public float GetOverallValue()
        {
            return Value * Stack;
        }
        #endregion

    }

    class SpeedElement<TSpeedId> : StackableElement<TSpeedId>
    {
        public SpeedElement(TSpeedId name, float value, bool isStackable) : base(name, value, isStackable) { }

    }
}

using System;
using System.Collections.Generic;

namespace StackableElement
{
    class StackableElement<TDataId>
    {
        public const int DefaultMaxStack = 999;
        public const int DefaultMinStack = 0;

        /// <summary>
	/// The name of a StackableElement with a generic type
	/// </summary>
        public TDataId Name { get; protected set; }
        public float Value { get; protected set; }
        public int Stack { get; protected set; }
        /// <summary>
        /// If a StackableElement can have multiple(more than 1) stacks.
        /// </summary>
        public bool IsExclusive { get; protected set; }
        /// <summary>
        /// The minimum stack a StackableElement can have. This is set to 0 if it is not specified.
        /// </summary>
        public int MinStack { get; protected set; }
        /// <summary>
        /// The maximum stack a StackableElement can have. This is set to 999 if it is not specified.
        /// </summary>
        public int MaxStack { get; protected set; }

        /// <summary>
        /// Constructor for a StackableElement object with a inital stack of 1 and customized stackability.
        /// </summary>
        /// <param name="name">The name of the StackableElement</param>
        /// <param name="value">The value of the StackableElement</param>
        /// <param name="isExclusive">If the StackableElement can have multiple stacks</param>
        public StackableElement(TDataId name, float value, bool isExclusive)
        {
            Value = value;
            Name = name;
            Stack = 1;
            IsExclusive = isExclusive;
            MinStack = DefaultMinStack;
            MaxStack = IsExclusive ? DefaultMaxStack : 1;
        }


        #region Public Methods
        /// <summary>
	/// Try to add specified number of Stacks to a StackableElement.
	/// </summary>
	/// <param name="stack">The number of Stack that will be added. CANNOT be negative.</param>
	/// <returns>True if adding stack is viable, meaning the result Stack is lesser than or equal to MaxStack, and property Stack will be added accordingly.
	/// False if the property Stack is grerater than the MaxStack after calling this method, and no action will be taken</returns>
        public bool TryAddStack(int stack)
        {
            if (stack < 0)
            {
                throw new ArgumentException($"Adding a negative value of stack is not allowed. Stackable Element: {Name}, OperationStack: {stack}.");
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
	/// <param name="stack">The number of Stack that will be added. CANNOT be negative.</param>
        public void AddStackTrim(int stack)
        {
            if (stack < 0)
            {
                throw new ArgumentException($"Adding a negative value of stack is not allowed. Stackable Element: {Name}, OperationStack: {stack}.");
            }

            Stack = (Stack + stack > MaxStack) ? MaxStack : (Stack + stack);
        }

        /// <summary>
        /// Try to remove specified number of Stacks to a StackableElement.
        /// </summary>
        /// <param name="stack">The number of Stack that will be removed. CANNOT be negative.</param>
        /// <returns>True if the result Stack is greater than or equal to 0, and property Stack will be removed accordingly.
        /// False if the property Stack is negative after calling this method, and no action will be taken.</returns>
        public bool TryRemoveStack(int stack)
        {
            if (stack < 0)
            {
                throw new ArgumentException($"Removing a negative value of stack is not allowed. Stackable Element: {Name}, OperationStack: {stack}.");
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
	/// emove specified number of Stacks to a StackableElement.
	/// If the result of addition ends up in having a negative, trim Stack to equal to MaxStack.
	/// </summary>
	/// <param name="stack">The number of Stack that will be removed. CANNOT be negative.</param>
        public void RemoveStackTrim(int stack)
        {
            if (stack < 0)
            {
                throw new ArgumentException($"Removing a negative value of stack is not allowed. Stackable Element: {Name}, OperationStack: {stack}.");
            }

            Stack = (Stack - stack < MinStack) ? MinStack : (Stack - stack);
        }

        /// <summary>
	/// Set the property Stack to ta specified number.
	/// If the parameter stack is greater than the MaxStack, throw a StackOutOfBoundException.
	/// </summary>
	/// <param name="stack">The number of Stack that will be set to.</param>
        public void SetStack(int stack)
        {
            if (stack > MaxStack) {
                throw new StackOutOfBoundException(Name.ToString(), Stack, stack, MinStack, MaxStack);
            }
            else
            {
                Stack = stack;
            }
        }

        /// <summary>
        /// Change the property IsExclusive of a StackableElement.
        /// </summary>
        /// <param name="isExclusive">A bool value that determines if a Stackable can have multiple stacks.</param>
        public void SetIsExclusive(bool isExclusive)
        {
            IsExclusive = IsExclusive;
        }

        /// <summary>
        /// Change the MaxStack of a StackableElement. If the new MaxStack excludes Stack, set Stack to the new MaxStack first.
        /// </summary>
        /// <param name="maxStack">The target value of MaxStack a StackableElement would have.</param>
        public void SetMaxStack(int maxStack)
        {
            if (maxStack < MinStack)
            {
                throw new ArgumentException($"Attempting to change the MaxStack of {Name} from {MaxStack} to {maxStack} which is smaller than {MinStack}. "
                    + "MaxStack has to be larger than MinStack.");
            }

            if (maxStack < Stack)
            {
                SetStack(maxStack);
            }

            MaxStack = maxStack;
        }

        /// <summary>
        /// Change the MinStack of a StackableElement. If the new MinStack excludes Stack, set Stack to the new MinStack first.
        /// </summary>
        /// <param name="maxStack">The target value of MaxStack a StackableElement would have.</param>
        public void SetMinStack(int minStack)
        {
            if (minStack > MaxStack)
            {
                throw new ArgumentException($"Attempting to change the MinStack of {Name} from {MinStack} to {minStack} which is larger than {MaxStack}. "
                    + "MinStack has to be smaller than MaxStack.");
            }

            if (minStack > Stack)
            {
                SetStack(minStack);
            }

            MinStack = minStack;
        }

        /// <summary>
	/// Calculate the overall value of a StackableElement, which is product of property Stack and Value.
	/// </summary>
	/// <returns>The overall value: Value times Stack.</returns>
        public float GetOverallValue()
        {
            return Value * Stack;
        }

        /// <summary>
        /// Return the string repesentation of a StackableElement.
        /// </summary>
        /// <returns>The String representation of a StackableElement.</returns>
        public override string ToString()
        {
            return $"{Name} Stack: {Stack}, Value: {Value}, IsExclusive: {IsExclusive}, MinStack: {MinStack}, MaxStack: {MaxStack}.";
        }

        /// <summary>
        /// Compare if two StackableElements are equal.
        /// </summary>
        /// <param name="obj">The other comparing object</param>
        /// <returns>True if two StackableElements have the same Name, Value, and Stack. False if they do not have the same poperties.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is StackableElement<TDataId>))
            {
                return false;
            }

            return Name.Equals(((StackableElement<TDataId>)obj).Name)
                && Value == ((StackableElement<TDataId>)obj).Value
                && Stack == ((StackableElement<TDataId>)obj).Stack;
        }

        /// <summary>
        /// Return the HashCode value of a StackableElement. Name^Value^Stack.
        /// </summary>
        /// <returns>Return the HashCode value of a StackableElement.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Value.GetHashCode() ^ Stack.GetHashCode();
        }
        #endregion

    }
}

using System;

namespace StackableElement
{
    /// <summary>
    /// A type of data that has a value and a stack.
    /// </summary>
    /// <typeparam name="TElementId">A class used for differentiating each StackableElement.</typeparam>
    public class StackableElement<TElementId>
    {
        private TElementId _name;
        private float _value;
        private int _stack;
        private bool _isExclusive;
        private int _minStack;
        private int _maxStack;
        private int _defaultMinStack;
        private int _defaultMaxStack;

        /// <summary>
        /// The name of a StackableElement with a generic type
        /// </summary>
        public TElementId Name { get { return _name; } protected set { _name = value; } }
        public float Value { get { return _value; } protected set { _value = value; } }
        public int Stack { get { return _stack; } protected set { _stack = value; } }
        /// <summary>
        /// If a StackableElement can have multiple(more than 1) stacks.
        /// </summary>
        public bool IsExclusive { get { return _isExclusive; } protected set { _isExclusive = value; } }
        /// <summary>
        /// The minimum stack a StackableElement can have. This is set to 0 if it is not specified.
        /// </summary>
        public int MinStack { get { return _minStack; } protected set { _minStack = value; } }
        /// <summary>
        /// The maximum stack a StackableElement can have. This is set to 999 if it is not specified.
        /// </summary>
        public int MaxStack { get { return _maxStack; } protected set { _maxStack = value; } }
        /// <summary>
        /// The default MinStack of a StackableElement if MinStack is not specified
        /// </summary>
        public int DefaultMinStack { get { return _defaultMinStack; } protected set { _defaultMinStack = value; } }
        /// <summary>
        /// The default MaxStack of a StackableElement if MaxStack is not specified
        /// </summary>
        public int DefaultMaxStack { get { return _defaultMaxStack; } protected set { _defaultMaxStack = value; } }


        /// <summary>
        /// Constructor for StackableElement object with a inital stack of 0.
        /// </summary>
        /// <param name="name">The name of a StackableElement.</param>
        /// <param name="value">The value of a StackableElement.</param>
        /// <param name="isExclusive">Determines if a StackableElement can only have Stack of 1 or 0.</param>
        public StackableElement(TElementId name, float value, bool isExclusive)
        {
            _value = value;
            _name = name;
            _stack = 0;
            _isExclusive = isExclusive;
            _minStack = _defaultMinStack;
            _maxStack = _isExclusive ? 1 : _defaultMaxStack;
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
                throw new ArgumentException($"Adding a negative value of stack is not allowed. Stackable Element: {_name}, OperationStack: {stack}.");
            }

            if (_stack + stack <= _maxStack)
            {
                _stack += stack;
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
                throw new ArgumentException($"Adding a negative value of stack is not allowed. Stackable Element: {_name}, OperationStack: {stack}.");
            }

            _stack = (_stack + stack > _maxStack) ? _maxStack : (_stack + stack);
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
                throw new ArgumentException($"Removing a negative value of stack is not allowed. Stackable Element: {_name}, OperationStack: {stack}.");
            }

            if (_stack - stack >= _minStack)
            {
                _stack -= stack;
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
                throw new ArgumentException($"Removing a negative value of stack is not allowed. Stackable Element: {_name}, OperationStack: {stack}.");
            }

            _stack = (_stack - stack < _minStack) ? _minStack : (_stack - stack);
        }

        /// <summary>
        /// Set the property Stack to ta specified number.
        /// If the parameter stack is greater than the MaxStack, throw a StackOutOfBoundException.
        /// </summary>
        /// <param name="stack">The number of Stack that will be set to.</param>
        public void SetStack(int stack)
        {
            if (stack > _maxStack || stack < _minStack)
            {
                throw new StackOutOfBoundException(_name.ToString(), _stack, stack, _minStack, _maxStack);
            }
            else
            {
                _stack = stack;
            }
        }

        /// <summary>
        /// Set Stack to 0;
        /// </summary>
        public void ClearStack()
        {
            _stack = 0;
        }

        /// <summary>
        /// Change the property IsExclusive of a StackableElement.
        /// </summary>
        /// <param name="isExclusive">A bool value that determines if a Stackable can have multiple stacks.</param>
        public void SetIsExclusive(bool isExclusive)
        {
            _isExclusive = isExclusive;
        }

        /// <summary>
        /// Change the MaxStack of a StackableElement. If the new MaxStack excludes Stack, set Stack to the new MaxStack first.
        /// </summary>
        /// <param name="maxStack">The target value of MaxStack a StackableElement would have.</param>
        public void SetMaxStack(int maxStack)
        {
            if (maxStack < _minStack)
            {
                throw new ArgumentException($"Attempting to change the MaxStack of {_name} from {_maxStack} to {maxStack} which is smaller than {_minStack}. "
                    + "MaxStack has to be larger than MinStack.");
            }

            if (maxStack < _stack)
            {
                SetStack(maxStack);
            }

            _maxStack = maxStack;
        }

        /// <summary>
        /// Change the MinStack of a StackableElement. If the new MinStack excludes Stack, set Stack to the new MinStack first.
        /// </summary>
        /// <param name="maxStack">The target value of MaxStack a StackableElement would have.</param>
        public void SetMinStack(int minStack)
        {
            if (minStack > MaxStack)
            {
                throw new ArgumentException($"Attempting to change the MinStack of {_name} from {_minStack} to {minStack} which is larger than {_maxStack}. "
                    + "MinStack has to be smaller than MaxStack.");
            }

            if (minStack > _stack)
            {
                SetStack(minStack);
            }

            _minStack = minStack;
        }

        /// <summary>
        /// Calculate the overall value of a StackableElement, which is product of property Stack and Value.
        /// </summary>
        /// <returns>The overall value: Value times Stack.</returns>
        public float GetOverallValue()
        {
            return _value * _stack;
        }

        /// <summary>
        /// Return the string repesentation of a StackableElement.
        /// </summary>
        /// <returns>The String representation of a StackableElement.</returns>
        public override string ToString()
        {
            return $"{_name} Stack: {_stack}, Value: {_value}, IsExclusive: {_isExclusive}, MinStack: {_minStack}, MaxStack: {_maxStack}.";
        }

        /// <summary>
        /// Compare if two StackableElements are equal.
        /// </summary>
        /// <param name="obj">The other comparing object</param>
        /// <returns>True if two StackableElements have the same Name, Value, and Stack. False if they do not have the same poperties.</returns>
        public override bool Equals(object obj)
        {
            if (obj is not StackableElement<TElementId>)
            {
                return false;
            }

            return _name.Equals(((StackableElement<TElementId>)obj)._name)
                && _value == ((StackableElement<TElementId>)obj)._value
                && _stack == ((StackableElement<TElementId>)obj)._stack;
        }

        /// <summary>
        /// Return the HashCode value of a StackableElement. Name^Value^Stack.
        /// </summary>
        /// <returns>Return the HashCode value of a StackableElement.</returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _value.GetHashCode() ^ _stack.GetHashCode();
        }
        #endregion

    }
}

using System;

namespace MyModule
{
    class StackOutOfBoundException : Exception
    {
        public StackOutOfBoundException(
            int currentStack,
            int operationStack,
            int minStack,
            int maxStack) : base(Form(currentStack, operationStack, minStack, maxStack)) { }


        public static string Form(
            int currentStack,
            int operationStack,
            int minStack,
            int maxStack)
        {
            return $"StackableElement currently has {currentStack} stacks, would have {currentStack + operationStack} after operation."
                + $"\n The range of Stack should be within {minStack} - {maxStack}.";
        }
    }
}

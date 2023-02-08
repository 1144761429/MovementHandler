using System;

namespace StackableElement
{
	class StackOutOfBoundException : Exception
	{
		public StackOutOfBoundException(
			string stackableElementName,
			int currentStack,
			int operationStack,
			int minStack,
			int maxStack) : base(Form(stackableElementName, currentStack, operationStack, minStack, maxStack)) { }


		public static string Form(
			string stackableElementName,
			int currentStack,
			int operationStack,
			int minStack,
			int maxStack)
        	{
			return $"{stackableElementName}, currently has {currentStack} stacks, would have {currentStack + operationStack} after operation."
				+ $"\n The range of Stack should be within {minStack} - {maxStack}.";
        	}
	}
}

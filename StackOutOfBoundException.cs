using System;

namespace StackableElement
{
	class StackOutOfBoundException : Exception
	{ 
		private int stack;
		private int minStack;
		private int maxStack;
		
		public StackOutOfBoundException(
			int stack,
			int[] bounds,
			string StackableElementId = null,
			string problem = null,
			string solution = null): base(Format(StackableElementId, problem, solution))
		{
			this.stack = stack;
			minStack = bounds[0];
			maxStack = bounds[1];
		}

		public static string Format(
			string context,
			string problem,
			string solution)
		{
			if (problem == null)
			{
				problem = "The property Stack of a StackableElement is out of range.";
			}

			if (solution == null)
			{
				solution = $"Make sure the value of property Stakc is within the bounds. Current Stack is {0}, but the bounds is {1} - {2}(both inclusive).";
			}

			return ExceptionFormatter.Format(context, problem, solution);
		}
	}
}

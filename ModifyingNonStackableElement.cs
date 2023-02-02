using System;
namespace StackableElementTest
{
    public class ModifyingNonStackableElement:Exception
    {
        public ModifyingNonStackableElement(string name):base(name.ToString())
        {
        }
    }
}

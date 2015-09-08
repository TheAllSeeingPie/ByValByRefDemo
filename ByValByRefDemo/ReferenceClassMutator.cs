namespace ByValByRefDemo
{
    public static class ReferenceClassMutator
    {
        public static void ChangeAField(ReferenceClass referenceClass)
        {
            ++referenceClass.AField;
        }

        public static void ChangeAField(ref ReferenceClass referenceClass)
        {
            ++referenceClass.AField;
        }
        
        public static void ChangeAProperty(ReferenceClass referenceClass)
        {
            ++referenceClass.AProperty;
        }

        public static void ChangeAProperty(ref ReferenceClass referenceClass)
        {
            ++referenceClass.AProperty;
        }

        public static void ChangeTheInstanceOfReferenceClass(ReferenceClass referenceClass)
        {
            referenceClass = new ReferenceClass {AField = 1, AProperty = 1};
        }

        public static void ChangeTheInstanceOfReferenceClass(ref ReferenceClass referenceClass)
        {
            referenceClass = new ReferenceClass { AField = 1, AProperty = 1 };
        }
    }
}
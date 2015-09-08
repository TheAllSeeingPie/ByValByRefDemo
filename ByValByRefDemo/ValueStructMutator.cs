namespace ByValByRefDemo
{
    public class ValueStructMutator
    {
        public static void ChangeAField(ValueStruct valueStruct)
        {
            ++valueStruct.AField;
        }

        public static void ChangeAField(ref ValueStruct valueStruct)
        {
            ++valueStruct.AField;
        }

        public static void ChangeAProperty(ValueStruct valueStruct)
        {
            ++valueStruct.AProperty;
        }

        public static void ChangeAProperty(ref ValueStruct valueStruct)
        {
            ++valueStruct.AProperty;
        }

        public static void ChangeTheInstanceOfValueStruct(ValueStruct valueStruct)
        {
            valueStruct = new ValueStruct { AField = 1, AProperty = 1 };
        }

        public static void ChangeTheInstanceOfValueStruct(ref ValueStruct valueStruct)
        {
            valueStruct = new ValueStruct { AField = 1, AProperty = 1 };
        }
    }
}
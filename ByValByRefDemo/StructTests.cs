using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByValByRefDemo
{
    [TestClass]
    public class StructTests
    {
        [TestMethod]
        public void Passed_ByRef_instance_can_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AField);
            Assert.AreEqual(0, valueStruct.AProperty);
            ValueStructMutator.ChangeTheInstanceOfValueStruct(ref valueStruct);
            //Changing the instance means that the current instance is "updated"
            Assert.AreEqual(1, valueStruct.AField);
            Assert.AreEqual(1, valueStruct.AProperty);
        }

        [TestMethod]
        public void Passed_ByRef_instance_fields_can_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AField);
            ValueStructMutator.ChangeAField(ref valueStruct);
            //Fields are updated as we're updating the instance passed in
            Assert.AreEqual(1, valueStruct.AField);
        }

        [TestMethod]
        public void Passed_ByRef_instance_properties_can_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AProperty);
            ValueStructMutator.ChangeAProperty(ref valueStruct);
            //Fields are updated as we're updating the instance passed in
            Assert.AreEqual(1, valueStruct.AProperty);
        }

        [TestMethod]
        public void Passed_ByVal_instance_cant_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AField);
            Assert.AreEqual(0, valueStruct.AProperty);
            ValueStructMutator.ChangeTheInstanceOfValueStruct(valueStruct);
            //Changing the instance has no effect as the instance has been copied
            Assert.AreEqual(0, valueStruct.AField);
            Assert.AreEqual(0, valueStruct.AProperty);
        }

        [TestMethod]
        public void Passed_ByVal_instance_fields_cant_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AField);
            ValueStructMutator.ChangeAField(valueStruct);
            //Because the instance copied is a value type we've copied all its values too
            //This means we end up copying all the values stopping them from being mutally shared
            Assert.AreEqual(0, valueStruct.AField);
        }

        [TestMethod]
        public void Passed_ByVal_instance_properties_cant_be_mutated()
        {
            var valueStruct = new ValueStruct();
            Assert.AreEqual(0, valueStruct.AProperty);
            ValueStructMutator.ChangeAProperty(valueStruct);
            //Because the instance copied is a value type we've copied all its values too
            //This means we end up copying all the values stopping them from being mutally shared
            Assert.AreEqual(0, valueStruct.AProperty);
        }
    }
}
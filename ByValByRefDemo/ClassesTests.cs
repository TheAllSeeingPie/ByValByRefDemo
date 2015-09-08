using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByValByRefDemo
{
    [TestClass]
    public class ClassesTests
    {
        [TestMethod]
        public void Passed_ByVal_instance_fields_can_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AField);
            ReferenceClassMutator.ChangeAField(referenceClass);
            //Because the instance copied is a reference type, all we've copied is it's pointers to instances of value types
            //This means we end up sharing their pointers and updating them across both instances
            Assert.AreEqual(1, referenceClass.AField);
        }

        [TestMethod]
        public void Passed_ByVal_instance_properties_can_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AProperty);
            ReferenceClassMutator.ChangeAProperty(referenceClass);
            //Because the instance copied is a reference type, all we've copied is it's pointers to instances of value types
            //This means we end up sharing their pointers and updating them across both instances
            Assert.AreEqual(1, referenceClass.AProperty);
        }

        [TestMethod]
        public void Passed_ByRef_instance_fields_can_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AField);
            ReferenceClassMutator.ChangeAField(ref referenceClass);
            //Fields are updated as we're updating the instance passed in
            Assert.AreEqual(1, referenceClass.AField);
        }

        [TestMethod]
        public void Passed_ByRef_instance_properties_can_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AProperty);
            ReferenceClassMutator.ChangeAProperty(ref referenceClass);
            //Fields are updated as we're updating the instance passed in
            Assert.AreEqual(1, referenceClass.AProperty);
        }

        [TestMethod]
        public void Passed_ByVal_instance_cant_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AField);
            Assert.AreEqual(0, referenceClass.AProperty);
            ReferenceClassMutator.ChangeTheInstanceOfReferenceClass(referenceClass);
            //Changing the instance has no effect as the instance has been copied
            Assert.AreEqual(0, referenceClass.AField);
            Assert.AreEqual(0, referenceClass.AProperty);
        }

        [TestMethod]
        public void Passed_ByRef_instance_can_be_mutated()
        {
            var referenceClass = new ReferenceClass();
            Assert.AreEqual(0, referenceClass.AField);
            Assert.AreEqual(0, referenceClass.AProperty);
            ReferenceClassMutator.ChangeTheInstanceOfReferenceClass(ref referenceClass);
            //Changing the instance means that the current instance is "updated"
            Assert.AreEqual(1, referenceClass.AField);
            Assert.AreEqual(1, referenceClass.AProperty);
        }
    }
}

using System;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByValByRefDemo
{
    [TestClass]
    public class ClassVsStructTests
    {
        [TestMethod]
        public void Test_1000000_instance_creation_time_structs_should_be_faster()
        {
            var testSize = 1000000;
            var structArray = new ValueStruct[testSize];
            var start = DateTime.Now;
            for (var i = 0; i < testSize; i++)
            {
                structArray[i] = new ValueStruct {AProperty = 1, AField = 1};
            }
            var structsEnded = (DateTime.Now - start).TotalMilliseconds;

            var classArray = new ReferenceClass[testSize];
            start = DateTime.Now;
            for (var i = 0; i < testSize; i++)
            {
                classArray[i] = new ReferenceClass { AProperty = 1, AField = 1 };
            }
            var classesEnded = (DateTime.Now - start).TotalMilliseconds;

            Console.WriteLine($"Classes creation:{classesEnded}ms");
            Console.WriteLine($"Structs creation:{structsEnded}ms");
            Assert.IsTrue(classesEnded > structsEnded);
        }

        [TestMethod]
        public void Test_1000000_array_copy_time_classes_should_be_faster()
        {
            var testSize = 1000000;
            var structArray = new ValueStruct[testSize];
            for (var i = 0; i < testSize; i++)
            {
                structArray[i] = new ValueStruct { AProperty = 1, AField = 1 };
            }
            var start = DateTime.Now;
            var copied = new ValueStruct[testSize];
            structArray.CopyTo(copied, 0);
            var structsEnded = (DateTime.Now - start).TotalMilliseconds;

            var classArray = new ReferenceClass[testSize];
            for (var i = 0; i < testSize; i++)
            {
                classArray[i] = new ReferenceClass { AProperty = 1, AField = 1 };
            }
            start = DateTime.Now;
            var copied2 = new ReferenceClass[testSize];
            classArray.CopyTo(copied2, 0);
            var classesEnded = (DateTime.Now - start).TotalMilliseconds;

            Console.WriteLine($"Classes copied in:{classesEnded}ms");
            Console.WriteLine($"Structs copied in:{structsEnded}ms");
            Assert.IsTrue(classesEnded < structsEnded);
        }

        [TestMethod]
        public void Copied_structs_are_not_mutally_sharing_properties_or_fields()
        {
            var testSize = 1000000;
            var structArray = new ValueStruct[testSize];
            for (var i = 0; i < testSize; i++)
            {
                structArray[i] = new ValueStruct {AProperty = 1, AField = 1};
            }
            var copied = new ValueStruct[testSize];
            structArray.CopyTo(copied, 0);

            for (var i = 0; i < testSize; i++)
            {
                copied[i].AField = 0;
                Assert.AreNotEqual(structArray[i].AField, copied[i].AField);
                copied[i].AProperty = 0;
                Assert.AreNotEqual(structArray[i].AProperty, copied[i].AProperty);
            }
        }

        [TestMethod]
        public void Copied_classes_are_mutally_sharing_properties_or_fields()
        {
            var testSize = 1000000;
            var classArray = new ReferenceClass[testSize];
            for (var i = 0; i < testSize; i++)
            {
                classArray[i] = new ReferenceClass { AProperty = 1, AField = 1 };
            }
            var copied = new ReferenceClass[testSize];
            classArray.CopyTo(copied, 0);

            for (var i = 0; i < testSize; i++)
            {
                copied[i].AField = 0;
                Assert.AreEqual(classArray[i].AField, copied[i].AField);
                copied[i].AProperty = 0;
                Assert.AreEqual(classArray[i].AProperty, copied[i].AProperty);
            }
        }
    }
}
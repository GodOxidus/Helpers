using System;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ExtensionTests
    {
        // o - object; n - null
        private TestObj Obg_o_n_3;
        private TestObj Obg_o_o_2;
        private TestObj Obg_n_o_1;
        private TestObj nullable;

        public ExtensionTests()
        {
            Obg_o_n_3 = new TestObj() {Obj = new Object(), Test = null};
            Obg_o_o_2 = new TestObj() {Obj = new Object(), Test = Obg_o_n_3};
            Obg_n_o_1 = new TestObj() {Obj = null, Test = Obg_o_o_2};
            nullable = null;
        }

        [TestMethod]
        public void WithTest()
        {
            Object result = Obg_n_o_1.With(x => x.Test)
                .With(x => x.Obj);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WithTest_null()
        {
            Object result = nullable.With(x => x.Test)
                .With(x => x.Obj);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReturnTest()
        {
            Object result = nullable.Return(x => x.Obj, 5);

            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void ReturnSuccess_true()
        {
            Boolean result = Obg_n_o_1.With(x => x.Test)
                .ReturnSuccess();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnSuccess_false()
        {
            Boolean result = Obg_n_o_1.With(x => x.Obj)
                .ReturnSuccess();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfTest()
        {
            Object result = Obg_n_o_1.If(x => x.Obj == null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IfTest_null()
        {
            Object result = Obg_n_o_1.If(x => x.Obj != null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void DoTest()
        {
            TestObj obj = Obg_n_o_1;

            Boolean result = obj.Do(x => x.Obj = new Object())
                .ReturnSuccess();

            Assert.IsTrue(result);
        }
    }
}

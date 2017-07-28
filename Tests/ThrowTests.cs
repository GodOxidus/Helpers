using System;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ThrowTests
    {
        [TestMethod]
        public void Check_true()
        {
            Int32 integer = 5;

            integer.Check(x => x == 5, new Exception());
        }

        [TestMethod]
        public void Check_throw()
        {
            Int32 integer = 5;
            Exception exception = null;

            try
            {
                integer.Check(x => x != 5, new Exception());
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void NotNull_true()
        {
            Object obj = new Object();

            obj.NotNull("obj", "message");
        }

        [TestMethod]
        public void NotNull_throw()
        {
            Object obj = null;
            ArgumentNullException exception = null;

            try
            {
                obj.NotNull("obj", "obj is null");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void String_NotEmpty_true()
        {
            String str = "Not empty string :D";

            str.NotEmpty("str");
        }

        [TestMethod]
        public void String_NotEmpty_throw()
        {
            String str = String.Empty;
            ArgumentNullException exception = null;

            try
            {
                str.NotEmpty("str");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void String_NotEmpty_null_throw()
        {
            String str = null;
            ArgumentNullException exception = null;

            try
            {
                str.NotEmpty("str");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void String_NotEmptyOrSpaces_true()
        {
            String str = "Not empty string :D";

            str.NotEmptyOrSpaces("str");
        }

        [TestMethod]
        public void String_NotEmptyOrSpaces_Empty_throw()
        {
            String str = String.Empty;
            ArgumentNullException exception = null;

            try
            {
                str.NotEmptyOrSpaces("str");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void String_NotEmptyOrSpaces_null_throw()
        {
            String str = null;
            ArgumentNullException exception = null;

            try
            {
                str.NotEmptyOrSpaces("str");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void String_NotEmptyOrSpaces_Spaces_throw()
        {
            String str = "           ";
            ArgumentNullException exception = null;

            try
            {
                str.NotEmptyOrSpaces("str");
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }

    }
}

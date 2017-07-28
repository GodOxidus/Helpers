using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ThrowHelper
    {
        /// <summary>
        /// Checks the specified predicate and throw exception.
        /// </summary>
        /// <param name="predicate">The predicate. Rerurn false for throw exception. </param>
        /// <param name="exception">The exception.</param>
        public static T Check<T>(this T obj, Predicate<T> predicate, Exception exception)
        {
            if (predicate(obj))
                return obj;
            throw exception;
        }

        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static T NotNull<T>(this T obj, ArgumentNullException exception)
            where T: class
        {
            return obj.Check(x => x != null, exception);
        }

        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="name">The param's name.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static T NotNull<T>(this T obj, String name, String message = null)
            where T: class
        {
            return obj.NotNull(new ArgumentNullException(name, message));
        }

        /// <summary>
        /// Nots the empty. Throw ArgumentNullException.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static String NotEmpty(this String str, String paramName, String message = null)
        {
            return str.Check(x => !String.IsNullOrEmpty(x),  new ArgumentNullException(paramName, message));
        }

        /// <summary>
        /// Nots the empty or spaces. Throw ArgumentNullException.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static String NotEmptyOrSpaces(this String str, String paramName, String message = null)
        {
            return str.Check(x => !String.IsNullOrWhiteSpace(x), new ArgumentNullException(paramName, message));
        }
    }
}

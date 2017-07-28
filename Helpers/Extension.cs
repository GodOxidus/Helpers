using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Extension
    {
        /// <summary>
        /// Check for null and execute function.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="o">The object.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns></returns>
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class where TResult : class
        {
            if (o == null)
                return null;
            return evaluator(o);
        }
        /// <summary>
        /// Returns the result of evaluator.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="o">The object.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <param name="failValue">The fail value.</param>
        /// <returns></returns>
        public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator, TResult failValue)
            where TInput : class
        {
            if (o == null)
                return failValue;
            return evaluator(o);
        }

        /// <summary>
        /// Returns true if result not failValue(null).
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="o">The object.</param>
        /// <param name="failValue">The fail value.</param>
        /// <returns></returns>
        public static Boolean ReturnSuccess<TInput>(this TInput o, TInput failValue = null)
            where TInput : class
        {
            return o != failValue;
        }

        /// <summary>
        /// Returns true if result not failValue(null) and out value.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="o">The object.</param>
        /// <param name="result">The result.</param>
        /// <param name="failValue">The fail value.</param>
        /// <returns></returns>
        public static Boolean ReturnSuccess<TInput>(this TInput o, out TInput result, TInput failValue = null)
            where TInput : class
        {
            result = o;
            return o.ReturnSuccess();
        }

        /// <summary>
        /// If object is null or evaluator returns false, return null, else object.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="o">The object.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns></returns>
        public static TInput If<TInput>(this TInput o, Predicate<TInput> evaluator)
            where TInput : class
        {
            if (o == null)
                return null;
            return evaluator(o) ? o : null;
        }

        /// <summary>
        /// Does the specified action.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="o">The o.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o == null)
                return null;
            action(o);
            return o;
        }
    }
}

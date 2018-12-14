using System;
using System.Collections.Generic;

namespace ArrayFlattenLib
{
    public class ArrayFlattenLib
    {
        /// <summary>
        /// Will flatten an array of object that contan integers or other object arrays that contain only integers
        /// </summary>
        /// <param name="objArray">And array of objects with integers and an arbitrarily nested arrays of objects with integers</param>
        /// <returns>An array of integers</returns>
        /// <example>
        /// var arrayObjectsGood = new object[] { 1, new object[] { 2 }, new object[] { 3, 4, new object[] { 5, 6 } }, 7, 8, 9, 10 };
        /// var result = arrayIntOnlyFlatten(arrayObjectsGood);
        /// </example>
        public static int[] ArrayIntOnlyFlatten(object[] objArray)
        {

            if (objArray == null)
            {
                return null;
            }

            var flatList = new List<int>();

            foreach (object item in objArray)
            {
                if (item is int)
                {
                    flatList.Add((int)item);
                }
                else if (item is object[])
                {
                    flatList.AddRange(ArrayIntOnlyFlatten((object[])item));
                }
                else
                {
                    throw new Exception("A non-Interger element of the array was included");
                }
            }

            return flatList.ToArray();
        }
    }
}

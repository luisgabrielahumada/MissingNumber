using MissingNumbers.Model;
using System.Collections.Generic;

namespace MissingNumbers.Services
{
    public interface INumberService
    {
        /// <summary>
        ///  Add number on arr
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        void Add(int number, List<Numbers> n);

        /// <summary>
        /// find Frequency of number between List Numbers
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        List<int> MissingNumber(List<Numbers> arr, List<Numbers> brr);

        /// <summary>
        /// Validar Max-Min < equal
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="equal"></param>
        /// <returns></returns>
        bool ValidateMinMax(List<Numbers> numbers, int equal);

        /// <summary>
        /// Validate range this number
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="equalfirst"></param>
        /// <param name="equallast"></param>
        /// <returns></returns>
        List<int> ValidateRangeNumber(List<Numbers> numbers, int equalfirst, int equallast);
    }
}
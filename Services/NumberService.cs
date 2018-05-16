using System.Collections.Generic;
using MissingNumbers.Model;
using System.Linq;

namespace MissingNumbers.Services
{
    public class NumberService : INumberService
    {
        /// <summary>
        ///  /// <see cref="INumberService.Add(int)"/>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        public void Add(int number, List<Numbers> n)
        {
            if (n.Exists(item => item.Number == number))
            {
                n = n.Where(m => m.Number == number)
                    .Select(item => { item.Frequency = item.Frequency + 1; return item; })
                    .ToList();
            }
            else
            {
                n.Add(new Numbers { Number = number, Frequency = 1 });
            }
        }

        /// <summary>
        /// <see cref="INumberService.MissingNumber(List{Numbers}, List{Numbers})"/>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public List<int> MissingNumber(List<Numbers> arr, List<Numbers> brr)
        {
            List<int> query = (from n in arr
                               join m in brr on n.Number equals m.Number
                               where m.Frequency > n.Frequency
                               select n.Number).ToList();

            return query;
        }

        /// <summary>
        /// <see cref="INumberService.ValidateMinMax(List{Numbers})"/>
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="equal"></param>
        /// <returns></returns>
        public bool ValidateMinMax(List<Numbers> numbers, int equal)
        {
            int xMax = numbers.Max(item => item.Number);
            int xMin = numbers.Min(item => item.Number);

            bool isValid = ((xMax - xMin) > equal);

            return isValid;
        }

        /// <summary>
        /// <see cref="INumberService.ValidateRangeNumber(List{Numbers})(List{Numbers})"/>
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public List<int> ValidateRangeNumber(List<Numbers> numbers, int equalfirst, int equallast)
        {
            List<int> query = numbers
                                .Where(item => item.Number <= equalfirst || item.Number >= equallast)
                                .Select(item => item.Number)
                                .ToList();

            return query;
        }
    }
}
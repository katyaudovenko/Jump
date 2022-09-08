using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Libs.Extensions
{
    public static class RandomExtension
    {
        public static T GetRandomItem<T>(this IEnumerable<T> list, Func<T, float> executor)
        {
            var sum = list.Sum(executor);
            var randomPoint = Random.value * sum;
            foreach (var item in list)
            {
                var chance = executor(item);
                if (chance > randomPoint)
                    return item;
                
                randomPoint -= chance;
            }

            return list.Last();
        }
    }
}
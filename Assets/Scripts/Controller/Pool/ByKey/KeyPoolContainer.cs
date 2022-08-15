using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool.ByKey
{
    public class KeyPoolContainer : MonoBehaviour
    {
        [SerializeField] private KeyPoolInfoConfig config;

        private readonly Dictionary<string, PoolObjects> _poolsMap = new Dictionary<string, PoolObjects>();

        public void CreatePools()
        {
            foreach (var poolInfo in config.keyPoolsInfo)
            {
                var type = poolInfo.key;
                var pool = new PoolObjects(poolInfo.prefab, CreateContainer(type), poolInfo.count);
                _poolsMap.Add(type, pool);
            }
        }

        private Transform CreateContainer(string typeName)
        {
            var container = new GameObject($"{typeName}Pool");
            container.transform.SetParent(transform);
            return container.transform;
        }

        public T GetFreeElement<T>(string key) where T : MonoBehaviour, IPoolBehaviour =>
            _poolsMap[key].GetFreeElement<T>();

        public void ReturnElement<T>(string key, T element) where T : MonoBehaviour, IPoolBehaviour =>
            _poolsMap[key].ReturnElement(element);
    }
}
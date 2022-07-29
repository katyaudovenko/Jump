using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool
{
    public class PoolContainer : MonoBehaviour
    {
        [SerializeField] private List<PoolInfo> poolsInfo;

        private readonly Dictionary<Type, PoolObjects> _poolsMap = new Dictionary<Type, PoolObjects>();

        public void CreatePools()
        {
            foreach (var poolInfo in poolsInfo)
            {
                var type = poolInfo.prefab.Behaviour.GetType();
                var pool = new PoolObjects(poolInfo.prefab, CreateContainer(type.Name), poolInfo.count);
                _poolsMap.Add(type, pool);
            }
        }

        private Transform CreateContainer(string typeName)
        {
            var container = new GameObject($"{typeName}Pool");
            container.transform.SetParent(transform);
            return container.transform;
        }

        public T GetFreeElement<T>() where T : MonoBehaviour, IPoolBehaviour => 
            _poolsMap[typeof(T)].GetFreeElement<T>();

        public void ReturnElement<T>(T element) where T : MonoBehaviour, IPoolBehaviour =>
            _poolsMap[typeof(T)].ReturnElement(element);

        public void ReturnElement<T>(Type type, T element) where T : MonoBehaviour, IPoolBehaviour =>
            _poolsMap[type].ReturnElement(element);
    }
}
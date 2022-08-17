using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool
{
    public class PoolObjects
    {
        private readonly PoolObject _prefab;
        private readonly Transform _container;
        private Stack<IPoolBehaviour> _pool;

        public PoolObjects(PoolObject prefab, Transform container, int count)
        {
            _prefab = prefab;
            _container = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        { 
            _pool = new Stack<IPoolBehaviour>();

            for (var i = 0; i < count; i++)
            {
                var element = CreatePoolElement();
                _pool.Push(element.Behaviour);
            }
        }

        private PoolObject CreatePoolElement()
        {
            var createdElement = Object.Instantiate(_prefab, _container);
            createdElement.gameObject.SetActive(false);
            createdElement.Behaviour.OnInitialize();
            return createdElement;
        }

        public void ReturnElement<T>(T element) where T : MonoBehaviour, IPoolBehaviour
        {
            if(_pool.Contains(element))
                return;
            
            _pool.Push(element);
            element.transform.SetParent(_container, false);
            element.gameObject.SetActive(false);
            element.OnReset();
        }

        public T GetFreeElement<T>() where T : MonoBehaviour, IPoolBehaviour
        {
            var element = (_pool.Count == 0 
                ? CreatePoolElement().Behaviour 
                : _pool.Pop()) 
                as T;

            if (element == null) 
                return null;
            
            element.gameObject.SetActive(true);
            element.OnSetup();
            return element;

        }
    }
}
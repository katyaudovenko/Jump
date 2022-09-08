using System;
using Infrastructure.Pool;
using Infrastructure.Pool.ByType;
using UnityEngine;

namespace Modules.PlayerComponents
{
    public class PlayerDestroyComponent : MonoBehaviour, IPoolBehaviour
    {
        public event Action OnDestroyPlayer;
        private TypePoolContainer _poolContainer;
        public void SetupPool(TypePoolContainer poolContainer) => 
            _poolContainer = poolContainer;

        public void DestroyPlayer()
        {
            _poolContainer.ReturnElement(this);
            OnDestroyPlayer?.Invoke();
        }

        public void OnInitialize() { }
        public void OnSetup() { }
        public void OnReset() { }
    }
}
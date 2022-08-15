using System;

namespace Controller.Pool.ByKey
{
    [Serializable]
    public class KeyPoolInfo
    {
        public string key;
        public int count;
        public PoolObject prefab;
    }
}
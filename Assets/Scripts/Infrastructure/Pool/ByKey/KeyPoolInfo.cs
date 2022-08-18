using System;

namespace Infrastructure.Pool.ByKey
{
    [Serializable]
    public class KeyPoolInfo
    {
        public string key;
        public int count;
        public PoolObject prefab;
    }
}
using System;

namespace Infrastructure.Pool.ByType
{
    [Serializable]
    public class TypePoolInfo
    {
        public int count;
        public PoolObject prefab;
    }
}
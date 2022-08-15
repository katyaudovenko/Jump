using System;

namespace Controller.Pool.ByType
{
    [Serializable]
    public class TypePoolInfo
    {
        public int count;
        public PoolObject prefab;
    }
}
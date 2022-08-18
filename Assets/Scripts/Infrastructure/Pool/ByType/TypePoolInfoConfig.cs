using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Pool.ByType
{
    [CreateAssetMenu(menuName = "New config/New TypePoolInfoConfig", fileName = "TypePoolInfoConfig")]
    public class TypePoolInfoConfig : ScriptableObject
    {
        public List<TypePoolInfo> typePoolsInfo;
    }
}
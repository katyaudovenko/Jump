using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool.ByType
{
    [CreateAssetMenu(menuName = "New config/New TypePoolInfoConfig", fileName = "TypePoolInfoConfig")]
    public class TypePoolInfoConfig : ScriptableObject
    {
        public List<TypePoolInfo> typePoolsInfo;
    }
}
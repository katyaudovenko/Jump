using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool.ByKey
{
    [CreateAssetMenu(menuName = "New config/New KeyPoolInfoConfig", fileName = "KeyPoolInfoConfig")]
    public class KeyPoolInfoConfig : ScriptableObject
    {
        public List<KeyPoolInfo> keyPoolsInfo;
    }
}
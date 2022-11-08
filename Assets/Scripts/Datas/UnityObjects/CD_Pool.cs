using Datas.ValueObject;
using Enums;
using UnityEngine;
using UnityEngine.Rendering;

namespace Datas.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Pool", menuName = "Objects/CD_Pool", order = 0)]
    public class CD_Pool : ScriptableObject
    {
        public SerializedDictionary<PoolType, PoolValueData> data;
    }
}
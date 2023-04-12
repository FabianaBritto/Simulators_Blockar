using UnityEngine;

namespace Block
{
    [CreateAssetMenu(fileName = "Block Engine", menuName = "Block Type/Engine", order = 20)]
    public class EngineScrObj : BlockScrObj
    {
        [Space]
        [Header("Wheel Data")]
        public int torque;
    }
}

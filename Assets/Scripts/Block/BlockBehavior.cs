using UnityEngine;

namespace Block
{
    public class BlockBehavior : MonoBehaviour
    {
        public enum Types
        {
            Engine,
            Standard,
            Wheel,
        }

        [Space]
        [Header("Block Settings")]
        public Types type;
        public BlockScrObj settings;

        [Space]
        [Header("Wheel Collider Settings")]
        public bool wheelRevert;

        public WheelCollider wheelCollider;
        public GameObject wheelModel;
    }
}

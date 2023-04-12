using UnityEngine;

namespace Block
{
    public class WheelCopyData : MonoBehaviour
    {
        private BlockBehavior block;

        private void Start()
        {
            block = GetComponent<BlockBehavior>();

            float scale = block.wheelCollider.radius * 2;
            block.wheelModel.transform.localScale = new Vector3(scale, scale, scale);
        }

        private void LateUpdate()
        {
            block.wheelCollider.GetWorldPose(out var pos, out var rot);
            block.wheelModel.transform.position = pos;
            block.wheelModel.transform.rotation = rot;
        }
    }
}

using UnityEngine;

namespace Fx
{
    public class SpeedFx : MonoBehaviour
    {
        private const float Speed = 8f;

        private void Start()
        {
            ResetPosition();
        }

        private void Update()
        {
            transform.position += Vector3.forward * Speed * Time.deltaTime;

            if (transform.position.z >= 4f) ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = new Vector3(0, 0, -3f);
        }
    }
}

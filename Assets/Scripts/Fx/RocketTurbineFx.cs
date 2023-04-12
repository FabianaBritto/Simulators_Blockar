using UnityEngine;

namespace Fx
{
    public class RocketTurbineFx : MonoBehaviour
    {
        private const float RotateSpeed = 30f;
        private const float Displacement = 0.5f;

        private float _timePassed;
        private Vector3 _positionOrigin;
        private Vector3 _positionDisplacement;

        private void Start()
        {
            _positionOrigin = transform.position;
            _positionDisplacement = new Vector3
            {
                x = _positionOrigin.x,
                y = _positionOrigin.y + Displacement,
                z = _positionOrigin.z
            };
        }

        private void Update()
        {
            _timePassed += Time.deltaTime;

            float timeInterpolation = Mathf.PingPong(_timePassed, 1f);
            transform.position = Vector3.Lerp(_positionOrigin, _positionDisplacement, timeInterpolation);
        }

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.up, RotateSpeed * Time.fixedDeltaTime);
        }
    }
}

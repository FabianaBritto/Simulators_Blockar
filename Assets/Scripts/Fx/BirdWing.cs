using UnityEngine;

namespace Fx
{
    public class BirdWing : MonoBehaviour
    {
        private float _timePassed;
        private SkinnedMeshRenderer _skinnedMeshRenderer;

        [SerializeField] private float speed = 1f;

        private void Start()
        {
            _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        private void Update()
        {
            _timePassed += Time.deltaTime * speed;

            float timeInterpolation = Mathf.PingPong(_timePassed, 1f);
            float shapeWeight = Mathf.Lerp(0f, 100f, timeInterpolation);

            _skinnedMeshRenderer.SetBlendShapeWeight(0, shapeWeight);
        }
    }
}

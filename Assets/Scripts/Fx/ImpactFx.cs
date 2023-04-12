using UnityEngine;

namespace Fx
{
    public class ImpactFx : MonoBehaviour
    {
        private const float Force = 4f;

        private Rigidbody _rigidbody;
        private ParticleSystem _particleSystems;

        [SerializeField] private Transform particleTransform;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _particleSystems = particleTransform.GetComponent<ParticleSystem>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _rigidbody.AddForce(Vector3.up * Force, ForceMode.Impulse);

            particleTransform.position = collision.GetContact(0).point;
            _particleSystems.Play();
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Fx
{
    public class BirdFlockFx : MonoBehaviour
    {
        private float _timePassed;

        [Space]
        [Header("Movement")]
        [SerializeField] [Range(0f, 20f)] private float speed = 2f;

        [Header("Displacement")]
        [SerializeField] [Range(2f, 1f)] private float displacement = 1.5f;
        [SerializeField] [Range(0f, 1f)] private float speedDisplacement = .1f;

        private Vector3 initialPos;
        public bool canFly = false;
        private void Start()
        {
            initialPos = transform.position;
            ResetPosition();
        }
        
        private void Update()
        {
            if (!canFly) return;
            _timePassed += Time.deltaTime * speedDisplacement;

            float timeInterpolation = Mathf.PingPong(_timePassed, 1f);
            Vector3 direction =
                Vector3.Lerp(Vector3.right / displacement, Vector3.right / displacement, timeInterpolation) +
                Vector3.right;
            transform.position += direction * speed * Time.deltaTime;

            //if (transform.position.z >= 4f) ResetPosition();
        }

        IEnumerator Birds()
        {
            yield return new WaitForSeconds(2f);
            canFly = true;
        }

        public void ResetPosition()
        {
            transform.position = initialPos;
           
            StartCoroutine(Birds());
        }
    }
}

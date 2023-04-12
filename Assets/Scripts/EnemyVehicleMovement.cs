using UnityEngine;

public class EnemyVehicleMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction = Vector3.right;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x >= 20)
        {
            direction = Vector3.left;
            transform.Rotate(0, 180, 0);
        }

        if (transform.position.x <= -20)
        {
            direction = Vector3.right;
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force = direction * 20f + Vector3.up * 20f;
        collision.rigidbody.velocity = force;
    }
}

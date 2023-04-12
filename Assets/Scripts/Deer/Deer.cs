using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    [SerializeField] private float runningRange, scareRange;
    [SerializeField] private bool playerInRunningRange, playerInScareRange;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private float speed;
    private DeerStrategy deerStrategy;
    private DeerIdle idle = new DeerIdle();
    private DeerRunning running = new DeerRunning();
    private DeerScared scared = new DeerScared();
    private float time = 0.0f;
    [SerializeField] private GameObject player;

    private void Start() {
        Invoke("SetEnemy", 2.0f);
    }
    private void SetEnemy(){
        player = GameObject.Find("Vehicle(Clone)");
    }
    private void FixedUpdate()
    {
        playerInScareRange = Physics.CheckSphere(transform.position, scareRange, whatIsPlayer);
        playerInRunningRange = Physics.CheckSphere(transform.position, runningRange, whatIsPlayer);
        deerStrategy = (playerInScareRange) ? scared : idle;
        deerStrategy = (playerInRunningRange) ? running : deerStrategy;
        if (deerStrategy == idle)
        {
            time += Time.fixedDeltaTime;
            if (time >= 5.0f)
            {
                deerStrategy?.Action(this.gameObject);
                time = 0.0f;
            }
        }
        else
        {
            deerStrategy?.Action(this.gameObject);
        }
        if (CollidedWithPlayer())
        {
            Rescued();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, runningRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, scareRange);
    }
    public bool CollidedWithPlayer(){
        bool collided = false;
        if (player != null)
        {
            if(Vector3.Distance(transform.position,player.transform.position) < 2.0f)
            {
                collided = true;
            }
        }
        return collided;
    }
    public void Rescued(){
        Destroy(this.gameObject);
    }
    public float GetSpeed => speed;
    public GameObject GetPlayer => player;
}

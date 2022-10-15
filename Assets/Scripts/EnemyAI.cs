using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private bool shouldRotate = true;
    [SerializeField]
    private LayerMask chasing;
    [SerializeField]
    private Vector3 dir;


    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 movement;
    

    [SerializeField] int knockbackForce = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

    }

    private void Update()
    {
        //move towards the player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (float)0.003);
        if (shouldRotate)
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.Rotate(0, 90, 90);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
            Vector2 knockback = (target.transform.position - transform.position).normalized * knockbackForce;
            targetRb.AddForce(knockback, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public bool shouldRotate = true;

    public LayerMask chasing;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    [SerializeField] int knockbackForce = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.Rotate(0, 90, 90);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            Vector3 knockback = (player.transform.position - transform.position).normalized * knockbackForce;
            playerRb.AddForce(knockback, ForceMode2D.Impulse);
        }
    }
}

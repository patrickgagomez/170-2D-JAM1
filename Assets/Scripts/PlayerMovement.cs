using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{

    void Start()
    {
        current_scene = SceneManager.GetActiveScene().buildIndex;
    }
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public int current_scene = SceneManager.GetActiveScene().buildIndex;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        current_scene = SceneManager.GetActiveScene().buildIndex;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LevelExit")
        {
            SceneManager.LoadScene(current_scene + 1);
        }
    }
}

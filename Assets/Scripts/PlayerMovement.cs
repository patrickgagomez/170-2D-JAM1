using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Camera cam;

    public bool switchScene = false;
    Vector2 movement;
    Vector2 mousePos;

    private float moveSpeed = 8f;
    private float horizontal;
    private float vertical;
    private float diagSpeedLimit = 0.7f;

    private Transform body;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;

        body = transform;
    }

    // Update is called once per frame
    void Update()
    {
        InputCollection();
        Movement();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void InputCollection()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        float horizontalSpeed = horizontal * moveSpeed;
        float verticalSpeed = vertical * moveSpeed;

        if (horizontal != 0 && vertical != 0)
        {
            body.position += new Vector3(horizontalSpeed * diagSpeedLimit * Time.deltaTime, verticalSpeed * Time.deltaTime, 0f);
        } else 
        {
            body.position += new Vector3(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0f);
        }
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LevelExit")
        {
            switchScene = true;
        }
    }
}

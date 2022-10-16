using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject hole;
    public float particleTimer = 1f;
    
    //HERE FOR DESTRUCTION?
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.GetComponent<Animator>().SetInteger("style", SceneManager.GetActiveScene().buildIndex);
        GameObject nextLevel = Instantiate(hole, transform.position, Quaternion.identity);
        nextLevel.GetComponent<Animator>().SetInteger("style", SceneManager.GetActiveScene().buildIndex);
        Destroy(effect, particleTimer);
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}

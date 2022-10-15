using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animate : MonoBehaviour
{

    [SerializeField]
    private Animator playerAnimator;
    //[SerializeField]
    //private Animator bulletAnimator;
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetInteger("style", currentScene);
    }
}

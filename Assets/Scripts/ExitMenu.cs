using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    private int current_scene;
    // Update is called once per frame
    void Update()
    {
        current_scene = SceneManager.GetActiveScene().buildIndex;
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(current_scene + 1);
        }   
    }
}


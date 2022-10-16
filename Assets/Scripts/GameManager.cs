using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnInterval = 4f;

    [SerializeField]
    private GameObject playerPrefab;

    private GameObject newPlayer;
    private int current_scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
        current_scene = SceneManager.GetActiveScene().buildIndex;
        //spawn player
        newPlayer = Instantiate(playerPrefab, new Vector3(Random.Range(-6f, 6f), 0), Quaternion.identity);
        //set the player anim
        newPlayer.GetComponent<Animator>().SetInteger("style", current_scene);
    }

    // Update is called once per frame
    void Update()
    {
        current_scene = SceneManager.GetActiveScene().buildIndex;
        if (newPlayer.GetComponent<PlayerMovement>().switchScene)
        {
            SceneManager.LoadScene(current_scene + 1);
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 0), Quaternion.identity);
        newEnemy.GetComponent<Animator>().SetInteger("style", current_scene);
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
        if (spawnInterval > 0.5)
        {
            spawnInterval -= 0.1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnInterval = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 0), Quaternion.identity);
        newEnemy.GetComponent<Animator>().SetInteger("style", SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
        if (spawnInterval > 0.5){
            spawnInterval -= 0.1f;
        }
    }
}

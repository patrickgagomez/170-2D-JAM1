using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerPrefab : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(Random.Range(-6f, 6f), 0), Quaternion.identity);
    }
}

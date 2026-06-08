using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Player;
    public float elapsedTime = 0f;
    public float timeToSpawn = 1f;

    public List<GameObject> enemiesPrefab;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > timeToSpawn )
        {
            int i = (int)Random.Range(0, enemiesPrefab.Count);
            print( i );
            GameObject enemy = Instantiate(enemiesPrefab[i], Player.transform.position + Vector3.up * 10, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().Player = Player;
            //elapsedTime = 0f
            elapsedTime = -10f;
        }
    }
}

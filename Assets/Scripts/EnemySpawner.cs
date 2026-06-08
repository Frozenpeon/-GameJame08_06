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
            Vector3 posSpawn = Random.insideUnitCircle.normalized * 15;
            GameObject enemy = Instantiate(enemiesPrefab[i], Player.transform.position + posSpawn, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().Player = Player;
            elapsedTime = 0f;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Player;
    public float elapsedTime = 0f;
    public float timeToSpawn = 1f;


    public List<GameObject> enemiesPrefab;


    public List<GameObject> enemies = new List<GameObject>();
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > timeToSpawn )
        {
            int i = (int)Random.Range(0, enemiesPrefab.Count);
            Vector3 posSpawn = Random.insideUnitCircle.normalized * 15;
            GameObject enemy = Instantiate(enemiesPrefab[i], Player.transform.position + posSpawn, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().Player = Player;
            enemy.GetComponent<EnemyHealth>().onDeath += removeEnemy;
            enemies.Add(enemy);            
            elapsedTime = 0f;
        }
    }


    public void removeEnemy(GameObject enemy)
    {
        if (enemies != null)
        {
            enemies.Remove(enemy);
        }
    }
}

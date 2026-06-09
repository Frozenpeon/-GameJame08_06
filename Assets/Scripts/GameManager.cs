using System;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPoint;
    public GameObject mainCamera;
    public EnemySpawner spawner;
    public HealthBarHandler healthBarHandler;

    public static Action<GameObject> PlayerSetUp;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        mainCamera.GetComponent<CameraFollowPlayer>().Player = player;
        GetComponent<EnemySpawner>().Player = player;
        healthBarHandler.init(player.GetComponent<Health>());
        player.GetComponent<WeaponHandler>().gameManager = this;
        PlayerSetUp?.Invoke(player);
    }

    public GameObject getClosestEnemy()
    {
        GameObject res;
        if (spawner.enemies.Count <= 0) { return null; }
        else 
            res = spawner.enemies[0];

            for (int i = 0; i < spawner.enemies.Count; i++)
            {
                GameObject go = spawner.enemies[i];
                Vector3 tempVec = go.transform.position - player.transform.position;
                if (tempVec.magnitude <= (res.transform.position - player.transform.position).magnitude) 
                    res = go;
            }
            return res;
    }
}

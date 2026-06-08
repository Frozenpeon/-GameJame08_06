using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPoint;
    public GameObject mainCamera;
    public HealthBarHandler healthBarHandler;

    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        mainCamera.GetComponent<CameraFollowPlayer>().Player = player;
        GetComponent<EnemySpawner>().Player = player;
        healthBarHandler.init(player.GetComponent<Health>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

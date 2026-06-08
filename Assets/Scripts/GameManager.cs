using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPoint;
    public GameObject mainCamera;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        mainCamera.GetComponent<CameraFollowPlayer>().Player = player;
        GetComponent<EnemySpawner>().Player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1000f;
    public Vector2 direction;


    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;
        print(direction.normalized * Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * Time.deltaTime * speed;
        }
}

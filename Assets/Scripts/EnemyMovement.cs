using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1000f;
    public Vector2 direction;
    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
        direction = Player.transform.position - transform.position;
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * Time.deltaTime * speed;
        }
    }
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}

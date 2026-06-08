using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    public Vector2 direction;
    private void Start()
    {
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
            Destroy(this.gameObject);
        }
    }
}

using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_WeaponBaseScript", menuName = "Scriptable Objects/SO_WeaponBaseScript")]
public class SO_WeaponBaseScript : ScriptableObject
{
    public GameObject bulletPrefab;
    public float shootSpeed;
    public GameObject Player;
    private int shot = 0;

    public void tryToShoot(float elapsedTime, Vector2 direction)
    {
        if (elapsedTime - shot * shootSpeed >= shootSpeed)
        {      
            Shoot(direction);
        }
    }

    private void Shoot(Vector2 direction)
    {
        GameObject go = Instantiate(bulletPrefab, Player.transform.position, Quaternion.identity);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.direction = direction;
        shot++;
    }
}

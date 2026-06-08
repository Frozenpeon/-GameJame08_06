using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_WeaponBaseScript", menuName = "Scriptable Objects/SO_WeaponBaseScript")]
public class SO_WeaponBaseScript : ScriptableObject
{
    public GameObject bulletPrefab;
    public float shootSpeed;
    public GameObject Player;
    private int shot = 0;

    public void tryToShoot(float elapsedTime)
    {
        if (elapsedTime - shot * shootSpeed >= shootSpeed)
        {      
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab);
        shot++;
    }
}

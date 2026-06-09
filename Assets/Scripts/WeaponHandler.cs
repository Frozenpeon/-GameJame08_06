using UnityEngine;
using System.Collections.Generic;
public class WeaponHandler : MonoBehaviour
{
    public List<SO_WeaponBaseScript> weapons = new List<SO_WeaponBaseScript>();
    public GameManager gameManager;
    public float elapsedTime = 0;
    public SO_WeaponBaseScript weapon;
    public float weaponSpeed = 2;
    public GameObject bulletPrefab;

    public List<AudioClip> shootSounds = new List<AudioClip>();
    public AudioSource shootSound;
    public float shootVolume;

    private void Start()
    {
        AddAWeapon(weapon);    
        shootSound.volume = shootVolume;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= weaponSpeed)
        {
            if (gameManager.getClosestEnemy() == null)
            {
                elapsedTime = 0;
                return;

            }
            shootSound.clip = shootSounds[Random.Range(0, shootSounds.Count)];
            shootSound.Play();
            GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.direction = (gameManager.getClosestEnemy().transform.position - transform.position).normalized;
            elapsedTime = 0;
        }

        /*if (gameManager.getClosestEnemy() == null)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].tryToShoot(elapsedTime, Vector2.up);
            }
            return;
        }       
        Vector2 directionShot = (gameManager.getClosestEnemy().transform.position - transform.position).normalized; 
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].tryToShoot(elapsedTime, directionShot);
        }*/
    }

    public void AddAWeapon(SO_WeaponBaseScript weapon)
    {   
        weapons.Add(weapon);
        weapon.Player = gameObject;
    }
}

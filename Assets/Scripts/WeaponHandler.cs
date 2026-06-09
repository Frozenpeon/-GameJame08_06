using UnityEngine;
using System.Collections.Generic;
public class WeaponHandler : MonoBehaviour
{
    public List<SO_WeaponBaseScript> weapons = new List<SO_WeaponBaseScript>();
    public GameManager gameManager;
    public float elapsedTime = 0;
    public List<SO_WeaponBaseScript> weaponFromStart;
    public float weaponSpeed = 2;
    public GameObject bulletPrefab;

    public List<AudioClip> shootSounds = new List<AudioClip>();
    public AudioSource shootSound;
    public float shootVolume;

    private void Start()
    {
        for (int i = 0; i < weaponFromStart.Count; i++)
        {
            AddAWeapon(weaponFromStart[i]);
        }
        shootSound.volume = shootVolume;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;        
        if (gameManager.getClosestEnemy() == null)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].keepShotTracks(elapsedTime);
            }
            return;
        }       

        Vector2 directionShot = (gameManager.getClosestEnemy().transform.position - transform.position).normalized; 
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].tryToShoot(elapsedTime, directionShot);
        }
    }


    public void PlayShootSound()
    {
        shootSound.clip = shootSounds[Random.Range(0, shootSounds.Count)];
        shootSound.Play();
    }

    public void AddAWeapon(SO_WeaponBaseScript weapon)
    {   
        weapons.Add(weapon);
        weapon.Player = gameObject;
        weapon.WH = this;
        weapon.shot = 0; 
    }
}

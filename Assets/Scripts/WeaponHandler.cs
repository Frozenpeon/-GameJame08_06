using UnityEngine;
using System.Collections.Generic;
public class WeaponHandler : MonoBehaviour
{
    public List<SO_WeaponBaseScript> weapons;

    private float elapsedTime = 0;
    void Update()
    {
        elapsedTime += Time.deltaTime;

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].tryToShoot(elapsedTime);
        }
    }

    public void AddAWeapon(SO_WeaponBaseScript weapon)
    {
        
        weapons.Add(weapon);
    }
}

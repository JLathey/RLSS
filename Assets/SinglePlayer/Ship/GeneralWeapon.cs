using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralWeapon : GeneralComponent {
    public bool firing = false;
    //The amount of shots fired every %fireInterval seconds
    public float fireRate = 2.0f;
    //The amount of time to base fire rate on. Ex: fireRate of 2 with fireInterval 1
    //should result in 2 shots every one second.
    public float fireInterval = 1.0f;
    //Timer to count interval to rate ratio
    public float fireElapsed = 0.0f;
    //True if the weapon is either on/off, and does not use firerate.
    public bool isBeam = false;
    //The amount of time before a weapon overheats.
    //0 for never overheat
    public float overHeatInterval = 0.0f;
    //The amount of time required to reload current "magazine"; -1 for no reloading
    public float reloadInterval = 0.0f;
    //The amount of ammo remaining per "magazine"; -1 for no ammo limit
    public int remainingAmmo = 0;
    //The max ammo per "magazine"; -1 for no ammo limit
    public int maxAmmo = 0;
    //Typically not used - only useful for weapons that require a separate custom timer
    public float specialTimer = 0.0f;
    //Typically not used - only useful for weapons that require a separate custom boolean
    public bool specialBool = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

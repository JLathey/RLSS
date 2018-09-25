using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : GeneralComponent {

    public bool isDead = false;
    public float speed = 0.8f;
    public float turnSpeed = 0.15f;
    public float drag = 0.01f;
    public float sideDrag = 0.02f;
    public bool neutral = false;
    public float burstCD = 1.0f;
    public float burstCounter = 0.0f;
    public float boosterFactor = 0.0f;
    public float maxSpeed = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reap_eater_bullet : GeneralBullet {

	void Start () {
        Destroy(gameObject, deadTimer);
    }

    void FixedUpdate () {

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(Random.Range(0.0f,1.0f) < 0.95f)
        {
            Destroy(gameObject);
        }
    }
}

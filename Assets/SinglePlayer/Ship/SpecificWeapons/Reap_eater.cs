using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reap_eater : GeneralWeapon {

    //The bullet to be used by the weapon
    public GameObject bullet;

    public Vector3 fireOffset;
    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = gameObject.GetComponentInParent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
		if(Input.GetAxis("Fire1") > 0)
        {
            if(firing == false)
            {
                firing = true;
            }
            fireElapsed += Time.deltaTime;
            if(fireElapsed >= (fireInterval/fireRate))
            {
                fireElapsed = 0;
                GameObject bref = Instantiate(bullet, AddOffset(),gameObject.transform.rotation);
                bref.GetComponent<Rigidbody>().AddRelativeForce(0, 0, bref.GetComponent<GeneralBullet>().velocity);

            }
        }
        else
        {
            if(firing == true)
            {
                firing = false;
                fireElapsed = 0;
            }
        }
	}

    Vector3 AddOffset()
    {
        Vector3 v = gameObject.transform.position;
        v = transform.InverseTransformDirection(v);
        v.x += fireOffset.x;
        v.y += fireOffset.y;
        v.z += fireOffset.z;
        v = transform.TransformDirection(v);
        return v;
    }
}

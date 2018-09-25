using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : ShipComponent
{
    bool cursorLock = true;
    bool violating = false;

    Rigidbody rig;
    public List<Engine> ENGINES;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        rig.useGravity = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rig.angularDrag = 0.8f;
        for (int i = 0; i < ENGINES.Count; i++)
        {
            speed += ENGINES[i].speedModifier;
            rig.mass += ENGINES[i].weight;
        }
        burstCounter = 0;
    }

    private void Update()
    {
        //Cursor Lock Toggle
        CheckCursorToggle();
        CheckNeutralToggle();
        //Check for booster
        CheckBurst();
    }

    void FixedUpdate()
    {
        ManageInput();
    }

    void ManageInput()
    {
        //Ship Movement
        MoveShip();
        CapSpeed();
        //Simulate Drag effect for dampening if we aren't in "neutral"
        if (!neutral)
        {
            SimulateDrag();
        }
    }

    void CheckCursorToggle()
    {
        //Cursor Lock Toggle
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (cursorLock)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cursorLock = false;
                neutral = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cursorLock = true;
                neutral = false;
            }
        }
    }

    void MoveShip()
    {
        //If the cursor is locked on screen, use it for input
        if (cursorLock)
        {
            if (!violating)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    rig.AddRelativeForce(Vector3.forward * speed);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    rig.AddRelativeForce(Vector3.back * speed);
                }
                if (!neutral)
                {
                    SimulateDrag();
                }
            }
            else
            {
                if (!neutral)
                {
                    SimulateDrag();
                }
            }
            rig.AddRelativeTorque((Input.GetAxis("Mouse Y")) * -turnSpeed, 0, 0);
            rig.AddRelativeTorque(0, (Input.GetAxis("Mouse X")) * turnSpeed, 0);
            rig.AddRelativeTorque(0, 0, (Input.GetAxis("Yaw") * (turnSpeed * 2.5f)));
        }
    }

    void CheckBurst()
    {
        if (Input.GetKeyDown(KeyCode.Space) && burstCounter <= 0)
        {
            rig.AddRelativeForce(0, 0, boosterFactor);
            burstCounter = burstCD;
        }
        if (burstCounter >= 0)
        {
            burstCounter -= Time.deltaTime;
        }
    }

    void SimulateDrag()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 vel = transform.InverseTransformDirection(rig.velocity);
            vel.x *= 1.0f - (sideDrag); // reduce x component...
            vel.y *= 1.0f - (sideDrag); // and y component...

            rig.velocity = transform.TransformDirection(vel);
        }
        else
        {
            if (Mathf.Abs(rig.velocity.x) > 0 || Mathf.Abs(rig.velocity.y) > 0 || Mathf.Abs(rig.velocity.z) > 0)
            {
                Vector3 vel = rig.velocity;
                vel.x *= 1.0f - drag; // reduce x component...
                vel.y *= 1.0f - drag; // and y component...
                vel.z *= 1.0f - drag; // and z component each cycle

                rig.velocity = vel;
            }
        }

    }

    void CapSpeed()
    {
        if (rig.velocity.magnitude > maxSpeed)
        {
            Vector3 vel = rig.velocity;
            vel.z *= 1.0f - (drag * 10); // and z component each cycle
            rig.velocity = vel;
            //Debug.Log("Speed Reached: " + rig.velocity.magnitude + " M/S");
            violating = true;
        }
        else
        {
            violating = false;
        }
    }

    void CheckNeutralToggle()
    {
        //Neutral Toggle
        if (cursorLock)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (neutral)
                {
                    rig.angularDrag = 0.8f;
                }
                else
                {
                    rig.angularDrag = 0.05f;
                }
                neutral = !neutral;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float movementspeed;
    public float turnspeed;
    public Rigidbody2D rigidbody;
    public Vector2 target;
    public Vector2 moveDirection;
    public Vector2 directionVector;
    private bool targetreached;
    public float snappingnumber;

    public GameObject deadzombie;
    public bool dead = false;

    void Start()
    {
        targetreached = true;
        snappingnumber = 0.3f;
    }


    // Update is called once per frame
    void Update()
    {
        ProccessOrder();
    }

    void FixedUpdate()
    {
        if (!targetreached)
        {
            Move();
            if (directionVector.magnitude < snappingnumber)
            {
                targetreached = true;
                rigidbody.velocity = new Vector2(0, 0);
            }


        }
    }

    void ProccessOrder()
    {
        directionVector = new Vector2(target.x - rigidbody.position.x, target.y - rigidbody.position.y);
        moveDirection = directionVector;
        moveDirection = moveDirection.normalized;
    }

    void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * movementspeed, moveDirection.y * movementspeed);
        float aimAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = aimAngle;
    }

    public void setTarget(Vector2 newTarget)
    {
        target = newTarget;
        targetreached = false;
    }

    public void getKilled()
    {
        GameObject temp = Instantiate(deadzombie, this.transform);
        dead = true;
        temp.transform.SetParent(gameObject.transform.parent);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour
{
    public float movementspeed;
    public float turnspeed;
    public Rigidbody2D rigidbody;
    public Transform target;
    public Vector2 targetPosition;
    public Vector2 moveDirection;
    public Vector2 directionVector;
    private bool targetreached;
    public float snappingnumber;

    // Start is called before the first frame update
    void Start()
    {
        targetreached = false;
        snappingnumber = 0.3f;
        targetPosition = target.position;
    }

    private void Update()
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
        // SetTarget? (Schlaues Wegrennen der Scientists nicht notwendig für Trailerprototyp?) 
        directionVector = new Vector2(targetPosition.x - rigidbody.position.x, targetPosition.y - rigidbody.position.y);
        moveDirection = directionVector.normalized;
    }

    void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * movementspeed, moveDirection.y * movementspeed);
        float aimAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = aimAngle;
    }
}

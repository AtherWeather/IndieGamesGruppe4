using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bullet;
    public Rigidbody2D rigidbody;

    public bool aiming;

    public GameObject target;
    public Vector2 directionVector;

    public float guncooldown;
    public float currentcooldown;

    void Start()
    {
        aiming = false;
        guncooldown = 80;
    }

    void Update()
    {
        if (aiming)
        {
            directionVector = new Vector2(target.transform.position.x - rigidbody.position.x, target.transform.position.y - rigidbody.position.y);
        }
    }

    void FixedUpdate()
    {
        if (aiming) { 
        float aimAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = aimAngle;
        
        if(currentcooldown <= 0)
            {
                currentcooldown = guncooldown;
                Instantiate(bullet, this.transform);
            }
            else
            {
                currentcooldown -= 0.4f;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.tag == "Zombie")
            {
                infect();
            }
           
    }

    private void infect()
    {     
        GameObject temp = Instantiate(zombie, this.transform);
        temp.transform.SetParent(gameObject.transform.parent);
        Destroy(gameObject);
    }

    public void aim(GameObject targetnew)
    {
        target = targetnew;
    }


}

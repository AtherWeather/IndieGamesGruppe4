using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bullet;
    public Rigidbody2D rigidbody;
    public GameObject playercontroller;
    

    public GameObject gunbarrel;

    public bool aiming;

    public GameObject target;
    public Vector2 directionVector;

    public float guncooldown;
    public float currentcooldown;
    public bool infected;

    void Start()
    {
        aiming = false;       
    }

    void Update()
    {
        if (aiming)
        {
            if (target == null)
            {
                aiming = false;
            }
            else
            {
                directionVector = new Vector2(target.transform.position.x - rigidbody.position.x, target.transform.position.y - rigidbody.position.y);
            }
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
                GameObject temp = Instantiate(bullet, gunbarrel.transform);
                temp.transform.SetParent(gameObject.transform.parent);
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
        if (!infected) { 
        infected = true;
        GameObject temp = Instantiate(zombie, this.transform);
        temp.transform.SetParent(gameObject.transform.parent);
        playercontroller.GetComponent<PlayerController>().addZombie(temp);
        Destroy(gameObject);
    }
    }

    public void aim(GameObject targetnew)
    {
        target = targetnew;
        aiming = true;
    }


}

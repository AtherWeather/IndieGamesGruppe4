using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bullet;

    public bool aiming;

    public GameObject target;

    void Start()
    {
        aiming = false;
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

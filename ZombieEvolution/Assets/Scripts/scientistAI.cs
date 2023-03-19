using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistAI : MonoBehaviour
{
    public GameObject zombie;
    public GameObject playercontroller;
    public bool infected;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Zombie")
        {
            infect();
        }
    }

    private void infect()
    {
        if (!infected)
        {
            GameObject temp = Instantiate(zombie, this.transform);
            temp.transform.SetParent(gameObject.transform.parent);
            playercontroller.GetComponent<PlayerController>().addZombie(temp);
            Destroy(gameObject);
        }
    }

}

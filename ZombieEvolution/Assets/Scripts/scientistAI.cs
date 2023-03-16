using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistAI : MonoBehaviour
{
    public GameObject zombie;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Zombie")
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDetection : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Zombie")
        {
            gameObject.transform.parent.GetComponent<GuardAI>().aim(collision.gameObject);
        }

    }

}

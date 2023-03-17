using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float projectileSpeed;

    // Update is called once per frame
    void Update()
    {
        float amountToMove = projectileSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * amountToMove);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().getKilled();
            Destroy(gameObject);
        }
    }
}

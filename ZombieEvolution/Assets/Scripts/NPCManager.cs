using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject controller;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = controller.GetComponent<PlayerController>();
    }

    private void OnTransformChildrenChanged()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.CompareTag("Zombie"))
            {
                playerController.zombies.Add(transform.GetChild(i).gameObject);
            }
        }
    }
}

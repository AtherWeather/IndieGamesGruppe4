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
            Transform child = transform.GetChild(i);
            if (child != null)
            {
                if (child.gameObject.CompareTag("Zombie"))
                {
                    if (child.GetComponentInChildren<Zombie>().dead)
                    {
                        playerController.zombies.Remove(child.gameObject);
                        Destroy(child.gameObject);
                    }
                    else
                    {
                        playerController.zombies.Add(child.gameObject);
                    }
                }
            }
        }
    }
}
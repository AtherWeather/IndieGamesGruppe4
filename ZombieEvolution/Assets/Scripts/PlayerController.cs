using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> zombies;

    public Camera sceneCamera;

    public float energy;
    public float energyCap;
    public float energyRegeneration;

    public GameObject attackorder;
    private Vector3 target;

    public Vector2 mousePosition;

    public float attackOrderCost;

    void Start ()
    {
       Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy >= attackOrderCost && Input.GetMouseButtonDown(0))
        {
            energy -= attackOrderCost;      
            for (int i = 0; i < zombies.Count; i++)
            {
                if (zombies[i] != null)
                {
                    zombies[i].GetComponent<Zombie>().setTarget(mousePosition);
                }
            }

        }
    }

    void FixedUpdate()
    {
        energy = Mathf.Min(energyCap, energy + energyRegeneration);
        target = sceneCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y , sceneCamera.transform.position.z));
        attackorder.transform.position = new Vector2(target.x, target.y);
        mousePosition = new Vector2(target.x, target.y);
    }

    public void addZombie(GameObject newZombey)
    {
        zombies.Add(newZombey);
    }
}

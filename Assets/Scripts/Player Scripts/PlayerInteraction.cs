using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Iinteractable
{
    public void interact();
}

public class PlayerInteraction : MonoBehaviour
{
    //this will refernce a source for where the ray will be casted
    public Transform interactorSource;
    //dictates the range the player can interact
    public float interactRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the player pressed the F key
        if(Input.GetKeyDown(KeyCode.F))
        {
            //checks for the distance of the interaction's source location
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            //casts ray between interactable and interaction source's collider
            if(Physics.Raycast(r,out RaycastHit hitInfo, interactRange))
            {
                //looks for the interactable's collider and checks if it is interactable
                if(hitInfo.collider.gameObject.TryGetComponent(out Iinteractable interactObj))
                {
                    interactObj.interact();
                }
            }
        }
    }
}

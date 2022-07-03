using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{


    public bool isFallen;
    

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag.Equals("Filter") && !isFallen)
        {

            isFallen = true;
            LevelManager.Instance.fallenCubes++;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
        
        }

        

    }
}

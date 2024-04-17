using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    
    void OnTriggerExit(Collider collision)
    {
        //Debug.Log(collision);
        if (!collision.CompareTag("FieldCheck"))
        {
            return;
        }
        
        Vector3 playerTransformPosition = GameManager.gameManager.player.transform.position;
        Vector3 myPosition = transform.position;
        
        float diffx = Mathf.Abs(playerTransformPosition.x - myPosition.x);
        float diffz = Mathf.Abs(playerTransformPosition.z - myPosition.z);

        //Vector3 platerDir = GameManager.gameManager.

        float dirX = GameManager.gameManager.player.horizontal < 0 ? -1 : 1;
        float dirZ = GameManager.gameManager.player.vertical < 0 ? -1 : 1;

        Debug.Log(dirZ);
        Debug.Log(dirX);

        //Debug.Log(transform.tag);
        switch (transform.tag)
        {
            

            case "Field":
                if (diffx > diffz)
                {
                    transform.Translate(Vector3.right * dirX * 80);
                    //Debug.Log(Vector3.right * dirX * 80);
                }
                else if (diffx < diffz)
                {
                    transform.Translate(Vector3.forward * dirZ * 80);
                    //Debug.Log(Vector3.forward * dirZ * 80);
                }

                break;

            case "Enemy":
                break;

        }


    }


}



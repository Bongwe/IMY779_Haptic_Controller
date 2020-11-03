using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{

    private bool canJump = false;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EnemyPlayer")
        {
            canJump = true;
            Debug.Log(canJump);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "EnemyPlayer" && (other.gameObject.tag != "InteractiveSphere1" || other.gameObject.tag != "InteractiveSphere2"))
        {
            canJump = false;
            Debug.Log(canJump);
        }
    }

    public bool canJumpFunction()
    {
        return canJump;
    }

}

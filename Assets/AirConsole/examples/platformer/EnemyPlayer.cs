using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float playerSpeed = 0.07f;
    private int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + new Vector3(playerSpeed * direction, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        direction = direction * -1;
    }
}

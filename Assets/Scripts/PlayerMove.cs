using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 directions;
    private CharacterController cc;
    [SerializeField]
    [Range(0f,5f)]
    private float speed = 3.0f;

    
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        directions = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        float rotationDirection = directions.x < 0 ? -1f : 1f; 
        this.transform.Rotate(new Vector3(0, directions.y * rotationDirection, 0));
        Vector3 moveDirection = transform.right * directions.x; 
        cc.Move(moveDirection * speed * Time.deltaTime);
    }
}

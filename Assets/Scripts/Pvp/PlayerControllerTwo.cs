using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour
{
    private Vector2 directions;
    private CharacterController cc;
    [SerializeField]
    [Range(0f, 5f)]
    private float speed = 5.0f;
    public int dirX, dirY;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        speed = PlayerTwoLife.lifePlayer2 <= 50 ? 1.5f : 3f;
    }

    void FixedUpdate()
    {
        dirX = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);
        dirY = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
        directions = new Vector2(dirX, dirY);
        float rotationDirection = directions.x < 0 ? -1f : 1f;
        this.transform.Rotate(new Vector3(0, directions.y * rotationDirection, 0));
        Vector3 moveDirection = transform.right * directions.x;
        cc.Move(moveDirection * speed * Time.deltaTime);
    }
}

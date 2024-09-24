using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveOne : MonoBehaviour
{
    private Vector2 directions;
    private CharacterController cc;
    [SerializeField]
    [Range(0f, 5f)]
    private float speed = 5.0f;
    int dirX, dirY;
    static public bool GODMODE = false;
    private Renderer playerRenderer;
    private Renderer canoRenderer;
    private Renderer pontaRenderer;
    public GameObject cano;
    public GameObject Ponta;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerRenderer = GetComponent<Renderer>();
        canoRenderer = cano.GetComponent<Renderer>();   
        pontaRenderer = Ponta.GetComponent<Renderer>(); 
    }

    void Update()
    {
        Debug.Log(speed);
        speed = PlayerOneLife.lifePlayer1 <= 50 ? 1.5f : 3f;
        if (Input.GetKeyDown(KeyCode.G))
        {
            GODMODE = true;
            speed = 100f;
            StartCoroutine(Rainbow());
        }
    }

    private IEnumerator Rainbow()
    {
        float hue = 0f;
        while (true)
        {
            hue += Time.deltaTime * 0.2f;
            if (hue > 1f)
            {
                hue = 0f;
            }

            
            playerRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);

            
            if (canoRenderer != null)
            {
                canoRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);
            }

            
            if (pontaRenderer != null)
            {
                pontaRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);
            }

            yield return null;
        }
    }

    void FixedUpdate()
    {
        dirX = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        dirY = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        directions = new Vector2(dirX, dirY);
        float rotationDirection = directions.x < 0 ? -1f : 1f;
        this.transform.Rotate(new Vector3(0, directions.y * rotationDirection, 0));
        Vector3 moveDirection = transform.right * directions.x;
        cc.Move(moveDirection * speed * Time.deltaTime);
    }
}

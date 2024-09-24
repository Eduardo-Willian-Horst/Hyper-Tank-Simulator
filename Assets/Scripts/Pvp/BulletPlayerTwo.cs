using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerTwo : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f; 

    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        Vector3 moveDirection = transform.right; 
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player1")){
            PlayerOneLife enemy = other.gameObject.GetComponent<PlayerOneLife>();
            enemy.ApplieDamage(Random.Range(7,10));
        }
        
    }

    
}

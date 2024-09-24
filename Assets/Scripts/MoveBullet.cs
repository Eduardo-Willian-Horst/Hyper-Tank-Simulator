using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBullet : MonoBehaviour
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
        if(other.gameObject.CompareTag("Enemy")){
            EnemyLife enemy = other.gameObject.GetComponent<EnemyLife>();
            enemy.ApplieDamage(3);
        }
        
    }

    
}

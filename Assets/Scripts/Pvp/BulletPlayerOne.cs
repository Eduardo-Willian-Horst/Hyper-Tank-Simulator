using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerOne : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player2")){
            PlayerTwoLife enemy = other.gameObject.GetComponent<PlayerTwoLife>();
            if(PlayerMoveOne.GODMODE){
                enemy.ApplieDamage(Random.Range(20,25));
            }
            else enemy.ApplieDamage(Random.Range(7,10));
        }
    }

    


    
}

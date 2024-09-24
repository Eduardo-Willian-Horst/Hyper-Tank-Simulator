using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float changeDirectionTime = 2f;  
    public float rotationSpeed = 180f;  

    private Vector3 randomDirection;
    private float timer;
    private Quaternion targetRotation;

    void Start()
    {
        ChooseRandomDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= changeDirectionTime)
        {
            ChooseRandomDirection();
            timer = 0f;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

   
    void ChooseRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        
        randomDirection = new Vector3(randomX, 0f, randomZ).normalized;

        
        targetRotation = Quaternion.LookRotation(randomDirection);
    }

    private void OnColliderEnter(Collider col){
        ChooseRandomDirection();
    }
}

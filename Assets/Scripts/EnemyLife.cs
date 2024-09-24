using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    int life = 10;
    public float flashDuration = 0.1f;  
    private Color originalColor;
    private Renderer enemyRenderer;
    
    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        originalColor = enemyRenderer.material.color;
    }
    public void ApplieDamage(int d){
        life -= d;
        Debug.Log("Acertou o inimigo");
        if(life <= 0) Destroy(gameObject);
        else StartCoroutine(Flash());
    }
    private IEnumerator Flash()
    {   
        enemyRenderer.material.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.material.color = originalColor;
    }
}

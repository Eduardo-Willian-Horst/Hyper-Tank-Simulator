using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoLife : MonoBehaviour
{
    static public int lifePlayer2 = 100;
    public float flashDuration = 0.1f;
    private Color originalColor;
    private Renderer render;
    private ParticleSystem smoke;
    private ParticleSystemRenderer smokeRender;
    


    void Start()
    {
        GameObject smokeObject = GameObject.Find("Particle System Player 2");
        smoke = smokeObject.GetComponent<ParticleSystem>();
        smoke.Pause();
        render = GetComponent<Renderer>();
        originalColor = render.material.color;
        
    }

    void Update()
    {
        
        if (lifePlayer2 <= 50) smoke.Play();

        if (lifePlayer2 <= 25)
        {
            smokeRender.minParticleSize = 0.16f;
            smokeRender.maxParticleSize= 1.5f;

        }
    }
    public void ApplieDamage(int d)
    {
        lifePlayer2 -= d;
        Debug.Log("Acertou o inimigo");
        if (lifePlayer2 <= 0) Destroy(gameObject);
        else StartCoroutine(Flash());
    }
    private IEnumerator Flash()
    {
        render.material.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        render.material.color = originalColor;
    }
}

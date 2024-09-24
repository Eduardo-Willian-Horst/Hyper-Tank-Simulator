using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneLife : MonoBehaviour
{
    static public int lifePlayer1 = 100;
    public float flashDuration = 0.1f;
    private Color originalColor;
    private Renderer render;
    private ParticleSystem smoke;
    private ParticleSystemRenderer smokeRender;


    void Start()
    {
        GameObject smokeObject = GameObject.Find("Particle System Player 1");
        smoke = smokeObject.GetComponent<ParticleSystem>();
        smokeRender = smokeObject.GetComponent<ParticleSystemRenderer>();
        smoke.Pause();
        render = GetComponent<Renderer>();
        originalColor = render.material.color;
    }

    void Update()
    {
        if (lifePlayer1 <= 50) smoke.Play();
        
        if (lifePlayer1 <= 25)
        {
            smokeRender.minParticleSize = 0.16f;
            smokeRender.maxParticleSize= 1.5f;
        }
        if(PlayerMoveOne.GODMODE) {
            lifePlayer1 = 100000;
            smoke.Stop();
        }

    }
    public void ApplieDamage(int d)
    {
        lifePlayer1 -= d;
        Debug.Log("Acertou o inimigo");
        if (lifePlayer1 <= 0) Destroy(gameObject);
        else StartCoroutine(Flash());
    }
    private IEnumerator Flash()
    {
        render.material.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        render.material.color = originalColor;
    }
}

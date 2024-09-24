using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerTwo : MonoBehaviour
{
    
    [SerializeField]
    private GameObject preFabTiro;

    private bool canShot = true;
    [Range(0f,3f)]
    private float delay = 1.5f;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && canShot){
            Instantiate(preFabTiro, this.transform.position, this.transform.rotation);
            StartCoroutine(DelayShot());
        }
    }

    private IEnumerator DelayShot(){
        canShot = false;
        yield return new WaitForSeconds(delay);
        canShot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerOne : MonoBehaviour
{

    [SerializeField]
    private GameObject preFabTiro;
    private bool canShot = true;
    [Range(0f, 3f)]
    private float delay = 1.5f;



    void Update()
    {
        if (PlayerMoveOne.GODMODE)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(preFabTiro, this.transform.position, this.transform.rotation);
                Instantiate(preFabTiro, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 10, this.transform.eulerAngles.z));
                Instantiate(preFabTiro, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y - 10, this.transform.eulerAngles.z));
                
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                for(int i = 0; i < 360; i+=10){
                    Instantiate(preFabTiro, this.transform.position, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y + i, this.transform.eulerAngles.z));
                }
                
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canShot)
            {
                Instantiate(preFabTiro, this.transform.position, this.transform.rotation);
                StartCoroutine(DelayShot());
            }
        }

    }

    private IEnumerator DelayShot()
    {
        canShot = false;
        yield return new WaitForSeconds(delay);
        canShot = true;
    }
}

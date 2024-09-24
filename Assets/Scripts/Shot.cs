using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    
    [SerializeField]
    private GameObject preFabTiro;

    

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(preFabTiro, this.transform.position, this.transform.rotation);
        }
    }
}

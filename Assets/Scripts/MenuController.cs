using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    static public void LoadTrain(){
        SceneManager.LoadScene("EnemysStatics");
    }

    static public void LoadPlayerVsPc(){
        SceneManager.LoadScene("EnemysMovement");
    }

    static public void LoadPvp(){
        SceneManager.LoadScene("Pvp");
    }

    

}

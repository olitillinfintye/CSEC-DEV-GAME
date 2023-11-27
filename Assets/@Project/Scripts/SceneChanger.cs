using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void start(){

    SceneManager.LoadScene("Stage1");

   }

   public void credit(){

    SceneManager.LoadScene("credit");

   }
   public void home(){

    SceneManager.LoadScene("menu");
   }

   public void exit(){

    Application.Quit();
    
    Debug.Log("exit..");

   }
}

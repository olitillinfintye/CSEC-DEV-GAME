using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
   
   public void OpenUrl(string UrlLink)
   {

    Application.OpenURL(UrlLink);
   
   }
}

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public string key;
    public void Update()
    {
        if (Input.GetKeyDown(key))
        {
            //for pc, Return = Enter Button
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
  

}
    
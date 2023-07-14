using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Image image; 

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Respawn") != null) {
            image = GetComponent<Image>();
            Destroy(this.gameObject);
        }
    }
}

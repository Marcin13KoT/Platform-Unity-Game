using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public AudioSource clickSource;

        public void clickSound() {
            clickSource.PlayOneShot(clickSource.clip, 0.5f);
        }
}

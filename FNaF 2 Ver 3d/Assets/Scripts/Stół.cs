using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stół : MonoBehaviour
{
    public GameObject Sprite;
    private bool OnGui = false;
    private void OnMouseDown()
    {
        if (!OnGui)
        {
            OnGui = true;
            Cursor.lockState = CursorLockMode.None;
            Sprite.SetActive(true);
        }
    }
}

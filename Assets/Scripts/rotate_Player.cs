using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotate_Player : MonoBehaviour
{
   
   private void Update()
    {
        Flip();
    }

 
    void Flip()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);

        }
    }
}

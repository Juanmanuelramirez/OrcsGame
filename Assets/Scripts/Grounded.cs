using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private ControlCharacter controlCharacter;

    void Start()
    {
        controlCharacter = GetComponent<ControlCharacter>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        controlCharacter.grounded = true;
        controlCharacter.jump = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        controlCharacter.grounded = false;
        controlCharacter.jump = true;
    }

}

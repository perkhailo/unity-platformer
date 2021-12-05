using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.jumpEvent += Jump;
    }

    private void OnDisable()
    {
        
    }

    private void Jump()
    {
        
    }
}

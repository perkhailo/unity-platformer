using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceDirectionType
{
    Left,
    Right
}

public class FlipFace : MonoBehaviour
{
    [SerializeField]
    FaceDirectionType faceDirection = FaceDirectionType.Right;
    public float DirectionInput { get; set; }

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        if (!_spriteRenderer)
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (faceDirection.Equals(FaceDirectionType.Right))
        {
            if (DirectionInput < 0)
                Flip(true);

            if (DirectionInput > 0)
                Flip(false);
        } 
        else
        {
            if (DirectionInput < 0)
                Flip(false);

            if (DirectionInput > 0)
                Flip(true);
        }
    }

    private void Flip(bool value)
    {
        _spriteRenderer.flipX = value;
    }
}

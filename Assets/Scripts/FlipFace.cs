using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(PhysicsBehaviour))]
public class FlipFace : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer 
    { 
        get => _spriteRenderer; 
        set => _spriteRenderer = value; 
    }
    public PhysicsBehaviour PhysicsBehaviour { get; set; }

    [SerializeField]
    DirectionType faceDirectionOrigin = DirectionType.Positive;

    private void Awake()
    {
        if (!SpriteRenderer)
            SpriteRenderer = GetComponent<SpriteRenderer>();
        if (!PhysicsBehaviour)
            PhysicsBehaviour = GetComponent<PhysicsBehaviour>();
    }

    private void Update()
    {
        SetFaceDirection(PhysicsBehaviour.HorizontalDirectionMovement, faceDirectionOrigin, ref _spriteRenderer);
    }

    private void SetFaceDirection(DirectionType horizontalDirectionMovement, DirectionType faceDirectio, ref SpriteRenderer spriteRenderer)
    {
        if (horizontalDirectionMovement.Equals(DirectionType.Positive))
        {
            if (faceDirectio.Equals(DirectionType.Negative))
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }

        if (horizontalDirectionMovement.Equals(DirectionType.Negative))
        {
            if (faceDirectio.Equals(DirectionType.Positive))
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }
    }
}

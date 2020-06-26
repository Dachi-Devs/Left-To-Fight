using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteColour : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] spriteRenderers;

    public void SetColour(Color colour)
    {
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.color = colour;
        }
    }
}

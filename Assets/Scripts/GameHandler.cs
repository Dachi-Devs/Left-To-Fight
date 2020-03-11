using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private Texture2D baseTexture;
    [SerializeField]
    private Texture2D headTexture;
    [SerializeField]
    private Texture2D bodyTexture;
    [SerializeField]
    private Material humanMaterial;

    private void Awake()
    {
        Texture2D texture = new Texture2D(512, 512, TextureFormat.RGBA32, true);

        Color[] spriteSheetBasePixels = baseTexture.GetPixels(0, 0, 512, 512);
        texture.SetPixels(0, 0, 512, 512, spriteSheetBasePixels);

        Color[] headPixels = headTexture.GetPixels(0, 0, 128, 128);
        texture.SetPixels(0, 384, 128, 128, headPixels);

        Color[] bodyPixels = bodyTexture.GetPixels(0, 0, 128, 128);
        texture.SetPixels(0, 256, 128, 128, bodyPixels);

        texture.Apply();

        humanMaterial.mainTexture = texture;
    }
}

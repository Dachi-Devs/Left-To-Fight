using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprites : MonoBehaviour
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
        const int HEAD_DIMENSIONS = 128;
        const int BODY_DIMENSIONS = 128;

        int headPixel = Random.Range(0, headTexture.width / HEAD_DIMENSIONS) * HEAD_DIMENSIONS;
        int bodyPixel = Random.Range(0, bodyTexture.width / BODY_DIMENSIONS) * BODY_DIMENSIONS;

        Texture2D texture = new Texture2D(512, 512, TextureFormat.RGBA32, true);

        Color[] spriteSheetBasePixels = baseTexture.GetPixels(0, 0, 512, 512);
        texture.SetPixels(0, 0, 512, 512, spriteSheetBasePixels);

        Color[] headPixels = headTexture.GetPixels(headPixel, 0, HEAD_DIMENSIONS, HEAD_DIMENSIONS);
        texture.SetPixels(0, 384, 128, 128, headPixels);

        Color[] bodyPixels = bodyTexture.GetPixels(bodyPixel, 0, BODY_DIMENSIONS, BODY_DIMENSIONS);
        texture.SetPixels(0, 256, 128, 128, bodyPixels);

        texture.Apply();

        humanMaterial.mainTexture = texture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class FadeSpriteGroup : MonoBehaviour
{
    public float fadeTime;
    public string droppedLayerName;
    private Color tmpColour;

    public void FadeOut()
    {
        GetComponentInChildren<SortingGroup>().sortingLayerName = droppedLayerName;
        StartCoroutine(FadeTimer(0f));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeTimer(1f));
    }

    IEnumerator FadeTimer(float finalAlpha)
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        float alpha = Mathf.Abs(finalAlpha - 1);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
        {
            foreach (SpriteRenderer spr in sprites)
            {
                Color newColor = new Color(spr.color.r, spr.color.g, spr.color.b, Mathf.Lerp(alpha, finalAlpha, t));
                spr.color = newColor;
            }
            yield return null;
        }

        if(finalAlpha == 0)
            GetComponent<DestroySelf>().Destroy();
    }
}

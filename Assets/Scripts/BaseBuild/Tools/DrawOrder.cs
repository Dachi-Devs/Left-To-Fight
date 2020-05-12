using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DrawOrder : MonoBehaviour
{
    private SortingGroup sprGroup;
    private List<SpriteRenderer> sprRends;
    [SerializeField] private SpriteRenderer lowestSprite = null;
    public int offset;

    void Start()
    {
        sprRends = new List<SpriteRenderer>();
        sprGroup = GetComponent<SortingGroup>();

        if(GetComponent<SpriteRenderer>() != null)
            sprRends.Add(GetComponent<SpriteRenderer>());
        foreach(SpriteRenderer spr in GetComponentsInChildren<SpriteRenderer>())
        {
            sprRends.Add(spr);
        }
    }

    void LateUpdate()
    {
        if (sprGroup != null)
            UsingSortingGroup();
        else
            SingleSprite();
    }

    void UsingSortingGroup()
    {
        foreach (SpriteRenderer spr in sprRends)
        {
            if (lowestSprite == null)
                lowestSprite = spr;

            if ((spr.bounds.min.y) < lowestSprite.bounds.min.y)
                lowestSprite = spr;
        }

        sprGroup.sortingOrder = (int)Camera.main.WorldToScreenPoint(lowestSprite.bounds.min).y * -1 + offset;
    }

    void SingleSprite()
    {
        lowestSprite = sprRends[0];
        lowestSprite.sortingOrder = (int)Camera.main.WorldToScreenPoint(lowestSprite.bounds.min).y * -1 + offset;
    }
}

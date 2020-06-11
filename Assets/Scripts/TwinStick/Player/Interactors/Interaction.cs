using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Color highlightColour = new Color(227f, 182f, 36f, 1f);
    public SpriteRenderer spr;

    public virtual void InteractWithObject(GameObject interactor) => Debug.Log("Base Interaction");

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.root.gameObject.tag == "Player") { HighlightSelf(); }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.root.gameObject.tag == "Player") { ClearHighlight(); }
    }

    private void ClearHighlight() => spr.color = new Color(255f, 255f, 255f, 1f);

    private void HighlightSelf() => spr.color = highlightColour;
}

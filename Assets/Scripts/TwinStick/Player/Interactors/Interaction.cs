using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Color highlightColour = new Color(227f, 182f, 36f, 1f);
    public SpriteRenderer spr;
    private string playerTag = "Human";

    public virtual void InteractWithObject(GameObject interactor) => Debug.Log("Base Interaction");

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (spr != null)
        {
            if (coll.transform.root.gameObject.tag == playerTag) { HighlightSelf(); }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (spr != null)
        {
            if (coll.transform.root.gameObject.tag == playerTag) { ClearHighlight(); }
        }
    }

    private void ClearHighlight() => spr.color = new Color(255f, 255f, 255f, 1f);

    private void HighlightSelf() => spr.color = highlightColour;
}

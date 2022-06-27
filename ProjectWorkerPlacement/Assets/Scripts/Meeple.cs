using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meeple : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 screenPoint;
    private Vector3 offset;

    private Area currentArea;

    private void OnEnable()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(
            gameObject.transform.position);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                screenPoint.z));

        offset = gameObject.transform.position - mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            screenPoint.z);

        Vector3 curPosition = 
            Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        // TODO: Snap to a position
        // Determine collider overlaps
        Collider2D[] colliders = new Collider2D[1];
        int colliderCount = boxCollider.OverlapCollider(
            new ContactFilter2D(), colliders);

        if (colliderCount <= 0)
        {
            ReturnMeeple();
        }
        else
        {
            if (TryChangeArea(colliders) == false)
            {
                ReturnMeeple();
            }
        }
    }

    private bool TryChangeArea(Collider2D[] colliders)
    {
        // Collided with something,
        // remove from previous area
        // add to new area

        if (colliders[0]
            .TryGetComponent<Area>(out Area newArea) == true)
        {
            if (newArea.TryAddMeeple(this))
            {
                return true;
            }
        }

        return false;
    }

    private void ReturnMeeple()
    {
        transform.position = transform.parent.transform.position;
    }

    public void SetCurrentArea(Area newArea)
    {
        // See if meeple needs to be removed from previous current area
        if (currentArea != null)
        {
            currentArea.RemoveMeeple(this);
        }

        currentArea = newArea;
    }
}

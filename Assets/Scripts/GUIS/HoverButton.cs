using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour
{
    // Declare the button
    Selectable button;

    void Start()
    {
        // get the selectable component from button
        button = GetComponent<Selectable>();
    }
    public void OnHover(PointerEventData eventData)
    {
        // Select the button when hovered
        button.Select();
    }
}

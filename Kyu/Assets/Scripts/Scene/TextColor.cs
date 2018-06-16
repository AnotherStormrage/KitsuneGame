using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color colorin, colorado;
    private Text myText;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.color = colorin;
        myText.fontSize = 55;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.color = colorado;
        myText.fontSize = 50;
    }
}


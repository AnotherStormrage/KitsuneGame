using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnPointEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Color colorin, colorado;
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<Text>().color = colorado;
        //gameObject.GetComponentInChildren<Text>().color = Color.white;
        gameObject.GetComponentInChildren<Text>().fontSize = 60;
    }

    // Use this for initialization
    void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData) {
        //gameObject.GetComponentInChildren<Text>().color = new Color (110, 110, 110, 255);
        gameObject.GetComponentInChildren<Text>().color = colorin;
        gameObject.GetComponentInChildren<Text>().fontSize = 65;
    }
	/*
	// Update is called once per frame
	void IPointExitHandler.OnPointerExit (PointerEventData eventData) {
        gameObject.GetComponentInChildren<Text>().color = new Color(0, 0, 255, 255);
    }*/
}


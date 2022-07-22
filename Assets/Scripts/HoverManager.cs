using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverManager : MonoBehaviour
{

    public TextMeshProUGUI tiptext;
    public RectTransform TipWindow;

    public static Action<String,Vector2> OnMouseHover;
    public static Action onMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += showtip;
        onMouseLoseFocus += hidetip;

    }
    private void OnDisable()
    {
        OnMouseHover -= showtip;
        onMouseLoseFocus -= hidetip;
    }
    // Start is called before the first frame update
    void Start()
    {
        hidetip();
    }

    // Update is called once per frame
    private void showtip(String tip,Vector2 MousePosition)
    {
        tiptext.text = tip;
        TipWindow.sizeDelta = new Vector2(tiptext.preferredWidth > 200 ? 200 : tiptext.preferredWidth,tiptext.preferredHeight);
        TipWindow.gameObject.SetActive(true);
        TipWindow.transform.position = new Vector2(MousePosition.x + TipWindow.sizeDelta.x * 2,MousePosition.y);

    }
    private void hidetip() 
    {
        tiptext.text = default;
        TipWindow.gameObject.SetActive(false);
    }
}

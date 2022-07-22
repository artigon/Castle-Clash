using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TipWindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    public string tiptoShow;
    private float timeToWait = 0.5f;


    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverManager.onMouseLoseFocus();
    }
    private void showmessage()
    {
        HoverManager.OnMouseHover(tiptoShow,Input.mousePosition);

    }
    private IEnumerator StartTimer()

    {
        yield return new WaitForSeconds(timeToWait);
        showmessage();
    }
}

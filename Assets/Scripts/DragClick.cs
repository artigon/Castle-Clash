using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragClick : MonoBehaviour
{
    Camera mycam;
    [SerializeField]
    RectTransform boxVisual;


    Rect SelectionBox;
    Vector2 startposition;
    Vector2 EndPosition;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        startposition = Vector2.zero;
        EndPosition = Vector2.zero;
        drawvisual();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startposition = Input.mousePosition;
            SelectionBox = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            EndPosition = Input.mousePosition;
            drawvisual();
            drawSelection();

        }
        if (Input.GetMouseButtonUp(0))
        {
            selectionUnits();
            startposition = Vector2.zero;
            EndPosition = Vector2.zero;
            drawvisual();


        }
    }
    void drawvisual()
    {
        Vector2 boxStart = startposition;
        Vector2 boxEnd = EndPosition;

        Vector2 BoxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = BoxCenter;

        Vector2 BoxSize = new Vector2(Mathf.Abs(boxStart.x-boxEnd.x),Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = BoxSize;
    }
    void drawSelection()
    {
        if (Input.mousePosition.x < startposition.x)
        {
            SelectionBox.xMin = Input.mousePosition.x;
            SelectionBox.xMax = startposition.x;
        }
        else
        {
            SelectionBox.xMin = startposition.x;
            SelectionBox.xMax = Input.mousePosition.x;
        }
        if (Input.mousePosition.y < startposition.y )
        {
            SelectionBox.yMin = Input.mousePosition.y;
            SelectionBox.yMax = startposition.y;
        }
        else
        {
            SelectionBox.yMin = startposition.y;
            SelectionBox.yMax = Input.mousePosition.y;
        }
    }
    void selectionUnits()
    {
        foreach(var unit in UnitSelections.Instance.unitList)
        {
            if (SelectionBox.Contains(mycam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitSelections.Instance.DragSelect(unit);

            }
        }
    }
}

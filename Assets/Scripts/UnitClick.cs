using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mycam;
    public LayerMask redMask;
    public LayerMask blueMask;
    public bool redSelected;
    public bool blueSelected;
    public LayerMask clickable;
    public LayerMask ground;
    public LayerMask fort;
    public UnitSelections unitSelections;
    public GameObject clickMarker;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;

        if (redSelected)
            clickable = redMask;
        else if (blueSelected)
            clickable = blueMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //UnitSelections.Instance.Deselectall();
            //if we hit a clickable target
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);

                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.Deselectall();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                unitSelections.sendUnitToWalkPoint(hit.point);
            }
            clickMarker.transform.position = hit.point;
        }
        else if (Input.GetMouseButtonDown(1) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                unitSelections.sendUnityToWalkPointOrder(hit.point);
            }
            clickMarker.transform.position = hit.point;
        }
    }
}


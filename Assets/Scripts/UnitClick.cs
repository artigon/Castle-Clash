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
            //if we hit a clickable target
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,Mathf.Infinity,clickable))
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
            //if we didnt;
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                UnitSelections.Instance.Deselectall();
            }
        }
    }
}

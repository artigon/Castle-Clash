using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
}

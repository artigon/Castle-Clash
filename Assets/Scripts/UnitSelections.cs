using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> SelectedList = new List<GameObject>();
    public GameObject clickMarker;


    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance;  } }

     void Awake()
    {
        if(_instance !=null&& _instance!=this){
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }   

   
     }
    public void ClickSelect(GameObject unitToAdd)
    {
        Deselectall();

        SelectedList.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!SelectedList.Contains(unitToAdd))
        {
            SelectedList.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            SelectedList.Remove(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        
        if (!SelectedList.Contains(unitToAdd))
        {
            SelectedList.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
    public void Deselectall()
    {
        foreach (var unit in SelectedList)
        {
           unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        SelectedList.Clear();
        //if (clickMarker.activeSelf)
        //    clickMarker.SetActive(false);
    }

    public void Deselect(GameObject unitToDESLECT)
    {

    }
    public void sendUnitToWalkPoint(Vector3 v)
    {
        foreach (var unit in SelectedList)
        {
            unit.GetComponent<npcMovmentMec>().getWalkPoint(v);
        }
    }

    public void sendUnityToWalkPointOrder(Vector3 v)
    {
        foreach (var unit in SelectedList)
        {
            unit.GetComponent<npcMovmentMec>().walkToWalkPointOrder(v);
        }
    }

    //public void sendUnitToAttackFort(GameObject fort)
    //{
    //    foreach (var unit in SelectedList)
    //    {
    //        unit.GetComponent<npcMovmentMec>().attackFortFirst(fort);
    //    }
    //}
}

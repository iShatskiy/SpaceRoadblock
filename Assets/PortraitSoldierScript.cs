using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitSoldierScript : MonoBehaviour
{
    public int position;
    [SerializeField] Sprite rifle;
    [SerializeField] Sprite bomber;

    public void OnEnable()
    {
        if (GameManager.instance.ss.curSoldiers !=null)
            foreach (var soldier in GameManager.instance.ss.curSoldiers)
            {
                if (soldier.GetComponent<SoldierBase>().position == position)
                {
                    SelectPortrait(soldier.GetComponent<SoldierBase>().type);
                    Debug.Log(soldier.GetComponent<SoldierBase>().type);
                }
            }
    }

    public void SelectPortrait(int num)
    {
        if (num == 0)
            GetComponent<Image>().sprite = rifle;
        if (num == 1)
            GetComponent<Image>().sprite = bomber;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
    public List<Button> buttons;
    public List<GameObject> upgradeButtons;
    public List<GameObject> unitsCard;

    public List<Button> units;

    public void LateUpdate()
    {
        if (GameManager.instance.countAmanith <= GameManager.instance.ss.soldiers[0].GetComponent<SoldierBase>().price)
        {
            units[0].interactable = false;
        }
        else
        {
            units[0].interactable = true;
        }
        if (GameManager.instance.countAmanith <= GameManager.instance.ss.soldiers[1].GetComponent<SoldierBase>().price)
        {
            units[1].interactable = false;
        }
        else
        {
            units[1].interactable = true;
        }
    }

    public void RefreshButtons()
    {
        int i = 0;
        foreach (var button in buttons)
        {
            if (GameManager.instance.ss.positions.soldierPoints[i].isEmpty == true)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
                
            }
            i++;
        }
    }

    public void RefreshButton(int num)
    {
        if (GameManager.instance.ss.positions.soldierPoints[num].isEmpty == true)
        {
            buttons[num].interactable = true;
        }
        else
        {
            buttons[num].interactable = false;
        }
    }

    public void SwitchUpgradeButton(int position)
    {
        if (position == 0)
        {
            unitsCard[position].SetActive(true);
            upgradeButtons[0].SetActive(true);
            upgradeButtons[1].SetActive(true);
        }
        else if (position == 1) {
            unitsCard[position].SetActive(true);
            upgradeButtons[2].SetActive(true);
            upgradeButtons[3].SetActive(true);
        }
        else if (position == 2)
        {
            unitsCard[position].SetActive(true);
            upgradeButtons[4].SetActive(true);
            upgradeButtons[5].SetActive(true);
        }
        else if (position == 3)
        {
            unitsCard[position].SetActive(true);
            upgradeButtons[6].SetActive(true);
            upgradeButtons[7].SetActive(true);
        }
    }
}


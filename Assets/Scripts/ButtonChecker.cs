using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
    public List<Button> buttons;
    public List<GameObject> upgradeButtons;

    public void RefreshButtons()
    {
        int i = 0;
        foreach (var button in buttons)
        {
            if (GameManager.instance.ss.positions.soldierPoints[i].isEmpty == true &&
                GameManager.instance.countAmanith >= GameManager.instance.ss.soldiers[0].GetComponent<SoldierBase>().price)
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
        if (GameManager.instance.ss.positions.soldierPoints[num].isEmpty == true &&
            GameManager.instance.countAmanith >= GameManager.instance.ss.soldiers[0].GetComponent<SoldierBase>().price)
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
            upgradeButtons[0].SetActive(true);
            upgradeButtons[1].SetActive(true);
        }
        else if (position == 1) {
            upgradeButtons[2].SetActive(true);
            upgradeButtons[3].SetActive(true);
        }
        else if (position == 2)
        {
            upgradeButtons[4].SetActive(true);
            upgradeButtons[5].SetActive(true);
        }
        else if (position == 3)
        {
            upgradeButtons[6].SetActive(true);
            upgradeButtons[7].SetActive(true);
        }
    }
}


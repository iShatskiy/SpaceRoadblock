using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonChecker_UpSpeed : MonoBehaviour
{
    public int position;
    private Button b;
    private TextMeshProUGUI t;
    private SoldierBase mySoldier;

    void Awake() 
    {
        b = GetComponent<Button>();
        t = GetComponentInChildren<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        if (GameManager.instance.ss.curSoldiers[0] == null)
        {
            return;
        }
        if (mySoldier == null)
        {
            foreach (var soldier in GameManager.instance.ss.curSoldiers)
            {
                if (soldier.GetComponent<SoldierBase>().position == position)
                {
                    mySoldier = soldier.GetComponent<SoldierBase>();
                }
            }
        }
        int lvl = mySoldier.curLevelSpeed;

        if (lvl == GameManager.instance.su.upgradesSpeedShooter.Length)
        {
            gameObject.SetActive(false);
        }
        if (mySoldier.curLevelSpeed <= GameManager.instance.su.upgradesSpeedShooter.Length-1)
               {
        t.text =
            GameManager.instance.su.upgradesSpeedShooter[
                mySoldier.curLevelSpeed].price.ToString();
        if (GameManager.instance.countAmanith >= GameManager.instance.su.upgradesSpeedShooter[lvl].price)
            {
                b.interactable = true;
                t.color = Color.green;
            }
            else 
            {
                b.interactable = false;
                t.color = Color.grey;
            }
               }
    }
}

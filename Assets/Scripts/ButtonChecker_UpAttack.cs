using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker_UpAttack : MonoBehaviour
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
        int lvl = mySoldier.curLevelAttack;
        if (lvl == GameManager.instance.su.upgradesAttackShooter.Length)
        {
            gameObject.SetActive(false);
        }

        if (mySoldier.curLevelAttack <= GameManager.instance.su.upgradesAttackShooter.Length-1)
               {
        t.text = "+ATK (-" +
           GameManager.instance.su.upgradesAttackShooter[
               mySoldier.curLevelAttack].price + ")";

               if (GameManager.instance.countAmanith >= GameManager.instance.su.upgradesAttackShooter[lvl].price)
            {
                b.interactable = true;
            }
            else 
            {
                b.interactable = false;
            }
            
               }
        
    }
}

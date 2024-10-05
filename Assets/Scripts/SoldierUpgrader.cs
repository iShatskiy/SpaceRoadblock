using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUpgrader : MonoBehaviour
{
    public LvlAttack[] upgradesAttackShooter;
    public LvlSpeed[] upgradesSpeedShooter;
    GameObject mySoldier;

    public void UpgradeAttack(int position)
    {
        foreach (GameObject soldier in GameManager.instance.ss.curSoldiers) {
            if (soldier.GetComponent<SoldierBase>().position == position)
            {
                mySoldier = soldier;
            }
        }
        
        int lvl = mySoldier.GetComponent<SoldierBase>().curLevelAttack;
        mySoldier.GetComponent<SoldierBase>().UpgradeAttack(upgradesAttackShooter[lvl].value);
        GameManager.instance.ChangeAmanith(-upgradesAttackShooter[lvl].price);
    }

    public void UpgradeSpeed(int position)
    {
        foreach (GameObject soldier in GameManager.instance.ss.curSoldiers) {
            if (soldier.GetComponent<SoldierBase>().position == position)
            {
                mySoldier = soldier;
            }
        }
        
        int lvl = mySoldier.GetComponent<SoldierBase>().curLevelSpeed;
        mySoldier.GetComponent<SoldierBase>().UpgradeSpeed(upgradesSpeedShooter[lvl].value);
        GameManager.instance.ChangeAmanith(-upgradesSpeedShooter[lvl].price);
    }

}

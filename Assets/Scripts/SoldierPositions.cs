using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPositions : MonoBehaviour
{
    public List<SoldierPoint> soldierPoints;

    public bool CheckPosition(int num)
    {
        if (soldierPoints[num].isEmpty == true)
        {
            return true;
        }
        else { 
            return false;
        }
    }

    public Vector3 TakePosition(int num)
    {
        soldierPoints[num].isEmpty = false;
        return soldierPoints[num].gameObject.transform.position;
    }
}

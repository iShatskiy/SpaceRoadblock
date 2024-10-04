using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableChecker : MonoBehaviour
{
    Button b;

    void Awake()
    {
        b = GetComponent<Button>();
    }

}

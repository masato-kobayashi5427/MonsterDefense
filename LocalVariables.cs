using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVariables : MonoBehaviour
{
    static public int currentHP = 100;

    void Start()
    {
        VariableReset();
    }

    // Update is called once per frame
    static public void VariableReset()
    {
        currentHP = 100;
    }
}

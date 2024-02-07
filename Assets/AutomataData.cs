using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AutomataData
{
    public int id = 0;
    public int price = 0;
    public int default_production = 0;
    public string name = "";

    public float position_x;
    public float position_y;
    public float position_z;
    
    public float camera_position_x;
    public float camera_position_y;
    public float camera_position_z;

    public float rotation_y;

    public float scale;
}

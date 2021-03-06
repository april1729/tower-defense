﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HealthBar : MonoBehaviour
{
    float barDisplay = 0;
    public Vector2 pos = new Vector2(20,40);
    public Vector2 size = new Vector2(60,20);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;

    public int Max { get; set; }
    public int Min { get; set; }

    public float Value { get; set; }
 
    void OnGUI()
    {
 
        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, -1*pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
 
            // draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
            GUI.EndGroup ();
 
        GUI.EndGroup ();
 
    }

    void Update()
    {
        // barDisplay is between 0 and 1
        barDisplay = (Value - Min) / (Max - Min);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridOverlayTool
{
    [MenuItem("Tools/Change Grid Transparency")]
    public static void changeTransparency()
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Grid Square");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuScript
{
    [MenuItem("Tools/Turn Off Cube Mesh")]
    public static void TurnOffMeshRenderer()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach(GameObject c in cubes)
        {
          c.GetComponent<Renderer>().enabled = false;
        }
    }

    [MenuItem("Tools/Turn On Cube Mesh")]
    public static void TurnOnMeshRenderer()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject c in cubes)
        {
            c.GetComponent<Renderer>().enabled = true;
        }
    }

}

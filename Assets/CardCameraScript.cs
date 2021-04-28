using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCameraScript : MonoBehaviour
{
    [SerializeField] GameObject cameraGameObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraGameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        cameraGameObject.SetActive(true);
    }
}

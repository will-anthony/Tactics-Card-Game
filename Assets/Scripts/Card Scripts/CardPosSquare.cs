using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPosSquare : MonoBehaviour
{
    [SerializeField] private CardDisplay card;
    [SerializeField] private int maxHandSize;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 cardToCameraPadding = new Vector3(0,1f,0);

        card.transform.position = this.transform.position + cardToCameraPadding;
        card.transform.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}

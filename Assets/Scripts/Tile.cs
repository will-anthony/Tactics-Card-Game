using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public bool current = false;
    [SerializeField] public bool target = false;
    [SerializeField] public bool selectable = false;
    [SerializeField] public bool walkable = true;

    private Color transRed = new Color(1, 0, 0, 0.5f);
    private Color transGreen = new Color(0, 1, 0, 0.5f);
    private Color transWhite = new Color(1, 1, 1, 0.5f);
    private Color transMagenta = new Color(1, 0, 1, 0.5f);
    private Color transparent = new Color(1, 1, 1, 0);


    // Needed variables for BFS (bredth first search)
    public List<Tile> adjacencyList = new List<Tile>();
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = transparent;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = transGreen;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = transRed;
        }
        else
        {
            GetComponent<Renderer>().material.color = transparent;
        }
    }

    public void Reset()
    {
        adjacencyList.Clear();
        this.current = false;
        this.target = false;
        this.selectable = false;
        this.walkable = true;
        this.visited = false;
        this.parent = null;
        this.distance = 0;
    }

    public void FindNeighbors()
    {
        Reset();
        AddToAdjacenyList(Vector3.forward);
        AddToAdjacenyList(-Vector3.forward);
        AddToAdjacenyList(Vector3.right);
        AddToAdjacenyList(-Vector3.right);
    }

    /*
     * Checks if there is a tile in a given direction that is walkable. If it is the tile is added to the AdjacenyList
     */
    private void AddToAdjacenyList(Vector3 direction)
    {
        Vector3 halfExtents = new Vector3(0.25f,0.25f,0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                if (!IsTileOccupied(tile))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }

    /*
     * IsTileOccupied() uses a raycat to determine if another object is sat directly on top of it. 
     */
    private bool IsTileOccupied(Tile tile)
    {
        RaycastHit hit;

        if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
        {
            return true;
        }

        else return false;
    }

    // getters and setters
    //public bool Current { get; set; }
   // public bool Target { get; set; }
    //public bool Selectable { get; set; }
   // public bool Walkable { get; set; }
  //  public bool Visited { get; set; }
   // public Tile Parent { get; set; }
 //   public int Distance { get; set; }


}

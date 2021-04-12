using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private int staminaCost = 1;

    private StaminaTracker staminaTracker;
    private int currentStamina;

    private Vector3 velocity = new Vector3();
    private Vector3 heading = new Vector3();

    private Stack<Tile> path = new Stack<Tile>();
    private Tile currentTile;

    private List<Tile> selectableTiles = new List<Tile>();
    private GameObject[] tiles;

    public bool moving = false;

    private float halfHeight = 0;
    public bool turn = false;


    // Init mehtod called in subclasses start() method
    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Cube");
        staminaTracker = gameObject.GetComponent<StaminaTracker>();
        currentStamina = staminaTracker.GetStamina();

        halfHeight = GetComponent<Collider>().bounds.extents.y;

        TurnOrders.AddUnit(this);       
    }

    // Sets the tile the object is above to 'current' field to true 
    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;
    }

    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;

        Tile tile = null;

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            return tile = hit.collider.GetComponent<Tile>();
        }

        return tile;
    }

    public void ComputeAdjacencyLists()
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors();
        }
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyLists();
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();

            selectableTiles.Add(t);
            t.selectable = true;

            if (t.distance < staminaTracker.GetStamina())
            {
                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }

    /*
     * MoveToTile() sets up the path to the traget tile. It then returns the 
     * number of movements the object must take to reach the target.
     */
    public void MoveToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        moving = true;

        Tile next = tile;
        while(next != null)
        {
            path.Push(next);
            next = next.parent;
        }

        // -1 to exclude tile that object is standing on 
        SpendStamina(path.Count - 1); 
    }

    private void SpendStamina(int stamina)
    {
        staminaTracker.RequestStamina(stamina);
    }

    public void Move()
    {
        if (path.Count > 0)
        {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            // Calculate the unit's position on top of the target tile
            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {

                CalculateHeading(target);
                SetHorizontalVelocity();

                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                // Tile center reached
                transform.position = target;
                path.Pop();
            }
        }
        else
        {
            RemoveSelectableTiles();
            moving = false;
            Debug.Log(staminaTracker.GetStamina());
            if (staminaTracker.GetStamina() > 0)
            {

            }
            else
            {
                AddStamina(10);
                TurnOrders.EndTurn();
            }

        }
    }

    public void RemoveSelectableTiles()
    {
        if(currentTile!= null)
        {
            currentTile.current = false;
            currentTile = null;
        }
        foreach(Tile tile in selectableTiles)
        {
            tile.Reset();
        }

        selectableTiles.Clear();
    }

    void CalculateHeading(Vector3 target)
    {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetHorizontalVelocity()
    {
        velocity = heading * moveSpeed;
    }

    private void AddStamina(int stamina)
    {
        staminaTracker.AddStamina(stamina);
    }

    public void BeginTurn()
    {
        Debug.Log("Turn started");
        turn = true;
    }
    public void EndTurn()
    {
        Debug.Log("Turn ended");
        turn = false;
        
    }
}

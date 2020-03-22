using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Pathfinding pathFinder;
    public PlayerStats playerStats;

    List<Node> currentPath = new List<Node>();

    private Vector3 newPos;
    private Vector3 targetPos;
    private Vector3 rayOffset = new Vector3(0, 1, 0);

    public Node TargetLocation
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(targetPos + rayOffset, Vector3.down, out hit, 1 << LayerMask.NameToLayer("Tile")))
                return hit.transform.gameObject.GetComponent<Node>();
            else return null;
        }
    }

    public Node CurrentLocation
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + rayOffset, Vector3.down, out hit, 1 << LayerMask.NameToLayer("Tile")))
                return hit.transform.gameObject.GetComponent<Node>();
            else return null;
        }
    }

    public bool IsMoving
    {
        get
        {
            return targetPos != transform.position;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        newPos = transform.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (newPos == transform.position && currentPath.Count > 0)
        {
            CurrentLocation.Visited = true;
            newPos = currentPath[0].WorldPosition;
            newPos.y = transform.position.y;
            currentPath.RemoveAt(0);
            playerStats.MovesLeft--;
        }

        if (Input.GetMouseButton(1) && !IsMoving)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject == pathFinder.TargetLocation.gameObject)
                {
                    currentPath = pathFinder.path;
                    targetPos = currentPath[currentPath.Count-1].WorldPosition;
                    targetPos.y = transform.position.y;
                }
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, 10 * Time.deltaTime);
    }
}

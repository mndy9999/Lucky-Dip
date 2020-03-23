using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Pathfinding pathFinder;

    List<Node> currentPath = new List<Node>();

    private Vector3 newPos;
    private Vector3 targetPos;

    public Node TargetLocation
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(targetPos + Vector3.up, Vector3.down, out hit, 1 << LayerMask.NameToLayer("Tile")))
                return hit.transform.gameObject.GetComponent<Node>();
            else return null;
        }
    }

    public Node CurrentLocation
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 1 << LayerMask.NameToLayer("Tile")))
            {
                hit.transform.gameObject.GetComponent<Node>().SteppedOn = true;
                GameManager.Instance.PlayerTilePosition = hit.transform.gameObject.GetComponent<Node>();
                return hit.transform.gameObject.GetComponent<Node>();
            }
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
            PlayerStats.Instance.MovesLeft--;
        }

        if (Input.GetMouseButton(1) && !IsMoving && PlayerStats.Instance.MovesLeft > 0)
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

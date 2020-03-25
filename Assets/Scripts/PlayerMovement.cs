using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Pathfinding pathFinder;
    private PlayerInteraction playerInteraction;

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

    public Node CurrentLocation;

    private Node GetCurrentLocation()
    {
        var lastKnownLocation = CurrentLocation;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 1 << 8) && hit.transform.gameObject.layer == 8)
        {
            
            var tileHit = hit.transform.gameObject.GetComponent<Node>();
            tileHit.SteppedOn = true;

            if (GameManager.Instance.PlayerTilePosition != tileHit)
            {
                GameManager.Instance.PlayerTilePosition = tileHit;
                PlayerStats.Instance.MovesLeft--;
            }
            return tileHit;
        }
        else return lastKnownLocation;
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
        playerInteraction = GetComponent<PlayerInteraction>();
        if (GameManager.Instance.PlayerTilePosition != null)
            transform.position = GameManager.Instance.PlayerTilePosition.transform.position;
        CurrentLocation = GetCurrentLocation();
        GameManager.Instance.PlayerTilePosition = CurrentLocation;
        newPos = transform.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused)
            return;

        if (IsMoving)
        {
            CurrentLocation = GetCurrentLocation();
            if (CurrentLocation == TargetLocation && PlayerStats.Instance.MovesLeft < 1)
            {
                var tileManager = CurrentLocation.GetComponent<TileManager>();
                if (tileManager.IsEnemy)
                    tileManager.CanFight = true;
                else
                    tileManager.CanCollect = true;
                playerInteraction.CheckTileAt(CurrentLocation);
            }
        }


        if (newPos == transform.position && currentPath.Count > 0)
        {
            CurrentLocation.Visited = true;
            newPos = currentPath[0].WorldPosition;
            newPos.y = transform.position.y;
            currentPath.RemoveAt(0);
        }

        if (Input.GetMouseButton(1) && !IsMoving)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (PlayerStats.Instance.MovesLeft < 1)
                {
                    if (hit.collider.gameObject == CurrentLocation.gameObject)
                    {
                        playerInteraction.CheckTileAt(CurrentLocation);
                    }
                }
                else if (hit.collider.gameObject == pathFinder.TargetLocation.gameObject && hit.collider.gameObject != CurrentLocation.gameObject)
                {
                    currentPath = pathFinder.path;
                    targetPos = currentPath[currentPath.Count - 1].WorldPosition;
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

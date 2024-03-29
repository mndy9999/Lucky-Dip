﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{
	private bool mIsLookingAtMap;
	public bool IsLookingAtMap
	{
		get
		{
			return mIsLookingAtMap;
		}
		set
		{

			mIsLookingAtMap = value;
			if (!mIsLookingAtMap && !player.IsMoving)
			{
				TargetLocation = player.CurrentLocation;
			}

		}
	}

	public PlayerMovement player;
	public PlayerStats playerStats;
	private Node targetLocation;

	public List<Node> path = new List<Node>();

	public Node TargetLocation
	{
		get
		{
			return targetLocation;
		}
		private set
		{

				ResetPathHighlights();
				path = FindPath(player.CurrentLocation, value);
				targetLocation = value;
				UpdatePathHighlight();
			
		}
	}

	private void UpdatePathHighlight()
	{
		if (path.Count > 0)
		{
			foreach (var node in path)
			{
				node.HighlightNode();
				node.Visited = false;
			}
		}
	}

	private void ResetPathHighlights()
	{
		if (path.Count > 0)
		{
			foreach (var node in path)
			{
				node.ResetBaseColour();
			}
		}
	}

	private List<Node> FindPath(Node startNode, Node targetNode)
	{
		if (startNode == targetNode || !mIsLookingAtMap)
		{
			return new List<Node>();
		}

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				return RetracePath(startNode, targetNode);
			}

			foreach (Node neighbour in node.Neighbours)
			{
				if (closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + 1;
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = 1;
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
		return new List<Node>();
	}

	private List<Node> RetracePath(Node startNode, Node endNode)
	{
		path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();
		if(path.Count > 0 && path.Count > PlayerStats.Instance.MovesLeft)
			path = path.GetRange(0, PlayerStats.Instance.MovesLeft);
		return path;
	}

	public void Update()
	{
		if (player.IsMoving)
			return;

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1<<8))
		{
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Tile"))
			{
				TargetLocation = hit.collider.gameObject.GetComponent<Node>();
			}
			else if(!Physics.CheckSphere(hit.point, 5, 1 << 8))
			{		
				TargetLocation = player.CurrentLocation;
			}
		}

	}

	public void Start()
	{
		TargetLocation = player.CurrentLocation;
	}

}
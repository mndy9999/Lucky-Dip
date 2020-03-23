using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{

	public int gCost;
	public int hCost;
	public Node parent;

	private bool mVisited;
	public bool Visited
	{
		get
		{
			return mVisited;
		}
		set
		{
			if(mVisited != value)
			{
				mVisited = value;
				if (mVisited) { ResetBaseColour(); }
			}
		}
	}

	public bool SteppedOn;

	public Vector3 WorldPosition;

	private Color baseColour;
	public void ResetBaseColour()
	{
		GetComponent<Renderer>().material.color = baseColour;
	}

	public void HighlightNode()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}

	private void Start()
	{
		baseColour = GetComponent<Renderer>().material.color;
		WorldPosition = gameObject.transform.position;
		GetNeighbours();
	}

	public int fCost
	{
		get
		{
			return gCost + hCost;
		}
	}

    public List<Node> Neighbours { get; } = new List<Node>();

	private void GetNeighbours()
	{
		var colliders = Physics.OverlapBox(transform.position, new Vector3(10, 1, 10), Quaternion.identity);
		foreach (var col in colliders)
		{
			var nodeHit = col.gameObject.GetComponent<Node>();
			if(nodeHit != null && nodeHit != this && IsIn4Direction(nodeHit))
				Neighbours.Add(nodeHit);
		}
	}

	private bool IsIn4Direction(Node node)
	{
		var position = node.transform.gameObject.transform.position;
		return position.x < transform.position.x && position.z == transform.position.z
			|| position.x > transform.position.x && position.z == transform.position.z
			|| position.x == transform.position.x && position.z < transform.position.z
			|| position.x == transform.position.x && position.z > transform.position.z;
	}

}
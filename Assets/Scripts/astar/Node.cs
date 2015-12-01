using UnityEngine;
using System.Collections;

public class Node : IHeapItem<Node> {
	
	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int costoDesp;
	public int heuristica;
	public Node parent;
	int heapIndex;
	
	public Node(bool w, Vector3 wp, int x, int y) {
		walkable = w;
		worldPosition = wp;
		gridX = x;
		gridY = y;
	}

	public int fCost {
		get {
			return costoDesp + heuristica;
		}
	}

	public int HeapIndex {
		get {
			return heapIndex;
		}
		set {
			heapIndex = value;
		}
	}

	public int CompareTo(Node nodeToCompare) {
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if (compare == 0) {
			compare = heuristica.CompareTo(nodeToCompare.heuristica);
		}
		return -compare;
	}
}

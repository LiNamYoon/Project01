using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public int X, Y;
	public Node(int x, int y)
	{
		X = x;
		Y = y;
	}
}
public class TestNodeManager : MonoBehaviour
{
    public int max;
	private int xTarget, yTarget;
	public int offset;
    public GameObject node;

	private Dictionary<(int, int), Node> nodeMap = new Dictionary<(int, int), Node>();

	private List<TestNode> testNodeList = new List<TestNode>();
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			MakeNode();
		}
	}
	private List<List<Node>> nodes = new List<List<Node>>();
	private void MakeNode()
	{
		int[,] map = new int[max, max];
		// 1 2 6
		// 3 5 7
		// 4 8 9
		

		// 
		int xPos = 0, yPos = 0;
		int value = 0;
		bool isLeft = false;
		int count = max * max;
		for (int i = 0; i < count; i++)
		{
			map[xPos, yPos] = ++value;

			if (isLeft)
			{
				yPos++;
				if(yPos >= max)
				{
					yPos = max - 1;
					xPos++;
					isLeft = false;
				}
				else
				{
					xPos--;
					if (xPos < 0)
					{
						xPos = 0;
						isLeft = false;
					}
				}
			}
			else
			{
				xPos++;
				if(xPos >= max)
				{
					xPos = max - 1;
					yPos++;
					isLeft = true;
				}
				else
				{
					yPos--;
					if (yPos < 0)
					{
						yPos = 0;
						isLeft = true;
					}
				}
			}

		}

		for (int y = 0; y < max; y++)
		{
			string text = "";
			for (int x = 0; x < max; x++)
			{
				text += $"-{map[x, y]}-";
			}

			Debug.Log($"{text}");
		}
		xTarget = Random.Range(0, max);
		yTarget = Random.Range(0, max);
		Debug.Log($"A [{xTarget},{yTarget}]: {map[xTarget, yTarget]}");

		int result = 0;
		if(xTarget > 0 && (xTarget % 2) == 0)
		{
			var xValue = xTarget + 1;
			result = (xValue * (xValue + 1) / 2) + (xTarget + 1);
			// Â¦¼ö right 4
		}
		else
		{
			result = (xTarget * (xTarget + 1) / 2) + (xTarget + 1);
		}

		Debug.Log($"B [{xTarget},{yTarget}]: {result}");
	}

	//private TestNode GetNode()
	//{
	//	for (int i = 0; i < testNodeList.Count; i++)
	//	{
	//		ga testNodeList[i]
	//	}
	//}
}

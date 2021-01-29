using System;
using AdjacencyList = System.Collections.Generic.SortedDictionary<string, System.Collections.Generic.List<string>>;

public enum NodeState
{
    Win,
    Lose,
    Draw
}


//GameState
public class Node
{
    public NodeState state = NodeState.Draw;

    public Node(NodeState nodeState)
    {
        this.state = nodeState;
    }

}


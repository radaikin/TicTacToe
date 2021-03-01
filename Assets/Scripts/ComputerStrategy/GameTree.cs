using System;
using System.Collections.Generic;
using AdjacencyList = System.Collections.Generic.SortedDictionary<string, System.Collections.Generic.List<string>>;

public class GameTree
{
    AdjacencyList m_adjacencyList = new AdjacencyList();
    private SortedDictionary<string, Node> hashToNode = new SortedDictionary<string, Node>();

    public GameTree()
    {
    }

    public void innit()
    {
        BuildTree("_________", true);
        StateCulculation("_________", true);
        Console.Write("Done");
    }

    public bool isGameOver(CellState[] field)
    {
        return isLeaf(hash(field));
    }
    //Call only if Game Over and not Draw
    public PlayerSide Winner(CellState[] field)
    {
        Node node;
        hashToNode.TryGetValue(hash(field), out node);
        return node.state == NodeState.Win ? PlayerSide.FirstPlayer : PlayerSide.SecondPlayer;
    }
    //Call only if Game Over
    public bool isDraw(CellState[] field)
    {
        return !hasThreeInRaw(hash(field));
    }

    public List<int> getCells(CellState[] field, NodeState state)
    {
        List<int> result = new List<int>();

        List<string> childrens;
        m_adjacencyList.TryGetValue(hash(field), out childrens);
        foreach (string child in childrens)
        {
            Node node;
            hashToNode.TryGetValue(child, out node);
            if (node.state == state)
            {
                result.Add(FindDifference(hash(field), child));
            }
        }
        return result;
    }

    private int FindDifference(string s1, string s2)
    {
        for (int i = 0; i < 9; i++)
        {
            if (s1[i] != s2[i]) return i;
        }
        return -1;
    }

    private void BuildTree(string nodeHash, bool side)
    {
        if (m_adjacencyList.ContainsKey(nodeHash)) return;
        m_adjacencyList.Add(nodeHash, new List<string>());
        if (hasThreeInRaw(nodeHash))
        {
            Node result = new Node(side ? NodeState.Lose : NodeState.Win);
            hashToNode.Add(nodeHash, result);
            return;
        }
        List<string> value;
        m_adjacencyList.TryGetValue(nodeHash, out value);
        for (int i = 0; i < 9; i++)
        {
            if (nodeHash[i] == '_')
            {
                char[] childHash = nodeHash.ToCharArray();
                childHash[i] = side ? 'x' : 'o';
                value.Add(new string(childHash));
            }
        }
        if (value.Count == 0)
        {
            hashToNode.Add(nodeHash, new Node(NodeState.Draw));
            return;
        }
        foreach (string child in value)
        {
            BuildTree(child, !side);
        }
    }

    private bool isLeaf(string nodeHash)
    {
        bool hasEmpty = false;
        foreach (char c in nodeHash)
        {
            hasEmpty |= c == '_';
        }

        return hasThreeInRaw(nodeHash) || !hasEmpty;
    }

    private bool hasThreeInRaw(string nodeHash)
    {
        return (nodeHash[0] == nodeHash[1] && nodeHash[0] == nodeHash[2] && nodeHash[0] != '_')
            || (nodeHash[3] == nodeHash[4] && nodeHash[3] == nodeHash[5] && nodeHash[3] != '_')
            || (nodeHash[6] == nodeHash[7] && nodeHash[6] == nodeHash[8] && nodeHash[6] != '_')

            || (nodeHash[0] == nodeHash[3] && nodeHash[0] == nodeHash[6] && nodeHash[0] != '_')
            || (nodeHash[1] == nodeHash[4] && nodeHash[1] == nodeHash[7] && nodeHash[1] != '_')
            || (nodeHash[2] == nodeHash[5] && nodeHash[2] == nodeHash[8] && nodeHash[2] != '_')

            || (nodeHash[0] == nodeHash[4] && nodeHash[0] == nodeHash[8] && nodeHash[0] != '_')
            || (nodeHash[2] == nodeHash[4] && nodeHash[2] == nodeHash[6] && nodeHash[2] != '_');
    }

    private Node StateCulculation(string nodeHash, bool side)
    {
        Node result;
        if (hashToNode.TryGetValue(nodeHash, out result)) return result;

        List<string> childes;
        m_adjacencyList.TryGetValue(nodeHash, out childes);
        
        bool hasWinPath = false;
        bool hasDrawPath = false;
        bool hasLosePath = false;
        foreach (string s in childes)
        {
            Node chiledNode = StateCulculation(s, !side);
            hasWinPath |= chiledNode.state == NodeState.Win;
            hasDrawPath |= chiledNode.state == NodeState.Draw;
            hasLosePath |= chiledNode.state == NodeState.Lose;
        }

        if ((side && hasWinPath)||(!hasLosePath && !hasDrawPath)) result = new Node(NodeState.Win);
        else if (!hasLosePath || (side &&  hasDrawPath)) result = new Node(NodeState.Draw);
        else result = new Node(NodeState.Lose);
        hashToNode.Add(nodeHash, result);
        return result;
    }

    private string hash(CellState[] field)
    {
        string nodeHash = "";
        foreach (CellState cs in field)
        {
            switch (cs)
            {
                case CellState.X:
                    nodeHash += "x";
                    break;
                case CellState.O:
                    nodeHash += "o";
                    break;
                default:
                    nodeHash += "_";
                    break;
            }
        }
        return nodeHash;
    }
}

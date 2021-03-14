using System.Collections.Generic;
using UnityEngine;
using AdjacencyList = System.Collections.Generic.SortedDictionary<string, System.Collections.Generic.List<string>>;

public class GameTree : MonoBehaviour
{
    private static GameTree s_instance;
    private AdjacencyList m_adjacencyList = new AdjacencyList();
    private SortedDictionary<string, Node> m_HashToNode = new SortedDictionary<string, Node>();

    private void Start()
    {
        if (s_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Init();
        s_instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public static GameTree GetInstance() => s_instance;

    public AdjacencyList GetAdjacencyList() => m_adjacencyList;

    public Node GetNodeByHash(CellState[] field)
    {
        Node result;
        m_HashToNode.TryGetValue(Hash(field), out result);
        return result;
    }

    public bool NodeHasChild(CellState[] field)
    {
        List<string> childrens = new List<string>();
        m_adjacencyList.TryGetValue(Hash(field), out childrens);
        return childrens.Count != 0;
    }

    public NodeState GetNodeState(CellState[] fieldState)
    {
        Node node;
        m_HashToNode.TryGetValue(Hash(fieldState), out node);
        return node.state;
    }

    public bool IsGameOver(CellState[] field)
    {
        return IsLeaf(Hash(field));
    }
    //Call only if Game Over and not Draw
    public PlayerSide Winner(CellState[] field)
    {
        Node node;
        m_HashToNode.TryGetValue(Hash(field), out node);
        return node.state == NodeState.Win ? PlayerSide.FirstPlayer : PlayerSide.SecondPlayer;
    }
    //Call only if Game Over
    public bool IsDraw(CellState[] field)
    {
        return !HasThreeInRaw(Hash(field));
    }

    public List<int> GetCells(CellState[] field, NodeState state)
    {
        List<int> result = new List<int>();

        List<string> childrens;
        m_adjacencyList.TryGetValue(Hash(field), out childrens);
        foreach (string child in childrens)
        {
            Node node;
            m_HashToNode.TryGetValue(child, out node);
            if (node.state == state)
            {
                result.Add(FindDifference(Hash(field), child));
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
        if (HasThreeInRaw(nodeHash))
        {
            Node result = new Node(side ? NodeState.Lose : NodeState.Win);
            m_HashToNode.Add(nodeHash, result);
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
            m_HashToNode.Add(nodeHash, new Node(NodeState.Draw));
            return;
        }
        foreach (string child in value)
        {
            BuildTree(child, !side);
        }
    }

    private bool IsLeaf(string nodeHash)
    {
        bool hasEmpty = false;
        foreach (char c in nodeHash)
        {
            hasEmpty |= c == '_';
        }

        return HasThreeInRaw(nodeHash) || !hasEmpty;
    }

    private bool HasThreeInRaw(string nodeHash)
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
        if (m_HashToNode.TryGetValue(nodeHash, out result)) return result;

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
        m_HashToNode.Add(nodeHash, result);
        return result;
    }

    private void Init()
    {
        BuildTree("_________", true);
        StateCulculation("_________", true);
        Debug.Log("Game Tree was initialized.");
    }

    private string Hash(CellState[] field)
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

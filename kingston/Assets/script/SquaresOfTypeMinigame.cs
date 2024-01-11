using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SquaresOfTypeMinigame : MonoBehaviour
{
    public GameObject board;
    public List<GameObject> Squares;

    [Serializable]
    public class Group
    {
        public List<int> Members;
        public bool complete;
        public string GroupName;
        public Color Colour;

        public Group(string GroupNameIN,List<int> MembersIN, Color colour, List<GameObject> Squares)
        {
            Members = MembersIN;
            GroupName = GroupNameIN;
            Colour = colour;
            complete = false;
            for (int x = 0; x < Members.Count; x++)
            {
                Squares[Members[x]-1].GetComponent<Minigame_Square>().GroupName = GroupName;
                Squares[Members[x]-1].GetComponent<Minigame_Square>().Colour = Colour;
            }
        }

        public void CheckGroup(List<GameObject> Squares)
        {
            complete = true;
            for (int x = 0; x < Members.Count; x++)
            {
                if (!Squares[Members[x]-1].GetComponent<Minigame_Square>().Activated)
                {
                    complete = false;
                }
            }
        }
    }

    public List<Group> SquareGroups;

    public bool SquareSelected(string groupname) {
        for (int x = 0; x < SquareGroups.Count; x++) // if selected square is part of a group
        {
            if (SquareGroups[x].GroupName == groupname)
            {
                SquareGroups[x].CheckGroup(Squares); // check if group has been completed
                return true;
            }
        }
        for (int x = 0; x < Squares.Count; x++) // if square was not part of a group reset all activated squares that are not part of a completed set
        {
            if (Squares[x].GetComponent<Minigame_Square>().Activated)
            {
                for (int y = 0; y < SquareGroups.Count; y++)
                {
                    if (SquareGroups[y].GroupName == Squares[x].GetComponent<Minigame_Square>().GroupName)
                    {
                        if (!SquareGroups[y].complete)
                        {
                            Squares[x].GetComponent<Minigame_Square>().Deactivate();
                        }
                    }
                }
            }
        }
        return false;
    }

    void Start()
    {
        for (int x = 0; x < 25; x++)
        {
            Squares.Add(board.transform.GetChild(x).gameObject);
        }
        Group group1 = new Group("group 1", new List<int>(){1,2,3} , Color.green, Squares);
        Group group2 = new Group("group 2", new List<int>(){5,6,7} , Color.red, Squares);
        SquareGroups.Add(group1);
        SquareGroups.Add(group2);
    }
}

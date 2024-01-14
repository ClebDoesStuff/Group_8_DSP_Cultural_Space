using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class SquaresOfTypeMinigame : MonoBehaviour
{
    public GameObject board;
    public GameObject WinText;
    public List<GameObject> Squares;
    public Playeritems Playersitems;
    public int Stage;
    public bool Win;

    public bool testbutton;

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
    public List<Group> Words;
    public string CurrentGroup = "NO GROUP SELECTED";

    public bool SquareSelected(string groupname) {
        for (int x = 0; x < SquareGroups.Count; x++) // if selected square is part of a group
        {
            if (SquareGroups[x].GroupName == groupname)
            {
                if (CurrentGroup == groupname || CurrentGroup == "NO GROUP SELECTED")
                {
                    CurrentGroup = groupname;
                    SquareGroups[x].CheckGroup(Squares); // check if group has been completed
                    WinCheck();
                    // function for if all groups have been found
                    return true;
                }
            }
        }
        for (int x = 0; x < Squares.Count; x++) // if square was not part of a group reset all activated squares that are not part of a completed set
        {
            if (Squares[x].GetComponent<Minigame_Square>().Activated)
            {
                for (int y = 0; y < SquareGroups.Count; y++)
                {
                    if (Squares[x].GetComponent<Minigame_Square>().GroupName == "")
                    {
                        Squares[x].GetComponent<Minigame_Square>().Deactivate();
                    }
                    if (SquareGroups[y].GroupName == Squares[x].GetComponent<Minigame_Square>().GroupName)
                    {
                        if (!SquareGroups[y].complete)
                        {
                            CurrentGroup = "NO GROUP SELECTED";
                            Squares[x].GetComponent<Minigame_Square>().Deactivate();
                        }
                    }
                }
            }
        }
        for (int x = 0; x < SquareGroups.Count; x++) // if new selected square is part of a group
        {
            if (SquareGroups[x].GroupName == groupname)
            {
                if (CurrentGroup == groupname || CurrentGroup == "NO GROUP SELECTED")
                {
                    CurrentGroup = groupname;
                    SquareGroups[x].CheckGroup(Squares); // check if group has been completed
                    return true;
                }
            }
        }
        return false;
    }

    public void WinCheck()
    {
        Win = true;
        for (int y = 0; y < SquareGroups.Count; y++)
        {
            if (SquareGroups[y].complete == false)
            {
                Win = false;
            }
        }
        Win = true; // testing purposes
        if (Win) {
            WinText.GetComponent<TextMeshPro>().text = "Stage: " + Stage + "\nAll Groups Found";
            if (Playersitems.artefacts < 4) // 0 1 2 3
            {
                Playersitems.artefacts++; // 1 2 3 4
                if (Playersitems.artefacts < 4)
                {
                    SquareGroups.Clear();
                    SquareGroups.Add(Words[Playersitems.artefacts + 1]); // 2 3 4
                }
            }
        }
    }
    public void ResetGame()
    {
        if (Stage == 4)
        {
            WinText.GetComponent<TextMeshPro>().text = "Stage: " + Stage + "\ncompleted\nAll Artefacts Found";
        }
        else {
            if (Stage < 4 && Win)
            {
                Stage++;
                Win = false;
                for (int x = 0; x < 25; x++)
                {
                    Squares[x].GetComponent<Minigame_Square>().ResetState();
                }
                WinText.GetComponent<TextMeshPro>().text = "Stage: " + Stage;
            }
        }        
    }

    void Start()
    {
        Win = false;
        testbutton = false;
        Stage = 1;
        for (int x = 0; x < 25; x++)
        {
            Squares.Add(board.transform.GetChild(x).gameObject);
        }
        Group group1 = new Group("group 1", new List<int>(){10,11,12,13,15} , Color.green, Squares);
        Group group2 = new Group("group 2", new List<int>(){5,6,7} , Color.red, Squares);
        Group group3 = new Group("group 3", new List<int>(){5,6,7} , Color.yellow, Squares);
        Group group4 = new Group("group 4", new List<int>(){5,6,7} , Color.blue, Squares);
        Group group5 = new Group("group 5", new List<int>(){5,6,7} , Color.magenta, Squares);
        SquareGroups.Add(group1);
        SquareGroups.Add(group2);
        Words.Add(group1);
        Words.Add(group2);
        Words.Add(group3);
        Words.Add(group4);
        Words.Add(group5);
    }

    void Update()
    {
        if (testbutton)
        {
            WinCheck();
            testbutton = false;
        }
    }
}

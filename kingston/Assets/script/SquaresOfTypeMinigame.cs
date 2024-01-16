using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SquaresOfTypeMinigame : MonoBehaviour
{
    public GameObject board;
    public GameObject WinText;
    public List<GameObject> Squares;
    public static int Stage;
    public bool Win;


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
        //Win = true; // testing purposes
        if (Win) {
            WinText.GetComponent<TextMeshPro>().text = "Stage: " + Stage + "\nAll Groups Found";
            if (Playeritems.artefacts < 4) // 0 1 2 3
            {
                Playeritems.artefacts++; // 1 2 3 4
                if (Playeritems.artefacts < 4)
                {
                    SquareGroups.Clear();
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
        else
        {
            if (Stage < 4 && Win)
            {
                Stage++;
                Win = false;
                for (int x = 0; x < 25; x++)
                {
                    Squares[x].GetComponent<Minigame_Square>().ResetState();
                }
                if (Stage == 2)
                {
                    SquareGroups.Clear();

                    Group group3 = new Group("group 3", new List<int>() { 4, 7, 15, 18, 25 }, Color.yellow, Squares);

                    Squares[3].GetComponent<Minigame_Square>().character = "P";
                    Squares[6].GetComponent<Minigame_Square>().character = "L";
                    Squares[14].GetComponent<Minigame_Square>().character = "A";
                    Squares[17].GetComponent<Minigame_Square>().character = "T";
                    Squares[24].GetComponent<Minigame_Square>().character = "E";
                    Words.Add(group3);
                    SquareGroups.Add(group3);
                }
                if (Stage == 3)
                {
                    SquareGroups.Clear();

                    Group group4 = new Group("group 4", new List<int>() { 1, 2, 3, 4, 5, 10 }, Color.blue, Squares);
                    Squares[0].GetComponent<Minigame_Square>().character = "T";
                    Squares[1].GetComponent<Minigame_Square>().character = "R";
                    Squares[2].GetComponent<Minigame_Square>().character = "O";
                    Squares[3].GetComponent<Minigame_Square>().character = "P";
                    Squares[4].GetComponent<Minigame_Square>().character = "H";
                    Squares[9].GetComponent<Minigame_Square>().character = "Y";
                    Words.Add(group4);
                    SquareGroups.Add(group4);
                }
                if (Stage == 4)
                {
                    SquareGroups.Clear();

                    Group group5 = new Group("group 5", new List<int>() { 1, 6, 11, 16, 21, 22 }, Color.magenta, Squares);
                    Squares[0].GetComponent<Minigame_Square>().character = "P";
                    Squares[5].GetComponent<Minigame_Square>().character = "E";
                    Squares[10].GetComponent<Minigame_Square>().character = "W";
                    Squares[15].GetComponent<Minigame_Square>().character = "T";
                    Squares[20].GetComponent<Minigame_Square>().character = "E";
                    Squares[21].GetComponent<Minigame_Square>().character = "R";
                    Words.Add(group5);
                    SquareGroups.Add(group5);
                }
                WinText.GetComponent<TextMeshPro>().text = "Stage: " + Stage;
            }
        }
        if (Stage < 4)
        {
            SceneManager.LoadScene(0);
        }
    }

    void Start()
    {
        Win = false;
        Stage = 1;
        for (int x = 0; x < 25; x++)
        {
            Squares.Add(board.transform.GetChild(x).gameObject);
        }
        Squares[0].GetComponent<Minigame_Square>().character = "S";
        Squares[5].GetComponent<Minigame_Square>().character = "W";
        Squares[6].GetComponent<Minigame_Square>().character = "O";
        Squares[11].GetComponent<Minigame_Square>().character = "R";
        Squares[12].GetComponent<Minigame_Square>().character = "D";
        Squares[4].GetComponent<Minigame_Square>().character = "N";
        Squares[9].GetComponent<Minigame_Square>().character = "E";
        Squares[14].GetComponent<Minigame_Square>().character = "W";
        Group group1 = new Group("group 1", new List<int>(){1,6,7,12,13} , Color.green, Squares);
        Group group2 = new Group("group 2", new List<int>(){5,10,15} , Color.red, Squares);
        
        SquareGroups.Add(group1);
        SquareGroups.Add(group2);
        Words.Add(group1);
        Words.Add(group2);
        
    }
}

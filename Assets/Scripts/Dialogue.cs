using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{
    public string characterName;

    [TextArea(3, 10)]
    public string text; 
}


[System.Serializable]
public class Dialogue
{
    public Line[] lines;
}

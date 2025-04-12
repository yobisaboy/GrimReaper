using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public int id;
    public string name;
    public QuestState state;

    public Quest(int id, string name, QuestState state)
    {
        this.id = id;
        this.name = name;
        this.state = state;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void OnNotify(QuestState state, Quest quest);
}

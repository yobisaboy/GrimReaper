using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }   

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // This method will be called when the subject's state changes
    public void NotifyObservers(QuestState state, Quest quest)
    {
        //another way of a method call for each list item
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(state, quest);
        });
    }
}

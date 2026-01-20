using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EventBuffer<T> : ScriptableObject
{
    List<Action<T>> Listeners = new();
    public void Subscribe(Action<T> listener)
    {
        Listeners.Add(listener);
    }
    public void Unsubscribe(Action<T> listener)
    {
        Listeners.Remove(listener);
    }

    public void Notify(T argument)
    {
        foreach (var listener in Listeners)
        {
            listener?.Invoke(argument);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPoolManager<T> : PersistentSingleton<GenericPoolManager<T>> where T : Component
{
  [SerializeField] private T _pooledPrefab;
  private Queue<T> _pool = new Queue<T>();

  public T Get()
  {
    if (_pool.Count == 0) // If it's empty
    {
      // Generate a new one
      Add(1);
    }
    return _pool.Dequeue();
  }

  private void Add(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var generic = Instantiate(_pooledPrefab);
      generic.gameObject.SetActive(false);
      _pool.Enqueue(generic);
    }
  }

  public void ReturnToPool(T generic)
  {
    generic.gameObject.SetActive(false);
    _pool.Enqueue(generic);
  }
}
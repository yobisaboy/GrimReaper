using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Items
{
    public abstract GameObject GetItemsPrefab();

    public abstract void SetItemsPrefab(GameObject prefab);
}

public class Banana : Items
{
    private GameObject _bananaPrefab;

    public override GameObject GetItemsPrefab()
    {
        return _bananaPrefab;
    }

    public override void SetItemsPrefab(GameObject prefab)
    {
        _bananaPrefab = prefab;
    }
}

public class Cherry : Items
{
    private GameObject _cherryPrefab;

    public override GameObject GetItemsPrefab()
    {
        return _cherryPrefab;
    }

    public override void SetItemsPrefab(GameObject prefab)
    {
        _cherryPrefab = prefab;
    }
}

public class Watermelon : Items
{
    private GameObject _watermelonPrefab;

    public override GameObject GetItemsPrefab()
    {
        return _watermelonPrefab;
    }

    public override void SetItemsPrefab(GameObject prefab)
    {
        _watermelonPrefab = prefab;
    }
}

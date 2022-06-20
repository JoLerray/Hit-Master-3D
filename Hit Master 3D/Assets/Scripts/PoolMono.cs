using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T:MonoBehaviour
{
    public T Prefab {get;}

    public bool AutoExpand { get; set;} 

    public Transform Container {get;}

    private List<T> _pool;

    public PoolMono(T prefab, int count) 
    {
        Prefab = prefab;
        Container = null;
        CreatePool(count);
    }

    public PoolMono(T prefab, int count,Transform container)
    {
        Prefab = prefab;
        Container = container; 
        CreatePool(count);
    }

    private void CreatePool(int count) 
    {
        _pool = new List<T>();

        for(int i = 0; i< count;i++)
            this.CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab,Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        
        _pool.Add(createdObject);

        return createdObject;
    }

    public bool HasFreelement(out T element) 
    {
        foreach(var mono in _pool) 
        {
            if(!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                mono.enabled = true;
                return  true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if(HasFreelement(out var element))
            return element;
        
        if(AutoExpand == true)
            return CreateObject(true);

        throw new System.Exception($"There is no free element in pool of {typeof(T)}");
    }
}

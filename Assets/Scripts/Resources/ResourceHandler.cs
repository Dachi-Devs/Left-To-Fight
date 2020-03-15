using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    private static ResourceHandler instance;

    [SerializeField]
    private Transform resourceNode;
    [SerializeField]
    private Transform storageNode;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform GetResource()
    {
        return resourceNode;
    }

    public static Transform GetResource_Static()
    {
        return instance.GetResource();
    }

    private Transform GetStorage()
    {
        return storageNode;
    }

    public static Transform GetStorage_Static()
    {
        return instance.GetStorage();
    }
}

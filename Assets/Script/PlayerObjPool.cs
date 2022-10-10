using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjPool : MonoBehaviour
{
    public static PlayerObjPool pop;
    [SerializeField] GameObject playerClone;

    private Queue<PlayerMovement> poolingObjQueue = new Queue<PlayerMovement>(); 
    private void Awake()
    {
        pop = this;
        Initialize(10);
    }

    private PlayerMovement CreateNewObject()
    {
        var newObj = Instantiate(playerClone, transform).GetComponent<PlayerMovement>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initialize(int count)
    {
        for(int i=0; i< count; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObject());
        }
    }
    public static PlayerMovement GetObject()
    {
        if(pop.poolingObjQueue.Count > 0)
        {
            var obj = pop.poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = pop.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(PlayerMovement pm)
    {
        pm.gameObject.SetActive(false);
        pm.transform.SetParent(pop.transform);
        pop.poolingObjQueue.Enqueue(pm);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadObjPool : MonoBehaviour
{
    public static DeadObjPool dop;
    [SerializeField] GameObject bodyClone;
    [SerializeField] int Life;

    private Queue<DeadPlayer> poolingObjQueue = new Queue<DeadPlayer>();
    // Start is called before the first frame update
    private void Awake()
    {
        dop = this;
        Initialize(Life);
    }

    private DeadPlayer CreateNewObject()
    {
        var GameObj = Instantiate(bodyClone, transform).GetComponent<DeadPlayer>();
        GameObj.gameObject.SetActive(false);
        return GameObj;
    }
    private void Initialize(int count)
    {
        for(int i = 0; i < count; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObject());
        }
    }

    public static DeadPlayer GetObject()
    {
        if(dop.poolingObjQueue.Count > 0)
        {
            var obj = dop.poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var obj = dop.CreateNewObject();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    public static void ReturnObject(DeadPlayer dp)
    {
        dp.gameObject.SetActive(false);
        dp.transform.SetParent(dop.transform);
        dop.poolingObjQueue.Enqueue(dp);
    }

}

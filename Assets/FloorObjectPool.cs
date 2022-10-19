using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorObjectPool : MonoBehaviour
{
    public static FloorObjectPool FOP;
    [SerializeField] GameObject FloorClone;

    private Queue<SpriteRenderer> poolingObjQueue = new Queue<SpriteRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        FOP = this;
        Initalize(10);
    }

    private SpriteRenderer CreateNewObject()
    {
        var newObj = Instantiate(FloorClone, transform).GetComponent<SpriteRenderer>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initalize(int count)
    {
        for(int i = 0; i < count; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObject());
        }
    }

    public static SpriteRenderer GetObject()
    {
        if(FOP.poolingObjQueue.Count > 0)
        {
            var obj = FOP.poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = FOP.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(SpriteRenderer sr)
    {
        sr.gameObject.SetActive(false);
        sr.transform.SetParent(FOP.transform);
        FOP.poolingObjQueue.Enqueue(sr);
    }
}

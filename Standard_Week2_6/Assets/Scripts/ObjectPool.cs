using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 오브젝트 풀링을 할 게임오브젝트 프리팹
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    private int poolSize = 300; // 최소 300의 반복의 조건을 받음
    private Dictionary<string, List<GameObject>> poolDict;
    public int PoolSize 
    {
        get { return poolSize; }

        set
        {
            if (poolSize < value) //입력 값이 poolSize 보다 크다면 그것을 poolSize로 사용
                poolSize = value;
        }
    }

    private void Awake()
    {
        poolDict = new Dictionary<string, List<GameObject>>();
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++) //시작할 때 poolSize 만큼 prefab을 만들어 놓기위해 반복문
        {
            GameObject obj = Instantiate(prefab); //prefab을 생성한 후 obj 에 할당
            Release(obj); //비활성화하는 메서드
            pool.Add(obj); //리스트 pool에 Add로 저장 
        }
        poolDict.Add(prefab.name, pool);
    }
    
    public GameObject Get(string key)
    {
        if (!poolDict.ContainsKey(key))
            return null;
        foreach (var dirctionary in poolDict)
        {
            for (int i = 0; poolDict[key].Count > i; i++)
            {
                if (!poolDict[key][i].activeInHierarchy)
                {
                    poolDict[key][i].SetActive(true);
                    return poolDict[key][i];
                }
            }
        }
        GameObject obj = Instantiate(prefab);
        poolDict[key].Add(obj);
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false); //게임 오브젝트 obj를 비활성화
    }
}

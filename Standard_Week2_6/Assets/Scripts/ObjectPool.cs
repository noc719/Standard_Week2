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
    public int PoolSize 
    {
        get { return poolSize; }

        set
        {
            if (poolSize < value) //입력 값이 poolSize 보다 크다면 그것을 poolSize로 사용
                poolSize = value;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++) //시작할 때 poolSize 만큼 prefab을 만들어 놓기위해 반복문
        {
            GameObject obj = Instantiate(prefab); //prefab을 생성한 후 obj 에 할당
            Release(obj); //비활성화하는 메서드
            pool.Add(obj); //리스트 pool에 Add로 저장 
        }
    }
    
    public GameObject Get()
    {
        for (int i =0; i < pool.Count; i++) //비활성화 된 것을 찾아 쓰기위해 조건문
        {
            if (!pool[i].activeInHierarchy) //만약 pool의 i번째가 비활성화라면(activeInHierarchy는 유니티 에디터 Hierarchy 창 상에서 활성화여부를 나타냄)
            {
                pool[i].SetActive(true); //비활성화된 개체를 활성화
                return pool[i]; //활성화하고나서 반환 (메서드 종료)
            }   
        }
        GameObject obj = Instantiate(prefab); // 조건 ,  비활성화 된 것이 없다면 새로 프리팹을 만들고 obj에 할당
        pool.Add(obj); //pool 리스트에 추가하고
        return obj; //그것을 반환 (메서드 종료)
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false); //게임 오브젝트 obj를 비활성화
    }
}
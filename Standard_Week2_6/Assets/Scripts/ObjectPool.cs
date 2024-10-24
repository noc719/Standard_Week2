using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ������Ʈ Ǯ���� �� ���ӿ�����Ʈ ������
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    private int poolSize = 300; // �ּ� 300�� �ݺ��� ������ ����
    private Dictionary<string, List<GameObject>> poolDict;
    public int PoolSize 
    {
        get { return poolSize; }

        set
        {
            if (poolSize < value) //�Է� ���� poolSize ���� ũ�ٸ� �װ��� poolSize�� ���
                poolSize = value;
        }
    }

    private void Awake()
    {
        poolDict = new Dictionary<string, List<GameObject>>();
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++) //������ �� poolSize ��ŭ prefab�� ����� �������� �ݺ���
        {
            GameObject obj = Instantiate(prefab); //prefab�� ������ �� obj �� �Ҵ�
            Release(obj); //��Ȱ��ȭ�ϴ� �޼���
            pool.Add(obj); //����Ʈ pool�� Add�� ���� 
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
        obj.SetActive(false); //���� ������Ʈ obj�� ��Ȱ��ȭ
    }
}

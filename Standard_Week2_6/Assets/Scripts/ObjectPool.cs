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
    public int PoolSize 
    {
        get { return poolSize; }

        set
        {
            if (poolSize < value) //�Է� ���� poolSize ���� ũ�ٸ� �װ��� poolSize�� ���
                poolSize = value;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++) //������ �� poolSize ��ŭ prefab�� ����� �������� �ݺ���
        {
            GameObject obj = Instantiate(prefab); //prefab�� ������ �� obj �� �Ҵ�
            Release(obj); //��Ȱ��ȭ�ϴ� �޼���
            pool.Add(obj); //����Ʈ pool�� Add�� ���� 
        }
    }
    
    public GameObject Get()
    {
        for (int i =0; i < pool.Count; i++) //��Ȱ��ȭ �� ���� ã�� �������� ���ǹ�
        {
            if (!pool[i].activeInHierarchy) //���� pool�� i��°�� ��Ȱ��ȭ���(activeInHierarchy�� ����Ƽ ������ Hierarchy â �󿡼� Ȱ��ȭ���θ� ��Ÿ��)
            {
                pool[i].SetActive(true); //��Ȱ��ȭ�� ��ü�� Ȱ��ȭ
                return pool[i]; //Ȱ��ȭ�ϰ��� ��ȯ (�޼��� ����)
            }   
        }
        GameObject obj = Instantiate(prefab); // ���� ,  ��Ȱ��ȭ �� ���� ���ٸ� ���� �������� ����� obj�� �Ҵ�
        pool.Add(obj); //pool ����Ʈ�� �߰��ϰ�
        return obj; //�װ��� ��ȯ (�޼��� ����)
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false); //���� ������Ʈ obj�� ��Ȱ��ȭ
    }
}
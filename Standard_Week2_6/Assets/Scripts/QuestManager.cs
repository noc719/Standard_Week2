using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance; // ���� �Ǿ��⿡ ���� �� �� null

    public static QuestManager Instance //������Ƽ ���� 
    {
        get    //Get�� �ܺο��� �ҷ��� ���� ���δ�. ���� �۵��ϴ� ������ �ܺο��� �ҷ��� ��
        {
            if (instance == null) //���� null �̶�� 
            {
                instance = FindObjectOfType<QuestManager>(); // FindObjectOfType ���� QuestManager Ÿ���� ��ü�� ã�� instance�� �����غ�

                if (instance == null)  //�׷����� null �̶��
                {
                    GameObject obj = new GameObject(nameof(QuestManager));
                    //GameObject obj��� ��ü�� ����� new Ű���带 ����Ͽ� �̸��� QuestManager�� �ν��Ͻ��� ������ �� obj�� �����Ͽ� �ִ´�.
                    instance = obj.AddComponent<QuestManager>(); //obj�� AddComponent �� QuestManager Ÿ���� �ο��ϰ� �װ��� �ν��Ͻ��� ����
                }
            }
            return instance; // �ܺη� ��ȯ��Ŵ
        }
    }
    private void Awake()  //Awake�� ����Ǵ� ������ �̰��� ���� ����ǰų� ó�� �̰��� �ҷ����� ��
    {
        if (instance == null) // �ν��Ͻ��� null ���̶�� 
        {
            instance = this;   //�ν��Ͻ��� �� ���� ������Ʈ�� �ǰ� (Ŭ���� ��ü�� ���ӿ�����Ʈ�̱� ������)
        }
        else
        {
            Destroy(gameObject); //�̹� ���� �ִٸ� �ı��ȴ�. Awake�� ����Ǵ� ������ ������ �̰��� ���� ����� �� �ı��� ���̴�.
        }  //�ϴ� �ν��Ͻ��� �ϳ��� �δ� ������ ������ �Ͽ����� �´� �Ͱ���..
    }
}

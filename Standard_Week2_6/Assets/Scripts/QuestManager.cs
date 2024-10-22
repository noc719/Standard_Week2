using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance; // 선언만 되었기에 아직 빈값 즉 null

    public static QuestManager Instance //프로퍼티 설정 
    {
        get    //Get은 외부에서 불러올 때만 쓰인다. 따라서 작동하는 시점은 외부에서 불러올 때
        {
            if (instance == null) //만약 null 이라면 
            {
                instance = FindObjectOfType<QuestManager>(); // FindObjectOfType 으로 QuestManager 타입의 객체를 찾아 instance에 대입해봄

                if (instance == null)  //그럼에도 null 이라면
                {
                    GameObject obj = new GameObject(nameof(QuestManager));
                    //GameObject obj라는 객체를 만들고 new 키워드를 사용하여 이름이 QuestManager인 인스턴스를 생성한 후 obj에 대입하여 넣는다.
                    instance = obj.AddComponent<QuestManager>(); //obj에 AddComponent 로 QuestManager 타입을 부여하고 그것을 인스턴스에 대입
                }
            }
            return instance; // 외부로 반환시킴
        }
    }
    private void Awake()  //Awake가 실행되는 시점은 이것이 신이 변경되거나 처음 이것이 불러와질 때
    {
        if (instance == null) // 인스턴스가 null 값이라면 
        {
            instance = this;   //인스턴스는 이 게임 오브젝트가 되고 (클래스 자체도 게임오브젝트이기 때문에)
        }
        else
        {
            Destroy(gameObject); //이미 값이 있다면 파괴된다. Awake가 실행되는 시점을 이유로 이것은 씬이 변경될 때 파괴될 것이다.
        }  //일단 인스턴스를 하나만 두는 로직을 만들기로 하였으니 맞는 것같다..
    }
}

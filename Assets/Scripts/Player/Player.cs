using UnityEngine;


//플레이어 스크립트와 다른 오브젝트에 있는 스크립트의 경우 GetComponent를 통해 필요한 스크립트를 호출할 수 없다. 
// 플레이어 스크립트에 다른 스크립트들에서 상호작용이 있을만한 클래스들을 선언해 접근할 수 있도록 함. 

public class Player : MonoBehaviour
{
    public PlayerController Controller { get; private set;}

    
    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }
}



 
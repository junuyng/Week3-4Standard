using UnityEngine;


// UI 스크립트를 별도로 만들어 주는 이유(객체 지향적 관점)
// 예를 들어 UI를 관리해주는 주체가 Player 안에 있다면
// 1. Player에 관한 스크립트 데이터를 관리하는 것 외에도 UI를 관리하게 되므로  Player 스크립트가 단일 책임 원칙을 위반한다. 
// 2. 유지보수가 어려워진다.  특정 UI를 수정하고 싶을 때 Player안에 있다는 내용을 인지하지 못하면 찾느라 시간을 많이 소요하게 될 것이다.
// 또한, Player 스크립트의 주요 로직과 UI 로직이 묶여있는 경우에는 주요 로직 자체를 건드려야 하는 상황이 생길 수 있다. 

public class PauseUI : MonoBehaviour
{

    private GameObject pauseUI;
    
    private void Start()
    {
        pauseUI = transform.GetChild(0).gameObject;
        CharacterManager.Instance.player.Controller.OnPauseEvent +=ToggleUI ;
    }


    private void ToggleUI()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
    }
    
}
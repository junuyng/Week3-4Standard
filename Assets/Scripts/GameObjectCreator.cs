using UnityEngine;

public enum ObjectID
{
    CharacterManager,
    InGameUI,
    HealthConditionUI,
    ManaConditionUI,
    PauseUI
}


//리소스 폴더안에 프리펩을 넣어 놓고 ID값을 활용해서 가져온다.  리소스 폴더에서 폴더링을 하는 경우면 경로 자체를 enum형태로 만들고 조합해서 한다.  
//SO 하나로 원하는 오브젝트를 한번에 생성 해줘도 괜찮은지 ?  보편적으로는 SO가 1대1 대응 그리고 SO리스트를 관리하는 SO를 만들어서 관리해줌.
[CreateAssetMenu(fileName = "GameObjectCreatorSO", menuName = "ScriptableObjects/GameObjectCreatorSO")]
public class GameObjectCreatorSO : ScriptableObject
{
    public string objectName;
    public Transform objectPos;
    public ObjectID id; 
    
    
    public GameObject CreateGameObject()
    {
        GameObject newObject = new GameObject(objectName);  
        newObject.transform.position = objectPos.position;
        AddComponents(newObject);
        return newObject;
    }

    private void AddComponents(GameObject newObject)
    {
        switch (id)
        {
            case ObjectID.CharacterManager:
                newObject.name = "CharacterManager";
                newObject.AddComponent<CharacterManager>();
                break;
            case ObjectID.InGameUI:
                newObject.name = "InGameUI";
                 break;
            case ObjectID.HealthConditionUI:
                newObject.AddComponent<Condition>();
                newObject.transform.SetParent(GameObject.Find("InGameUI").transform);
                break;
            case ObjectID.ManaConditionUI:
                newObject.AddComponent<Condition>();
                newObject.transform.SetParent(GameObject.Find("InGameUI").transform);
                break;
            case ObjectID.PauseUI:
                newObject.AddComponent<PauseUI>();
                break;
        }
    }
}
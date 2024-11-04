# Week3-4Standard
 
## public class Equipment 
- **`EquipNew(ItemData data)` 메서드**:
    - ItemData로부터 `equipPrefab` 정보를 가져와 `equipParent`의 자식으로 `Instantiate` 한 뒤  생성된 객체에서 `Equip` 컴포넌트를 가져와 `curEquip`에 할당

- **`UnEquip()` 메서드**:
    - 현재 장착된 `curEquip`이 null이 아니면 `Destroy`를 통해 `curEquip` 객체를 파괴하고, `curEquip`을 `null`로 설정하여 장비 해제 상태로 만들어줌

- **`OnAttackInput(InputAction.CallbackContext context)` 메서드**:
    - **매핑된 키가 눌리면**: `context.phase`가 `Performed` or 'Started'인 경우 `curEquip.OnAttackInput()`을 호출하여 공격 로직을 실행
    - **매핑된 키가 떼지면**: `context.phase`가 `Canceled`인 경우 `curEquip.EndAttack()`을 호출하여 공격을 종료
    - **사용 조건**: `controller.canLook`이 `true`이고 `curEquip`이 `null`이 아닐 때만 키 입력을 처리

## public class EquipTool 
- **`OnAttackInput()` 메서드**:
    - OnAttackInput()를 통해 아이템 상태를 변경해 줍니다. 
    - 


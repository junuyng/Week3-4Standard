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
- **`OnAttackInput() 메서드`**
	- 플레이어의 컨디션 스크립트를 통해 스태미나 사용이 가능한지 판단 해줍니다.
	- 사용이 가능하다면 애니메이션 트리거를 설정해주고 공격간 딜레이를 주기 위해 OnCanAttack 메서드를 호출 해줍니다. 
 - **`OnCanAttack() 메서드`**
	 - 공격 중임을 확인하는 변수 attacking 값을 false로 처리 해줍니다.
- **`OnHit() 메서드`**
	- 카메라 중앙에서 ray를 attackDistance만큼 길이로 쏴 물체와 충돌을 판단 해줍니다.
	- 충돌한 물체가 resource를 가지고 있고 doesGatherResources가 true면 충돌한 물체의 resource 스크립트로부터 Gather를 호출해 자원을 캡니다.
	- 충돌한 물체가 damagable를 가지고 있고 doesDealDamage가 true면 충돌한 물체에서 정의된 IDamagable TakePhysicalDamage메서드를 호출 해 damage를 입힙니다.
	
- Gathering과 Combat 중 어떤 것을 위한 도구인지 판단을 위해 doesGatherResources과 doesDealDamage를 직렬화 해줘 인스펙터에서 설정하도록 합니다.

## public class Resource

- **`Gather(Vector3 hitPoint,Vector3 hitNormal) 메서드`**
	 - quantityPerHit와 capacy를 통해 자원을 얼마나 제공할지를 정해줍니다.
	 - Gather 메서드가 호출되면 quantityPerHit만큼의 자원을 생성해줍니다.  호출될 때 마다 capacy를 1만큼 감소 시켜 줍니다. capacy가 0보다 같거나 작아지면 자원 오브젝트를 삭제 해줍니다.


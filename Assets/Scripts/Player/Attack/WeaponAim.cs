using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public Transform weaponTransform; // 武器的 Transform 组件

    void Update()
    {
        AimWeaponAtMouse();
        AdjustWeaponFacing();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    void AimWeaponAtMouse()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Vector3 direction = mouseWorldPosition - weaponTransform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void AdjustWeaponFacing()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();

        if (mouseWorldPosition.x < weaponTransform.position.x)
        {
            weaponTransform.localScale = new Vector3(1, -1, 1); // 根据需要调整
        }
        else
        {
            weaponTransform.localScale = new Vector3(1, 1, 1); // 根据需要调整
        }
    }
}
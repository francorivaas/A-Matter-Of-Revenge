using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int weaponSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeaponSelected = weaponSelected;

        #region Inputs

        #region ScrollWheel Inputs

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSelected >= transform.childCount - 1)
                weaponSelected = 0;

            else weaponSelected++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSelected <= 0)
                weaponSelected = transform.childCount - 1;

            else weaponSelected--;
        }

        #endregion ScrollWheel Inputs

        #region AlphaInputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelected = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            weaponSelected = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            weaponSelected = 2;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            weaponSelected = 3;
        }

        #endregion Alpha Inputs

        #endregion Inputs

        if (previousWeaponSelected != weaponSelected)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == weaponSelected) 
                weapon.gameObject.SetActive(true);
            
            else 
                weapon.gameObject.SetActive(false);

            i++;

            
        }

        print(weaponSelected);
    }
}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public Shoot shoot;
    public SwordController Candle;
    public CrescentController Cres;
    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    [SerializeField] GameObject slot3;
    [SerializeField] GameObject slot4;
    [SerializeField] GameObject slot5;
    public Cooldown[] cool;
    public Button CrossBowButton;
    public Button SwordButton;
    public Button CrescentButton;
    public Button RodButton;
    public Button SunButton;
    public int currentWeapon = 0;

    void Awake()
    {
        // Attach the OnSwitchButtonClick method to the button click events
        CrossBowButton.onClick.AddListener(SwitchToCrossbow);
        SwordButton.onClick.AddListener(SwitchToSword);
        CrescentButton.onClick.AddListener(SwitchToCrescent);
        RodButton.onClick.AddListener(SwitchToRod);
        SunButton.onClick.AddListener(SwitchToSun);

        // Initially equip the first weapon
        SwitchToCrossbow(); // Assuming you want the CrossBow as the initial weapon
    }

    public void SwitchToCrossbow()
    {
        if (currentWeapon == 0)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 0;
        Equip1();
        shoot.isOnCooldown = false;
        cool[0].isCooldown = false;
        cool[0].Fill();

    }


    void SwitchToSword()
    {
        if (currentWeapon == 1)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 1;
        Equip2();
        Candle.canAttack = true;
        cool[1].isCooldown = false;
        cool[1].Fill();

    }

    void SwitchToCrescent()
    {
        if (currentWeapon == 2)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 2;
        Equip3();
        Cres.canAttack = true;
        cool[2].isCooldown = false;      
        cool[2].Fill();

    }

    void SwitchToRod()
    {
        if (currentWeapon == 3)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 3;
        Equip4();
        cool[3].isCooldown = false;
        cool[3].Fill();

    }

    void SwitchToSun()
    {
        if (currentWeapon == 4)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 4;
        Equip5();
        cool[4].isCooldown = false;
        cool[4].Fill();

    }

    void Equip1()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        shoot.SetCanShoot(true); // Allow shooting with this weapon
    }

    void Equip2()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        shoot.SetCanShoot(false); // Prevent shooting with this weapon
    }
    
    void Equip3()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(true);
        slot4.SetActive(false);
        slot5.SetActive(false);
        shoot.SetCanShoot(false);
    }

    void Equip4()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(true);
        slot5.SetActive(false);
        shoot.SetCanShoot(false);
    }

    void Equip5()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
        slot5.SetActive(true);
        shoot.SetCanShoot(false);
    }
}

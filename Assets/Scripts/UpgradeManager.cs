using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    //player:
    public PlayerControls player;
    public Rigidbody playerrb;
    //gameobjects & stuff:
    public Button Speedupg;
    public Button Speed2upg;
    public Button Speed3upg;

    public Button Agilityupg;
    public Button Liftupg2;
    public Button Liftupg3;

    public Button Fuelrefill;
    public Button Fuelupg2;
    public Button Fuelupg3;

    public Button OpenUpgMenu;
    public Button CloseUpgMenu;
    public Button OpenWepMenu;
    public Button CloseWepMenu;

    public Button ShortRangeMissile;
    public Button LongRangeMissile;
    public Button OldGun;
    
    public float totaldistance;
    public float luck;
    public string moneydisplay;
    public float money;
    public Text moneydis;
    public Text earnedmon;
    public string earnedmoneydisplay;
    
    //physical upgrades:
    public GameObject rocketbooster1;
    public GameObject rocketbooster2;
    public GameObject wingsupg;
    public GameObject AntiGrav;

    //bools:
    public bool firstspeedupg;
    public bool firstfuelupg;
    public bool firstflightupg;

    public bool wepmenu;
    public bool upgmenu;

    public bool speed1purchased;
    public bool speed2purchased;
    public bool speed3purchased;

    public bool fuel1purchased;
    public bool fuel2purchased;
    public bool fuel3purchased;

    public bool lift1purchased;
    public bool lift2purchased;
    public bool lift3purchased;

    public bool IR1purchased;
    public bool ARHpurchased;
    public bool Gun1purchased;

    void Start()
    {
        Speedupg.interactable = false;
        Agilityupg.interactable = false;
        Fuelrefill.interactable = false;

        Speedupg.gameObject.SetActive(false);
        Speed2upg.gameObject.SetActive(false);
        Speed3upg.gameObject.SetActive(false);

        Agilityupg.gameObject.SetActive(false);
        Liftupg2.gameObject.SetActive(false);
        Liftupg3.gameObject.SetActive(false);

        Fuelrefill.gameObject.SetActive(false);
        Fuelupg2.gameObject.SetActive(false);
        Fuelupg3.gameObject.SetActive(false);

        ShortRangeMissile.gameObject.SetActive(false);
        LongRangeMissile.gameObject.SetActive(false);
        OldGun.gameObject.SetActive(false);

        rocketbooster1.SetActive(false);
        rocketbooster2.SetActive(false);
        AntiGrav.SetActive(false);

        speed1purchased = false;
        speed2purchased = false;
        speed3purchased = false;

        fuel1purchased = false;
        fuel2purchased = false;
        fuel3purchased = false;

        lift1purchased = false;
        lift2purchased = false;
        lift3purchased = false;

        IR1purchased = false;
        ARHpurchased = false;
        Gun1purchased = false;

        wingsupg.gameObject.SetActive(false);
        //OpenUpgMenu.gameObject.SetActive(false);
       // OpenUpgMenu.interactable = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        moneydisplay = "money: " + player.money;
        moneydis.text = moneydisplay;
        earnedmon.text = earnedmoneydisplay;
        earnedmoneydisplay = "Earnings:" + player.earnedmoney;
        if (wepmenu == true)
        {
            if (player.gamestart == false && upgmenu == false)
            {
                ShortRangeMissile.gameObject.SetActive(true);
                LongRangeMissile.gameObject.SetActive(true);
                OldGun.gameObject.SetActive(true);
                OpenUpgMenu.gameObject.SetActive(false);
                CloseWepMenu.gameObject.SetActive(true);
            }
            else
            {
                OpenWepMenu.gameObject.SetActive(true);
                OpenUpgMenu.gameObject.SetActive(true);

                
            }
           
        }
        if (upgmenu == true)
        {
            
            if (player.gamestart == false)
            {
                UpdateUpgradeButtons();

                Speedupg.gameObject.SetActive(true);
                Agilityupg.gameObject.SetActive(true);
                Fuelrefill.gameObject.SetActive(true);
                if (speed1purchased == true)
                {
                    Speed2upg.gameObject.SetActive(true);
                }
                if (fuel1purchased == true)
                {
                    Fuelupg2.gameObject.SetActive(true);
                }
                if (lift1purchased == true)
                {
                    Liftupg2.gameObject.SetActive(true);
                }
                if (lift2purchased == true)
                {
                    Liftupg3.gameObject.SetActive(true);
                }
                
                CloseUpgMenu.gameObject.SetActive(true);
                OpenUpgMenu.gameObject.SetActive(false);
                OpenWepMenu.gameObject.SetActive(false) ;
                CloseWepMenu.gameObject.SetActive(false);
            } else
            {

                CloseUpgMenu.gameObject.SetActive(false);
                OpenUpgMenu.gameObject.SetActive(false); 
                OpenWepMenu.gameObject.SetActive(true);
                CloseWepMenu.gameObject.SetActive(false);
            }
            
        }
        else 
        {
            if (player.gamestart == false){
                Speedupg.gameObject.SetActive(false);
                Speed2upg.gameObject.SetActive(false);
                Speed3upg.gameObject.SetActive(false);
                Agilityupg.gameObject.SetActive(false);
                Liftupg2.gameObject.SetActive(false);
                Liftupg3.gameObject.SetActive(false);
                Fuelrefill.gameObject.SetActive(false);
                Fuelupg2.gameObject.SetActive(false);
                Fuelupg3.gameObject.SetActive(false);
                OpenUpgMenu.gameObject.SetActive(true);
                CloseUpgMenu.gameObject.SetActive(false); 
                OpenWepMenu.gameObject.SetActive(true);
                CloseWepMenu.gameObject.SetActive(false);
            } else
            {
                OpenUpgMenu.gameObject.SetActive(false) ;
                CloseUpgMenu.gameObject.SetActive(false);
                OpenWepMenu.gameObject.SetActive(false);
                CloseWepMenu.gameObject.SetActive(false);
                Speed2upg.gameObject.SetActive(false);
                Speed3upg.gameObject.SetActive(false);
                Speedupg.gameObject.SetActive(false);
                Agilityupg.gameObject.SetActive(false);
                Fuelrefill.gameObject.SetActive(false);
                Fuelupg2.gameObject.SetActive(false);
                Fuelupg3.gameObject.SetActive(false);
                Liftupg2.gameObject.SetActive(false);
                Liftupg3.gameObject.SetActive(false);
            }

            
            
        }
    }
  
    
    

    public void SpeedUpg2()
    {
        
        if (player.money >= 1000)
        {
            rocketbooster1.SetActive(true);
            rocketbooster2.SetActive(true);
            player.maxspeed = player.maxspeed + 50;
            player.money = player.money - 1000;
            Speed2upg.interactable = false;
            speed2purchased = true;
        }
        
        
    }
    public void SpeedUpg1()
    {
        if (player.money >= 300)
        {
            player.maxspeed = player.maxspeed + 10;
            player.money = player.money - 300;
            Speedupg.interactable = false;
            speed1purchased = true;

        }
    }
    public void SpeedUpg3()
    {

    }
     
    public void fuelupg1()
    {
        
        if (player.money >= 600)
        {
            player.maxfuel = player.maxfuel + 25;
            player.money = player.money - 600;
            Fuelrefill.interactable = false;
            fuel1purchased = true;
        }
    }
    public void fuelupg2()
    {
        if (player.money >= 1000)
        {
            player.maxfuel = player.maxfuel + 75;
            player.money = player.money - 1000;
            Fuelupg2.interactable = false;
            fuel2purchased = true;
        }

    }
    public void fuelupg3()
    {

    }
    public void LiftUpg1()
    {
        if (player.money >= 300)
        {
            player.upgdrag = 5;
            player.money = player.money - 300;
            lift1purchased = true;
            
        }
    }
    public void LiftUpg2()
    {
        if (player.money >= 750)
        {
            player.upgdrag = 7;
            player.money = player.money - 750;
            lift2purchased = true;
            Liftupg2.interactable = false;
            wingsupg.gameObject.SetActive(true);
        }
    }
    public void LiftUpg3()
    {
        if (player.money >= 5000)
        {
            player.money = player.money - 5000;
            playerrb.useGravity = false;
            lift3purchased = true;
            Liftupg3.interactable = true;
            AntiGrav.gameObject.SetActive(true);
        }
    }
    public void Infared1()
    {
       
    }
    public void ARH1()
    {

    }

    public void GUN1()
    {

    }

    public void openupgrademenu()
    {
        upgmenu = true;
        wepmenu = false;
    }
    public void closeupgrademenu()
    {
        upgmenu = false;
        OpenWepMenu.gameObject.SetActive(true);
    }
    public void openweaponmenu()
    {
        wepmenu = true;
        upgmenu = false;
    }
    public void closeweaponmenu()
    {
        wepmenu = false;
        upgmenu = true;
    }
    void UpdateUpgradeButtons()
    {
        ShortRangeMissile.interactable = !IR1purchased && player.money >= 3000;
        LongRangeMissile.interactable = !ARHpurchased && player.money >= 10000;
        Speedupg.interactable = !speed1purchased && player.money >= 300;
        Speed2upg.interactable = !speed2purchased && player.money >= 1000;
        
        Fuelrefill.interactable = !fuel1purchased && player.money >= 600;
        Fuelupg2.interactable = !fuel2purchased && player.money >= 1000;
        Agilityupg.interactable = !lift1purchased && player.money >= 300;
        Liftupg2.interactable = !lift2purchased && player.money >= 750;
        Liftupg3.interactable = !lift3purchased && player.money >= 5000;
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaQueen : UnitMgr
{
    public GameObject flower;
    private Vector3 rightPlace;
    public bool isActive = false;
    public enum WHERE
    {
        TOWN, PLANTA_HOUSE, PUZZLE

    }

    public WHERE place;
    protected override void Awake()
    {
        base.Awake();
        if (place == WHERE.PLANTA_HOUSE)
            rightPlace = flower.transform.position;
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        switch (place)
        {
            case WHERE.TOWN:
                {
                    if (isCol)
                    {
                        Stare();
                    }
                    else transform.rotation = startRotation;
                }

                break;
            case WHERE.PLANTA_HOUSE:
                {
                    if (isCol)
                    {
                        MoveFlower();
                    }
                }
                break;
            case WHERE.PUZZLE:
                break;
        }

    }


    public void MoveFlower()
    {

    }
}

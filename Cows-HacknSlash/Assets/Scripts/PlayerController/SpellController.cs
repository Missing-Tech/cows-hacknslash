﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{

    [SerializeField]
    private GameObject SpawnPos;

    [Header("FireBall")]
    [SerializeField]
    private GameObject FireBall;
    public GameObject selectedText;

    [SerializeField]
    private GameObject ice;
    [SerializeField]
    private GameObject poison;
    [Tooltip("0 == null; 1 == FireStaff")]
    [SerializeField]
    private int StaffSelected;
    public float cooldownPeriod = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StaffSelected = 1;
            selectedText.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StaffSelected = 0;
            selectedText.SetActive(false);
        }
        if (StaffSelected == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && FireBall.GetComponent<SpellInitialise>().spell.timeStamp <= Time.time)
            {
                FireBall.GetComponent<SpellInitialise>().spell.timeStamp = Time.time + FireBall.GetComponent<SpellInitialise>().spell.cooldownPeriod;
                var projectile = Instantiate(FireBall, SpawnPos.transform.position, Quaternion.identity);
                SpawnPos.GetComponent<FireTest>().Shoot(projectile.transform, true);
                Destroy(projectile.gameObject, 5f);
            }
            else if (Input.GetKeyDown(KeyCode.R) && ice.GetComponent<SpellInitialise>().spell.timeStamp <= Time.time)
            {
                ice.GetComponent<SpellInitialise>().spell.timeStamp = Time.time + ice.GetComponent<SpellInitialise>().spell.cooldownPeriod;
                var projectile = Instantiate(ice, SpawnPos.transform.position, Quaternion.identity);
                SpawnPos.GetComponent<FireTest>().Shoot(projectile.transform, true);
                Destroy(projectile.gameObject, 5f);
            }
            else if (Input.GetKeyDown(KeyCode.T) && poison.GetComponent<SpellInitialise>().spell.timeStamp <= Time.time)
            {
                poison.GetComponent<SpellInitialise>().spell.timeStamp = Time.time + poison.GetComponent<SpellInitialise>().spell.cooldownPeriod;
                var projectile = Instantiate(poison, SpawnPos.transform.position, Quaternion.identity);
                SpawnPos.GetComponent<FireTest>().Shoot(projectile.transform, true);
                Destroy(projectile.gameObject, 5f);
            }
        }


    }
}
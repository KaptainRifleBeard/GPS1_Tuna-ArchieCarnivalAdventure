using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healthSystemB : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnDead;

    private List<Heart> heartList;

    public healthSystemB(int hA) // heart amount
    {
        heartList = new List<Heart>();
        for (int i = 0; i < hA; i++)
        {
            Heart heart = new Heart(2); // 1 heart can tahan how many damage
            heartList.Add(heart);
        }
    }

    public List<Heart> GetHeartList()
    {
        return heartList;
    }

    public void Damage(int da) // damage amount
    {
        for (int i = heartList.Count - 1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            if (da > heart.GetFragmentAmount()) // Test if this heart can absorb damageAmount
            {
                da -= heart.GetFragmentAmount();// Heart cannot absorb full damageAmount, damage heart and keep going to next heart
                heart.Damage(heart.GetFragmentAmount());
            }
            else
            {
                heart.Damage(da);
                break;
            }
        }
        OnDamaged(this, EventArgs.Empty);
        if (IsDead())
        {
            OnDead(this, EventArgs.Empty);
        }
    }

    public bool IsDead()
    {
        return heartList[0].GetFragmentAmount() == 0;
    }

    public class Heart
    {
        private int fragments;

        public Heart(int fm)
        {
            fragments = fm;
        }
        public int GetFragmentAmount()
        {
            return fragments;
        }
        public void Damage(int da)// damage amount
        {
            if (da >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= da;
            }
        }
    }




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIA.nsHeroController
{
    public class AttackBehaviour : MonoBehaviour
    {
        [HideInInspector] public HeroController cc;

        protected virtual void Start()
        {
            InitilizeController();
        }

        protected virtual void Update()
        {
            
        }

        protected virtual void InitilizeController()
        {
            cc = GetComponent<HeroController>();

            if (cc != null)
                cc.Init();
        }
    }
}

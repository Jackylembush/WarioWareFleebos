﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fleebos
{
    namespace BananaStrip
    {
        public class PeelBehaviour : TimedBehaviour
        {

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            public void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Enemy2"))
                {
                    switch (currentDifficulty)
                    {
                        case Difficulty.EASY:
                            GameManagerBanana.gm.PeelEASY();
                            break;
                        case Difficulty.MEDIUM:
                            GameManagerBanana.gm.PeelMEDIUM();
                            break;
                        case Difficulty.HARD:
                            GameManagerBanana.gm.PeelHARD();
                            break;
                    }
                }
            }
        }
    }
}
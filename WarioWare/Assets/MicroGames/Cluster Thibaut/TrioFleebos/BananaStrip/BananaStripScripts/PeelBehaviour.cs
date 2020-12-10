using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fleebos
{
    namespace BananaStrip
    {
        public class PeelBehaviour : TimedBehaviour
        {
            public HandMovement hand;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            public void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Enemy2"))
                {
                    hand.Peel();
                }
            }
        }
    }
}
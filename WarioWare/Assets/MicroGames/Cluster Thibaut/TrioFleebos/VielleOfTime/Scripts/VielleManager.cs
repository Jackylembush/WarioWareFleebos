using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fleebos
{
    namespace VielleOfTime
    {
        /// <summary>
        /// Arthur SPELLANI
        /// </summary>
        
        public class VielleManager : TimedBehaviour
        {
            Vector2 joystickRotation;
            Vector2 currentJoystickRotation;

            public Image turnSignal;

            [HideInInspector] public bool turnActivation = false;


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                joystickRotation = new Vector2(1,1);
                turnSignal.color = Color.red;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                currentJoystickRotation = new Vector2(Input.GetAxis("Left_Joystick_X"), Input.GetAxis("Left_Joystick_Y"));

                if (turnSignal.fillAmount > 0)
                {
                    turnSignal.fillAmount -= Time.deltaTime / 2;
                }      
                
                if(turnSignal.fillAmount > 0.85f && turnActivation == false)
                {
                    TurnIsOn();
                }
                if (turnSignal.fillAmount < 0.85f && turnActivation == true)
                {
                    TurnIsOff();
                }

                if (Vector2.Angle(currentJoystickRotation, joystickRotation) > 45 && Vector2.Angle(currentJoystickRotation, joystickRotation) < 100)
                {
                    turnSignal.fillAmount += 0.1f;
                    joystickRotation = currentJoystickRotation;
                }


            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            public void TurnIsOn()
            {
                turnActivation = true;
                turnSignal.color = Color.green;
            }

            public void TurnIsOff()
            {
                turnActivation = false;
                turnSignal.color = Color.red;
            }
        }
    }
}
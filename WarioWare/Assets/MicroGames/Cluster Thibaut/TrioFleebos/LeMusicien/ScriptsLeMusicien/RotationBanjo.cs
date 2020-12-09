using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace Fleebos
{
    namespace LeMusicien
    {
        public class RotationBanjo : TimedBehaviour
        {
            public List<float> rotations;
            public bool rightTriggerPressed;
            public bool leftTriggerPressed;
            public float rotationValue;
            public float rotationPositions;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        rotationValue = 90f;
                        rotationPositions = 360f/rotationValue;
                        break;
                    case Manager.Difficulty.MEDIUM:
                        rotationValue = 60f;
                        rotationPositions = 360f / rotationValue;
                        break;
                    case Manager.Difficulty.HARD:
                        rotationValue = 45f;
                        rotationPositions = 360f / rotationValue;
                        break;
                }

                for (int i = 0; i < rotationPositions; i++)
                {
                    rotations.Add(rotationValue * i);
                }

                int rand = Random.Range(1, rotations.Count);
                transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
            }


            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            if (Tick < 8 && rightTriggerPressed == false && Input.GetAxis("Right_Trigger") == 1f)
            {
                transform.Rotate(new Vector3(0, 0, -rotationValue));
                rightTriggerPressed = true;
            }
                if (Input.GetAxis("Right_Trigger") == 0f)
                {
                    rightTriggerPressed = false;
                }

            if (Tick < 8 && leftTriggerPressed == false && Input.GetAxis("Left_Trigger") == 1f)
            {
                 transform.Rotate(new Vector3(0, 0, rotationValue));
                 leftTriggerPressed = true;
            }
                if (Input.GetAxis("Left_Trigger") == 0f)
                {
                    leftTriggerPressed = false;
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick == 8)
                {
                    if( transform.rotation.z == 0f)
                    {
                        Debug.Log("win");
                        Manager.Instance.Result(true);
                    }
                    if (transform.rotation.z < 0f || transform.rotation.z > 0f)
                    {
                        Debug.Log("loose");
                        Manager.Instance.Result(false);
                    }

                }
            }
        }
    }
}
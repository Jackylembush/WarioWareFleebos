using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fleebos
{
    namespace BananaStrip
    {
        /// <summary>
        /// Job Corentin
        /// </summary>
        public class HandMovement : TimedBehaviour
        {
            float timeCounter;
            public float speed, height, width, triggerValue;

            public Transform centerPoint;
            Rigidbody2D rb;

            public float rayCastDist;
            public GameObject pinchPoint;
            public LineRenderer line;
            public override void Start()
            {
                base.Start(); //Do not erase this line!
                rb = gameObject.GetComponent<Rigidbody2D>();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                #region Movement
                if (Input.GetAxis("Right_Trigger") >= 0.5f)
                {
                    triggerValue = 1f;
                }
                else if (Input.GetAxis("Left_Trigger") >= 0.5f)
                {
                    triggerValue = -1f;
                }
                else
                {
                    triggerValue = 0;
                }

                //Set Time counter according to triggerValue
                if(triggerValue == 1)
                {
                    timeCounter += Time.deltaTime * speed;
                }
                else if (triggerValue == -1)
                {
                    timeCounter -= Time.deltaTime * speed;
                }

                float x = Mathf.Cos(timeCounter) * width;
                float y = Mathf.Sin(timeCounter) * height;

                transform.position = new Vector2(x, y);
                #endregion

                #region rotation

                Vector2 lookDir = centerPoint.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                #endregion

                Checking();
                Line();
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            public void Checking()
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,rayCastDist);

                if(hit.collider != null)
                {
                    if (hit.collider.CompareTag("Enemy1"))
                    {
                        GameObject bananaPeel = hit.collider.gameObject;

                        bananaPeel.transform.position = pinchPoint.transform.position;
                    }
                }
            }

            public void Line()
            {
                line.SetPosition(0, pinchPoint.transform.position);
                line.SetPosition(1, transform.position);
            }
        }
    }
}
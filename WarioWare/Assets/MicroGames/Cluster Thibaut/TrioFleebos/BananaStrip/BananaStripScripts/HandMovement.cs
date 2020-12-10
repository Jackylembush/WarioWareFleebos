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
            bool pinched;

            public Transform centerPoint;
            Rigidbody2D rb;

            public float rayCastDist;
            public Transform pinchPoint;
            public Transform linePoint,linePoint2;
            public LineRenderer line;
            public GameObject box;

            public Animator bananaAnimator;
            int peelCounter = 0;
            public override void Start()
            {
                base.Start(); //Do not erase this line!
                rb = gameObject.GetComponent<Rigidbody2D>();
                lineStartSetup();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                #region rotation

                Vector2 lookDir = centerPoint.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                #endregion

                Movement();
                if (pinched == false)
                {
                    Checking();
                }

                if(pinched == true)
                {
                    Line();
                    MoveCollider();
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            public void Movement()
            {
                if (Input.GetAxis("Right_Trigger") >= 0.5f)
                {
                    triggerValue = -1f;
                }
                else if (Input.GetAxis("Left_Trigger") >= 0.5f && pinched == false)
                {
                    triggerValue = 1f;
                }
                else
                {
                    triggerValue = 0;
                }

                //Set Time counter according to triggerValue
                if (triggerValue == 1)
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
            }

            public void Checking()
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,rayCastDist);

                if(hit.collider != null)
                {
                    if (hit.collider.CompareTag("Enemy1"))
                    {
                        pinched = true;
                        box = hit.collider.gameObject;
                    }
                }
            }

            public void Line()
            {
                line.SetPosition(0, pinchPoint.transform.position);
                line.SetPosition(1, linePoint.transform.position);
            }

            public void MoveCollider()
            {
                box.transform.position = pinchPoint.transform.position;
            }
            public void lineStartSetup()
            {
                line.SetPosition(0, linePoint2.transform.position);
                line.SetPosition(1, linePoint.transform.position);
            }

            public void Peel()
            {
                peelCounter += 1;
                bananaAnimator.SetTrigger("Peel");
            }
        }
    }
}
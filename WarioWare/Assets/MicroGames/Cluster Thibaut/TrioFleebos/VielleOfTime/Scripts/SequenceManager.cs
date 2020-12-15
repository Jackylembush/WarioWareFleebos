using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;
using UnityEngine.UI;

namespace Fleebos
{
    namespace VielleOfTime
    {
        /// <summary>
        /// Arthur SPELLANI
        /// </summary>

        public class SequenceManager : TimedBehaviour
        {
            public GameObject particleWin;

            public GameObject[] Inputs;
            public GameObject[] NotesUI;
            public List<GameObject> MusicNotes;
            
            int ListOfNotesLength;
            int Easy = 3;
            int Medium = 4;
            int Hard = 5;

            [HideInInspector] public int NoteOrder = 0;

            VielleManager VL;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                VL = GetComponent<VielleManager>();

                switch (currentDifficulty)
                {
                    case Manager.Difficulty.EASY:
                        ListOfNotesLength = Easy;
                        break;

                    case Manager.Difficulty.MEDIUM:
                        ListOfNotesLength = Medium;
                        break;

                    case Manager.Difficulty.HARD:
                        ListOfNotesLength = Hard;
                        break;
                }

                for (int i = 0; i < ListOfNotesLength; i++)
                {
                    MusicNotes.Add(Inputs[Random.Range(0, 4)]);
                }

                for (int i = 0; i < MusicNotes.Count; i++)
                {
                    Instantiate(MusicNotes[i], NotesUI[i].transform);
                }

            }

            private void Update()
            {
                if (VL.turnActivation == true && NoteOrder < MusicNotes.Count)
                {
                    if (Input.GetButtonDown("A_Button"))
                    {
                        if (MusicNotes[NoteOrder].name == "A_Button_Sequence")
                        {
                            PlayNote();
                        }
                    }
                    if (Input.GetButtonDown("B_Button"))
                    {
                        if (MusicNotes[NoteOrder].name == "B_Button_Sequence")
                        {
                            PlayNote();
                        }
                    }
                    if (Input.GetButtonDown("X_Button"))
                    {
                        if (MusicNotes[NoteOrder].name == "X_Button_Sequence")
                        {
                            PlayNote();
                        }
                    }
                    if (Input.GetButtonDown("Y_Button"))
                    {
                        if (MusicNotes[NoteOrder].name == "Y_Button_Sequence")
                        {
                            PlayNote();
                        }
                    }
                }
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

            public void PlayNote()
            {
                NotesUI[NoteOrder].GetComponent<AudioSource>().Play();
                Instantiate(particleWin, NotesUI[NoteOrder].transform);
                NotesUI[NoteOrder].GetComponentInChildren<Image>().color = Color.black;
                NoteOrder++;
            }
        }
    }
}
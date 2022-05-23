using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BorshClick : MonoBehaviour
    {
        private const string pathToValuesCanvas = "Canvas/ValuesCanvas";
        private const int stage1 = 0;
        private const int stage2 = 50;
        private const int stage3 = 100;
        private const int stage4 = 200;

        private ValuesCanvas valuesCanvas;

        void Start()
        {
            valuesCanvas = GameObject.Find(pathToValuesCanvas).GetComponent<Canvas>().GetComponent<ValuesCanvas>();
        }

        Vector3 touchPosWorld;
        
        TouchPhase touchPhase = TouchPhase.Began;
        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
            {
                touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (hitInformation.collider != null)
                {
                    GameObject touchedObject = hitInformation.transform.gameObject;

                    if (touchedObject.name.Equals("Square"))
                    {
                        valuesCanvas.AddMold(valuesCanvas.addMoldClickCount);
                    }
                }
            }
            CheckStage();
        }
        private void CheckStage()
        {
            if (valuesCanvas.moldCount >= stage1 && valuesCanvas.moldCount < stage2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            else if (valuesCanvas.moldCount >= stage2 && valuesCanvas.moldCount < stage3)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (valuesCanvas.moldCount >= stage3 && valuesCanvas.moldCount < stage4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            else if (valuesCanvas.moldCount >= stage4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }
}


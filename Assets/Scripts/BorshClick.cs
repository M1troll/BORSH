using UnityEngine;

namespace Assets.Scripts
{
    public class BorshClick : MonoBehaviour
    {
        private const string pathToValuesCanvas = "Canvas/ValuesCanvas";
        private const string borshName = "BORSH";
        private const int stage1 = 0;
        private const int stage2 = 500;
        private const int stage3 = 900;
        private const int stage4 = 1200;

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

                    if (touchedObject.name.Equals(borshName))
                    {
                        valuesCanvas.AddMold(GlobalData.addMoldClickCount);
                    }
                }
            }
            CheckStage();
        }
        private void CheckStage()
        {
            if (GlobalData.moldCount >= stage1 && GlobalData.moldCount < stage2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (GlobalData.moldCount >= stage2 && GlobalData.moldCount < stage3)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (GlobalData.moldCount >= stage3 && GlobalData.moldCount < stage4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            else if (GlobalData.moldCount >= stage4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}


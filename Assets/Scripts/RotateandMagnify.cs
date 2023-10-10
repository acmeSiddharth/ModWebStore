using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateandMagnify : MonoBehaviour
{
    private Vector3 InitPosn, InitRotn;
    private bool MagniTog,allowRot;
    private float _touchPointX, _touchPointY;

    // Start is called before the first frame update
    void Start()
    {
        InitPosn = this.gameObject.transform.position;
        InitRotn = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
      if (allowRot)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 TouchDeltaPos = Input.GetTouch(0).deltaPosition;
                transform.Rotate(0, -TouchDeltaPos.x * Time.deltaTime * 10, 0);
            }
        }
       
    }

    public void OnMouseDown()
    {
        if (!MagniTog)
        {
            allowRot = true;
            InitPosn = this.gameObject.transform.position;
            gameObject.transform.DOMove(new Vector3(0, 0, -8), 2);
            MagniTog = true;
        }
        else
        {
            // StartCoroutine(offMeg());
        }
    }
    IEnumerator offMeg()
    {
        yield return new WaitForSeconds(.2f);
        allowRot = false;
        gameObject.transform.DOMove(new Vector3(0, 0, 0), 1);
        MagniTog = false;
        gameObject.transform.Rotate(new Vector3(0, 0, 0));

    }
}
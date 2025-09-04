using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public LayerMask selectableLayers; //  ָ����ѡ��Ĳ㼶�������Ż����߼��
    private bool isSelecting = false; //  �Ƿ�����ѡ�����
    [SerializeField] private Animator animator;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���������
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayers))
            {
                GameObject selectedObject = hit.collider.gameObject;
                isSelecting=!isSelecting;

                //  ������ִ��ѡ����������������ʾ
                SelectObject(selectedObject);
            }
        }
    }

    void SelectObject(GameObject obj)
    {
      if(isSelecting)
        {
            animator.SetTrigger("open");
            Debug.Log(1);
        }
      else
        {
            animator.SetTrigger("close");
            Debug.Log(2);
        }
    }
}
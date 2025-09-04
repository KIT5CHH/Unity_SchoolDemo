using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public LayerMask selectableLayers; //  指定可选择的层级，用于优化射线检测
    private bool isSelecting = false; //  是否正在选择对象
    [SerializeField] private Animator animator;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键点击
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayers))
            {
                GameObject selectedObject = hit.collider.gameObject;
                isSelecting=!isSelecting;

                //  在这里执行选择操作，例如高亮显示
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
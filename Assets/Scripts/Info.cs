using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour {

    private Animator _animator;
    private CanvasGroup _canvasGroup;

    
    public bool isShown
    {
        get { return _animator.GetBool("isShown"); }
        set { _animator.SetBool("isShown", value); }
    }


    public void ChangeAlpha(float a)
    {
        _canvasGroup.alpha = a;
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();

        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

        _canvasGroup.alpha = 0;

    }
    
    public void Update()
    {
        // on update we check the state of the animator if current panel.
        // if it is NOT show then make it non visible non interactable
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Show"))
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
            //_canvasGroup.alpha = 0;
        } else
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
           // _canvasGroup.alpha = 1;
        }
    }
    
}

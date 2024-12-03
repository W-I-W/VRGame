using System.Collections;
using System.Collections.Specialized;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineView : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_CenterGround;
    [SerializeField] private GameObject m_Parent;
    [SerializeField] private LayerMask m_Layer;

    public int id { get; private set; } = -1;

    private Coroutine m_Coroutine;

    protected void Start()
    {
        m_Parent.SetActive(false);
    }

    public void Play(Transform tran)
    {
        id = tran.GetInstanceID();
        m_Parent.SetActive(true);
        m_Coroutine = StartCoroutine(SetPositionPoint(tran));
    }

    public void OnSelectExited()
    {
        id = -1;
        m_Parent.SetActive(false);
        StopCoroutine(m_Coroutine);
    }

    private IEnumerator SetPositionPoint(Transform tran)
    {
        while (true)
        {
            transform.localPosition = tran.localPosition + Vector3.down / 4f;
            RaycastHit hit;
            bool isTrigger = Physics.Raycast(tran.localPosition, Vector3.down, out hit, 10, m_Layer);
            if (isTrigger)
            {
                m_CenterGround.transform.position = hit.point + new Vector3(0, 0.01f, 0);
            }
            yield return null;
        }
    }
}

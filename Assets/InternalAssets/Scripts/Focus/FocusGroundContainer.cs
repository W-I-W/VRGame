using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FocusGroundContainer : MonoBehaviour
{
    [SerializeField] private LineView[] m_Lines;

    public void OnSelectEneable(SelectEnterEventArgs select)
    {
        for (int i = 0; i < m_Lines.Length; i++)
        {
            if (m_Lines[i].id == -1)
            {
                m_Lines[i].Play(select.interactableObject.transform);
                return;
            }
        }
    }

    public void OnSelectExited(SelectExitEventArgs select)
    {
        for (int i = 0; i < m_Lines.Length; i++)
        {
            int hash = select.interactableObject.transform.GetHashCode();
            if (m_Lines[i].id == hash)
            {
                m_Lines[i].OnSelectExited();
                return;
            }
        }
    }
}

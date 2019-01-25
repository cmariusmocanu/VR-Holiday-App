namespace GoogleVR.HelloVR
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Movement : MonoBehaviour
    {
        public GameObject playerpozition;
        public GameObject destination;
        public float speed;
        private Vector3 startingPosition;
        private Renderer myRenderer;

        public Material inactiveMaterial;
        public Material gazedAtMaterial;

        private bool active = false;

        void Start()
        {
            startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        }
                public void SetGazedAt(bool gazedAt)
        {
            active = gazedAt;
            if (inactiveMaterial != null && gazedAtMaterial != null)
            {
                myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
                return;
            }
        }

        public void Reset()
        {
            int sibIdx = transform.GetSiblingIndex();
            int numSibs = transform.parent.childCount;
            for (int i = 0; i < numSibs; i++)
            {
                GameObject sib = transform.parent.GetChild(i).gameObject;
                sib.transform.localPosition = startingPosition;
                sib.SetActive(i == sibIdx);
            }
        }

        public void Recenter()
        {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        public void TeleportRandomly()
        {
            /*var x = 2;
            transform.Translate(x, 0, 0);
            x = x + 2;
            SetGazedAt(false);
            */

            float step = speed * Time.deltaTime;
            while (playerpozition.transform.position != destination.transform.position)
            {
                playerpozition.transform.position = Vector3.MoveTowards(playerpozition.transform.position, destination.transform.position, step);
            }
        }
        void Update()
        {
            if (active == true)
            {
                Event e = Event.current;
                if (e.isKey)
                {
                    Debug.Log(active);
                    float step = speed * Time.deltaTime;
                    while (playerpozition.transform.position != destination.transform.position)
                    {
                        playerpozition.transform.position = Vector3.MoveTowards(playerpozition.transform.position, destination.transform.position, step);
                    }
                }
            }
        }
    }
}

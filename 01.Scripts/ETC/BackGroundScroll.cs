using UnityEngine;

public class SpriteOffset : MonoBehaviour
{
    [SerializeField] private float _parallaxOffset;

    private MeshRenderer _meshRenderer;
    private Material _backgroundMaterial;

    private float _currentScroll;
    
    private readonly int _offsetHash = Shader.PropertyToID("_Offset");

    private float _beforePosition;
    private Transform _mainCamTrm;

    private float _ratio = 0;

    private void Awake() 
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _backgroundMaterial = _meshRenderer.material;
        _currentScroll = 0;
        _ratio = 1f / _meshRenderer.bounds.size.x;
    }

    private void Start()
    {
        _mainCamTrm = Camera.main.transform;
        _beforePosition = _mainCamTrm.position.x;
    }

    void Update()
    {
        float delta = _mainCamTrm.position.x - _beforePosition;
        _beforePosition = _mainCamTrm.position.x;
        _currentScroll += delta * _parallaxOffset * _ratio;
        _backgroundMaterial.SetFloat(_offsetHash, _currentScroll);
    }
}

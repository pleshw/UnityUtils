using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.Pooling
{

  public class GameObjectPool : ObjectPool<GameObject>
  {
    public int poolSize;
    private List<GameObject> _using = new List<GameObject>();

    public GameObjectPool(GameObject model, int amountToPool) : base(model)
    {
      poolSize = amountToPool;
      for (int i = 0; i < amountToPool; i++)
      {
        InstantiateClone();
      }
    }

    public override GameObject Get()
    {
      if (_objects.TryPop(out GameObject item))
      {
        item.SetActive(true);
        _using.Add(item);
        return _using[_using.Count - 1];
      }
      InstantiateClone();
      return Get();
    }

    public void Recycle(GameObject obj)
    {
      Add(_using.Find(i => i == obj));
      _using.Remove(obj);
    }

    /// <summary>
    /// Adiciona um objeto a pool.
    /// Ao ser inserido na pool o objeto não poderá ser visto no jogo até que seja retirado.
    /// </summary>
    /// <param name="item"> Objeto que será adicionado a pool </param>
    protected override void Add(GameObject item)
    {
      item.SetActive(false);
      _objects.Push(item);
    }

    /// <summary>
    /// Cria um clone do objeto _model e então o adiciona a pool
    /// </summary>
    protected override void InstantiateClone()
    {
      var tmp = UnityEngine.Object.Instantiate(_model);
      Add(tmp);
    }

    /// <summary>
    /// Remove todos os objetos que não estão sendo usados e fazem exceder o tamanho
    /// da pool.
    /// </summary>
    public void Clean()
    {
      while (_objects.Count + _using.Count > poolSize)
      {
        _objects.TryPop(out GameObject item);
        UnityEngine.Object.Destroy(item);
      }
    }
  }
}

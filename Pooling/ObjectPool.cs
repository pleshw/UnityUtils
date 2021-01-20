using System;
using System.Collections.Concurrent;



namespace UnityUtils.Pooling
{

  public abstract class ObjectPool<T>
  {

    protected T _model;

    protected readonly ConcurrentStack<T> _objects;

    public ObjectPool(T model) => (_model, _objects) = (model, new ConcurrentStack<T>());



    /// <summary>
    ///     Essa função deve tentar remover um item da lista '_objects' e retorná-lo.
    ///     Caso não seja possível, deve instanciar um novo clone de _model na lista 
    ///     e retorná-lo.
    /// </summary>

    public abstract T Get();

    /// <summary>
    ///     Essa função deve instanciar e armazenar um objeto na lista '_objects'
    /// </summary>
    protected abstract void Add(T item);

    /// <summary>
    ///     Essa função deve instanciar e armazenar um objeto clone da variável
    ///    'model' na lista '_objects'
    /// </summary>
    protected abstract void InstantiateClone();
  }
}

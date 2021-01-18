
using Vector2 = UnityEngine.Vector2;
using Mathf = UnityEngine.Mathf;
using UnityUtils.Metrics;

namespace UnityUtils.Angles
{
  public static class Convertion
  {
    // Retorna em forma de indíce o ponto para qual esse vetor está apontando.
    // Considere que o angulo de 360º será dividido em fatias(slices). A função vai
    // retornar o indice para qual fatia esse vetor está apontando.
    // Esse indíce  vai em sentido anti-horário.
    public static int VectorToIndex(Vector2 inputVector, int slices)
    {
      // Calcula a distancia em graus entre os pontos cardeais
      float step = 360f / slices;
      // Calcula metade da distância entre duas fatias. Isso vai ser usado para
      // que a fatia que representa o norte esteja sempre alinhada com o centro
      // do circulo.
      float northOffset = step / 2;
      // Calculando o angulo formado entre ponto norte(Vector2.up) e o vetor de entrada
      float angle = Vector2.SignedAngle(Vector2.up, inputVector.normalized);
      // Adiciona o offset para que o ponto norte seja centralizado
      angle += northOffset;
      // Caso o angulo seja negativo, é transformado em positivo adicionando 360
      // O angulo retornado pela função SignedAngle é entre -180 e 180 graus.
      if (angle < 0)
      {
        angle += 360;
      }
      // Calcula e retorna quantas "fatias" esse angulo ocupa
      return Mathf.FloorToInt(angle / step);
    }


    public static Cardinal.Point VectorToCardinal(Vector2 inputVector)
    {
      var cardinalIndex = VectorToIndex(inputVector, 8);
      return Cardinal.GetPointByIndex(cardinalIndex);
    }
  }
}

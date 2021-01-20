
using Vector2 = UnityEngine.Vector2;
using Mathf = UnityEngine.Mathf;
using UnityUtils.Metrics;
using System.Linq;

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

    public static Position.Horizontal VectorToHorizontal(Vector2 inputVector)
    {
      var normalized = inputVector.normalized;

      if (normalized.x > 0)
      {
        return Position.Horizontal.RIGHT;
      }
      else if (normalized.x < 0)
      {
        return Position.Horizontal.LEFT;
      }
      else
      {
        return Position.Horizontal.NONE;
      }
    }



    public static Position.Position2D VectorToPosition2D(Vector2 inputVector)
    {
      var cardinalIndex = VectorToIndex(inputVector, 4);
      return Position.PositionByIndex(cardinalIndex);
    }

    public static Position.Position2D Cardinal4ToPosition2D(Cardinal.Points4 point)
    {
      var cardinalIndex = Cardinal.points4ByIndex.ToList().FindIndex(p => p == point);
      return Position.PositionByIndex(cardinalIndex);
    }

    public static Cardinal.Points4 VectorToCardinal4(Vector2 inputVector)
    {
      var cardinalIndex = VectorToIndex(inputVector, 4);
      return Cardinal.Cardinal4ByIndex(cardinalIndex);
    }

    public static Cardinal.Points8 VectorToCardinal8(Vector2 inputVector)
    {
      var cardinalIndex = VectorToIndex(inputVector, 8);
      return Cardinal.Cardinal8ByIndex(cardinalIndex);
    }

    public static Position.Direction2D VectorToDirection2D(Vector2 inputVector)
    {
      var cardinalIndex = VectorToIndex(inputVector, 8);
      var result = new Position.Direction2D { horizontal = Position.Horizontal.NONE, vertical = Position.Vertical.NONE };
      if (cardinalIndex == 2)
      {
        result.horizontal = Position.Horizontal.LEFT;
        return result;
      }

      if (cardinalIndex == 6)
      {
        result.horizontal = Position.Horizontal.RIGHT;
        return result;
      }

      if (cardinalIndex == 0 || cardinalIndex == 1 || cardinalIndex == 7)
      {
        result.vertical = Position.Vertical.TOP;
        if (cardinalIndex == 1)
          result.horizontal = Position.Horizontal.LEFT;
        if (cardinalIndex == 7)
          result.horizontal = Position.Horizontal.RIGHT;
        return result;
      }

      if (cardinalIndex == 3 || cardinalIndex == 4 || cardinalIndex == 5)
      {
        result.vertical = Position.Vertical.BOTTOM;
        if (cardinalIndex == 3)
          result.horizontal = Position.Horizontal.LEFT;
        if (cardinalIndex == 5)
          result.horizontal = Position.Horizontal.RIGHT;
        return result;
      }

      return result;
    }
  }
}

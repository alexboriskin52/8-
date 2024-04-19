using System;

// Интерфейс для шахматных фигур
public interface IChessPiece
{
    void SecondName();
    void Properties();
}

// Базовый абстрактный класс "Шахматная фигура"
public abstract class ChessPiece : IChessPiece
{
    public string EnglishName { get; set; }
    public string RussianName { get; set; }

    // Конструктор
    public ChessPiece(string englishName)
    {
        EnglishName = englishName;
    }

    // Абстрактный метод, который должен быть реализован в подклассах
    public abstract void Properties();

    // Виртуальный метод для второго русскоязычного названия фигуры
    public virtual void SecondName()
    {
        Console.WriteLine($"Второе название: {RussianName}");
    }
}

// Абстрактный класс "Легкая фигура", наследуется от "Шахматная фигура"
public abstract class LightPiece : ChessPiece
{
    // Конструктор
    public LightPiece(string englishName, string russianName) : base(englishName)
    {
        RussianName = russianName;
    }
}

// Абстрактный класс "Тяжелая фигура", наследуется от "Шахматная фигура"
public abstract class HeavyPiece : ChessPiece
{
    // Конструктор
    public HeavyPiece(string englishName, string russianName) : base(englishName)
    {
        RussianName = russianName;
    }
}

// Класс "Pawn" (Пешка), наследуется от "LightPiece" (Легкая фигура)
public class Pawn : LightPiece
{
    // Конструктор
    public Pawn() : base("Pawn", "") { }

    // Реализация метода Properties() для пешки
    public override void Properties()
    {
        Console.WriteLine("Свойства: шаг/два вперед, рубить влево/вправо");
    }
}

// Класс "King" (Король), наследуется от "HeavyPiece" (Тяжелая фигура)
public class King : HeavyPiece
{
    // Конструктор
    public King() : base("King", "")
    {
    }

    // Реализация метода Properties() для короля
    public override void Properties()
    {
        Console.WriteLine("Свойства: ходит вокруг себя на 1, рубит также");
    }
}

// Класс "Bishop" (Слон), наследуется от "LightPiece" (Легкая фигура)
public class Bishop : LightPiece
{
    // Конструктор
    public Bishop() : base("Bishop", "")
    {
    }

    // Реализация метода Properties() для слона
    public override void Properties()
    {
        Console.WriteLine("Свойства: ходит по диагонали, рубит также");
    }
}

// Класс "Rook" (Ладья), наследуется от "HeavyPiece" (Тяжелая фигура)
public class Rook : HeavyPiece
{
    // Конструктор
    public Rook() : base("Rook", "")
    {
    }

    // Реализация метода Properties() для ладьи
    public override void Properties()
    {
        Console.WriteLine("Свойства: ходит попрямой/вправо/влево/назад, рубит также по всей площади");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем массив для хранения объектов различных фигур
        ChessPiece[] pieces = new ChessPiece[4];
        pieces[0] = new Pawn();
        pieces[1] = new King();
        pieces[2] = new Bishop();
        pieces[3] = new Rook();

        // Вводим второе название с клавиатуры для каждой фигуры
        foreach (var piece in pieces)
        {
            Console.Write($"Введите второе название для фигуры \"{piece.EnglishName}\": ");
            piece.RussianName = Console.ReadLine();
        }

        // Обходим каждый элемент массива
        foreach (var piece in pieces)
        {
            // Выводим свойства фигуры
            Console.WriteLine($"Первое название: {piece.EnglishName}");
            
            piece.SecondName();

            piece.Properties();

            // Пустая строка для отделения информации о каждой фигуре
            Console.WriteLine();
        }
    }
}

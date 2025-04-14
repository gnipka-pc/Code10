using System.Runtime.InteropServices.Swift;
using System.Security.Cryptography;

// public delegate void MessageHandler();

// public class Publisher
// {
//     public event MessageHandler MessageSent;

//     public void SendMessage()
//     {
//         System.Console.WriteLine("Сообщение отправлено");
//         MessageSent?.Invoke();
//     }
// }

// public class Subscriber
// {
//     public void OnMessage()
//     {
//         System.Console.WriteLine("Подписчик получил сообщение");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Publisher publisher = new Publisher();
//         Subscriber subscriber = new Subscriber();

//         publisher.MessageSent += subscriber.OnMessage; // подписка на событие

//         publisher.SendMessage();
//     }
// }
     

public delegate void ClickHandler();

public class Button
{
    public ClickHandler OnClick;

    public void Click()
    {
        System.Console.WriteLine("Кнопка нажата");
        OnClick?.Invoke();
    }
}

public class Window
{
    public void ShowWindow()
    {
        System.Console.WriteLine("|-------|");
        System.Console.WriteLine("|   OK  |");
        System.Console.WriteLine("|       |");
        System.Console.WriteLine("|-------|");
    }
}

class Program
{
    static void Main()
    {
        Button button = new Button();
        Window window = new Window();

        button.OnClick += window.ShowWindow;

        button.Click();
    }
}
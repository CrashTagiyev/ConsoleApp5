using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}

public class WhatsAppGroup : ISubject
{
    private List<IObserver> observers;

    public WhatsAppGroup()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void SendMessage(string message)
    {
        NotifyObservers(message);
    }
}

public class User : IObserver
{
    public string name;

    public User(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} received a new message: {message}");
    }
}


public class Program
{
    public static void Main()
    {
        // Wharsapp group
        WhatsAppGroup FBMS_2_22_3_az = new ();

        // Userler
        User user1 = new User("Elgun");
        User user2 = new User("Nurlan");
        User user3 = new User("Emil");

        // Group(observer)-a qowuruq userleri
        FBMS_2_22_3_az.RegisterObserver(user1);
        FBMS_2_22_3_az.RegisterObserver(user2);
        FBMS_2_22_3_az.RegisterObserver(user3);

        // Ve qrupdaki herkese(gonderene bele) mesaj gedir
        FBMS_2_22_3_az.SendMessage($"{user1.name};Sabah derse gelemmiyecem");

 
    }
}

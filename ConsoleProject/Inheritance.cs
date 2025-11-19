using System;

interface ICamera
{
    void CapturePhoto();
}

interface IMusicPlayer
{
    void PlayMusic();
}


class Device
{
    public string Brand;

    public Device(string brand)
    {
        Brand = brand;
        Console.WriteLine($"Device Constructor: {brand} device initialized.");
    }

    public void PowerOn()
    {
        Console.WriteLine("Device is powered ON.");
    }
}

class SmartPhone : Device, ICamera, IMusicPlayer
{
    public string Model;

    
    public SmartPhone(string brand, string model) : base(brand)
    {
        Model = model;
        Console.WriteLine($"SmartPhone Constructor: {Brand} {Model} is ready to use!");
    }

    
    public void CapturePhoto()
    {
        Console.WriteLine($"{Brand} {Model} is capturing a photo 📸");
    }

    public void PlayMusic()
    {
        Console.WriteLine($"{Brand} {Model} is playing music 🎵");
    }
}


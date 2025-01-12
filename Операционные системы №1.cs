﻿using System;
using System;
using System.IO;
using System.Text;

string path = @"D:5.txt";
FileStream fs = File.Create(path);
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
    Console.WriteLine("Имя файла: {0}", fileInf.Name);
    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
    Console.WriteLine("Размер: {0}", fileInf.Length);
}
Console.WriteLine("Введите строку\n");
string text = Console.ReadLine();
fs.Close();
using (FileStream file = new FileStream($"{path}", FileMode.Open))
{
    byte[] str = System.Text.Encoding.Default.GetBytes(text);
    file.Write(str, 0, str.Length);
    Console.WriteLine("Текст записан");
    file.Close();
}
Thread.Sleep(200);
using (FileStream filestream = new FileStream($"{path}", FileMode.Open))
{
    byte[] str = new byte[filestream.Length];
    filestream.Read(str, 0, str.Length);
    string textfromF = System.Text.Encoding.Default.GetString(str);
    Console.WriteLine($"Текст из файла:{textfromF}");
    filestream.Close();
}
fs.Close();
fileInf.Delete();



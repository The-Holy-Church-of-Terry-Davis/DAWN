﻿using Dawn.Types;
using Dawn.Server;
using Dawn.Colors;
using Newtonsoft.Json;

namespace Dawn;

class Program
{
    private static string whitespaceCounter(int len, string str) {
        try {
            int whitespace = 44 - len;
            string toReturn = $"{str}" + String.Concat(Enumerable.Repeat(" ", whitespace));
            return toReturn;
        } catch (ArgumentOutOfRangeException) {
            try {
                string toReturn = $"{String.Concat(Enumerable.Repeat(' ', 44))}║\n║          {str}{String.Concat(Enumerable.Repeat(' ', 60 - len))}";
                return toReturn;
            } catch (ArgumentOutOfRangeException) {
                string toReturn = $"{String.Concat(Enumerable.Repeat(' ', 44))}║\n║          --unavailable, project name too long!{String.Concat(Enumerable.Repeat(' ', 23))}";
                return toReturn;
            }
        }
    }
    public static void Main()
    {
        ConsoleColor YELLOW = ConsoleColor.Yellow;
        ConsoleColor BLUE = ConsoleColor.Blue;
        ConsoleColor PURPLE = ConsoleColor.DarkMagenta;
        ConsoleColor END = ConsoleColor.White;

        ConsoleColor INFO = ConsoleColor.Cyan;
        ConsoleColor SUCCESS = ConsoleColor.Green;

        string tick = "\u2713";


        string DAWN = @"
                        ▄▄▄    ▄▄   ▄   ▄  ▄▄  ▄  
                        █  █  █▄▄█  █ █ █  █ █ █ 
                        ▀▀▀   ▀  ▀   ▀ ▀   ▀  ▀▀ ";
        
        Console.WriteLine($"{Colors.Colors.setColor(INFO)}[-] Prepping DAWN");

        Console.WriteLine($"{Colors.Colors.setColor(INFO)}[-] Deserializing \"appconfig.json\"");

        AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));

        Console.WriteLine($"{Colors.Colors.setColor(SUCCESS)}[{tick}] Deserialized \"appconfig.json\"");

        WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"));

        Console.Write($@"{Colors.Colors.setColor(YELLOW)}
  
                             .^    !~    ^         
                              7!   !~   !7         
                         ~!.   ^ ..::.. ^   :!~    
                          :~  ^!?Y5PGPPY7^ .!:     
                      ^^:.  :75PGGGGGGGGGPJ:  .:^^ 
                      .::: ^?Y5555555555555Y: :::. 
                     .  !?JJJJJJJJJJJJJJJ7  .
                     .:^^:.!7777777777777777!.::::.");
        Console.Write($"{Colors.Colors.setColor(BLUE)}{DAWN}");

        //string rd = "./apoisdhioashdoashdiaosasdasdawdawdawdadasdfdasdid/";
        string? rd = cfg?.RootDir;

        string table = $@"
╔══════════════════════════════════════════════════════════════════════╗
║                                                                      ║
║   [{tick}] DAWN app started                                               ║
║                                                                      ║
║   Network Information                                                ║
║       - Local   :   http://localhost:8080                            ║
║       - Network :   --unavailable for security reasons               ║
║                                                                      ║
║   DAWN Information                                                   ║
║       - GH Repo        :                                             ║
║          https://github.com/The-Holy-Church-of-Terry-Davis/DAWN      ║
║                                                                      ║
║       - Root Directory : {whitespaceCounter(rd!.Length, rd)}║
║                                                                      ║
║       DAWN is still under development, expect bugs                   ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝";
        Console.Write($"{Colors.Colors.setColor(PURPLE)}{table}\nLogs:\n");
        Colors.Colors.setColor(END);
    }
}
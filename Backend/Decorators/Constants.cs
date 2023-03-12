namespace Dawn.Decorators;

public static class Constants
{
    public const string tick = "\u2713";
    public const string table = $@"
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
║                                                                      ║";

    public const string second = $@"
║                                                                      ║
║       DAWN is still under development, expect bugs                   ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝";

    public static string Logo = $@"{Colors.setColor(ConsoleColor.Yellow)}
  
                             .^    !~    ^         
                              7!   !~   !7         
                         ~!.   ^ ..::.. ^   :!~    
                          :~  ^!?Y5PGPPY7^ .!:     
                      ^^:.  :75PGGGGGGGGGPJ:  .:^^ 
                      .::: ^?Y5555555555555Y: :::. 
                        .  !?JJJJJJJJJJJJJJJ7  .
                     .:^^:.!7777777777777777!.::::.";
    public const int boxLen = 72;

    public const string DAWN = @"
                        ▄▄▄    ▄▄   ▄   ▄  ▄▄  ▄  
                        █  █  █▄▄█  █ █ █  █ █ █ 
                        ▀▀▀   ▀  ▀   ▀ ▀   ▀  ▀▀ ";
}
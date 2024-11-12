class In{
    //SelNext
    //RemSel
    //Addrect
    //MoveSel

    enum CMD{
        d = (int)'d',
        f = (int)'f',
        j = (int) 'j',
        k = (int) 'k'
    }

    public void Menu(){
        bool isCorrectInput = false;

        while(!isCorrectInput){
            CMD input = (CMD)Console.ReadKey().KeyChar;
            Console.SetCursorPosition(Console.CursorLeft-1,Console.CursorTop);
            switch(input)
            {
                case CMD.d:
                isCorrectInput = true;
                break;
                case CMD.f:
                isCorrectInput = true;
                break;
                case CMD.j:
                isCorrectInput = true;
                break;
                case CMD.k:
                isCorrectInput = true;
                break;
                default:

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input!");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
        }
        Console.WriteLine("Passed");
    }

}
using ScreenManager1;

// Vars
bool keepRunning = true;

Parent cParent = new Parent(0, 0, Global.consoleWidth, Global.consoleHeight);

// Program borders
Box outerMargin = new Box(cParent, 2, 1, Global.consoleWidth, Global.consoleHeight);
Box InnerMargin = new Box(outerMargin.MakeParent, 2, 1, outerMargin.GetParent.width, outerMargin.GetParent.height);

// Label
_ = new Label(InnerMargin.MakeParent, 2, 1, 0, "CRUDapp");

// Button
_ = new Button(InnerMargin.MakeParent, 0, 1, 2, "Create User");

// Table
Table table = new Table(InnerMargin.MakeParent, 2, 5, InnerMargin.MakeParent.width, 0);

while(keepRunning)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.CursorVisible = false;
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.C:
            
            
            
            //table.Update(table.Active, ["id", "john", "Smith", "john@smith.dk", "12345678", "john smith street", "Mr.", "Slet", "Edit"]);
            break;
        default:
            break;
    }
}

// Set cursor at bottom of console
Render.SetPos(Global.consoleWidth, Global.consoleHeight + 1);
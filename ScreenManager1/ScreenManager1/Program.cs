using ScreenManager1;

// Vars
bool keepRunning = true;
string[] inputLabels = ["Fornavn", "Efternavn", "EmailAdr", "Mobil", "Adresse", "Titel"];

Parent cParent = new(0, 0, Global.consoleWidth, Global.consoleHeight);

// Program borders
Box outerMargin = new(cParent, 2, 1, Global.consoleWidth, Global.consoleHeight);
Box InnerMargin = new(outerMargin.MakeParent, 2, 1, outerMargin.GetParent.width, outerMargin.GetParent.height);

// Label
_ = new Label(InnerMargin.MakeParent, 2, 1, 0, "CRUDapp");

// Button
_ = new Button(InnerMargin.MakeParent, 0, 1, 2, "Create User");

// Table
Table table = new(InnerMargin.MakeParent, 2, 5, InnerMargin.MakeParent.width, 0);

while(keepRunning)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.CursorVisible = false;
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.DownArrow:
            table.Update(table.Active + 1);
            break;
        case ConsoleKey.UpArrow:
            table.Update(table.Active - 1);
            break;
        case ConsoleKey.Delete:
            table.Remove(table.Active);
            break;

        case ConsoleKey.C:
            Render.Remove(table.X + table.Width / 2 - 20, table.Y + table.Height / 2, 40, 25);
            Box createUserBox = new(new Parent(table.X + table.Width / 2 - 20, table.Y + table.Height / 2, 50, 25), 0, 0, 40, 25);
           
            for(int i = 1; i <= inputLabels.Length - 1; i++)
            {
                _ = new Label(createUserBox.MakeParent, 2, 3 * i + 1, 2, inputLabels[i-1]);
                _ = new Box(createUserBox.MakeParent, createUserBox.MakeParent.width - 25 - table.X, i * 3, 25, 3);
            }

            _ = new Label(createUserBox.MakeParent, 2, 3 * inputLabels.Length + 1, 2, "Titel");
            ComboBox cb = new(createUserBox.MakeParent, createUserBox.MakeParent.width - 25 - table.X, 3 * inputLabels.Length, 25, 3);

            Input.Run(createUserBox.MakeParent, createUserBox.MakeParent.width - 25 - table.X, 3);
            cb.Run();

            string[] res = Input.Get(cb.Chosen);

            Render.Remove(table.X + table.Width / 2 - 20, table.Y + table.Height / 2, 40, 25);

            table.Update(table.Active, res);
            break;
        default:
            break;
    }
}

// Set cursor at bottom of console
Render.SetPos(Global.consoleWidth, Global.consoleHeight + 1);
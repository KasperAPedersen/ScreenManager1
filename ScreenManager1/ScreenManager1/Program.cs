using ScreenManager1;

// Vars
bool keepRunning = true;
string[] inputLabels = ["Fornavn", "Efternavn", "EmailAdr", "Mobil", "Adresse", "Titel"];

Parent cParent = new(new Pos(0, 0), Global.consoleWidth, Global.consoleHeight);

// Program borders
Box outerMargin = new(cParent, new Pos(2, 1), Global.consoleWidth, Global.consoleHeight);
Box InnerMargin = new(outerMargin.MakeParent, new Pos(2, 1), outerMargin.GetParent.width, outerMargin.GetParent.height);

// Label
_ = new Label(InnerMargin.MakeParent, new Pos(2, 1), (int)Padding.None, "CRUDapp", ConsoleColor.Red, Style.Bold);

// Button
_ = new Button(InnerMargin.MakeParent, new Pos(0, 1), (int)Padding.Small, "Create User");

// Table
Table table = new(InnerMargin.MakeParent, new Pos(2, 5), InnerMargin.MakeParent.width, 0);

while(keepRunning)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.CursorVisible = false;
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.LeftArrow:
            table.ActiveSelector = table.ActiveSelector == 8 ? 7 : 8;
            table.Update(table.Active);
            break;
        case ConsoleKey.RightArrow:
            table.ActiveSelector = table.ActiveSelector == 7 ? 8 : 7;
            table.Update(table.Active);
            break;
        case ConsoleKey.DownArrow:
            table.Update(table.Active + 1);
            break;
        case ConsoleKey.UpArrow:
            table.Update(table.Active - 1);
            break;
        case ConsoleKey.Delete:
            table.Remove(table.Active);
            break;
        case ConsoleKey.Enter:
            switch (table.ActiveSelector)
            {
                case 7:
                    table.Remove(table.Active);
                    break;
                case 8:
                    CreateUser(true);
                    break;
                default:
                    break;
            }
            break;
        case ConsoleKey.C:
            CreateUser();
            break;
        default:
            break;
    }

    // Set cursor at bottom of console
    Render.SetPos(new Pos(Global.consoleWidth, Global.consoleHeight));
}

void CreateUser(bool edit = false)
{
    _ = new Button(InnerMargin.MakeParent, new Pos(0, 1), (int)Padding.Small, "Create User", ConsoleColor.Red);
    Render.Remove(new Pos(table.X + table.Width / 2 - 20, table.Y + table.Height / 2), 40, 25);
    Box createUserBox = new(new Parent(new Pos(table.X + table.Width / 2 - 20, table.Y + table.Height / 2), 50, 25), new Pos(0, 0), 40, 25);
    _ = new Label(createUserBox.MakeParent, new Pos(1, 1), (int)Padding.Small, edit ? "Edit" : "Create");

    for (int i = 1; i <= inputLabels.Length - 1; i++)
    {
        _ = new Label(createUserBox.MakeParent, new Pos(2, 3 * i + 1), (int)Padding.None, inputLabels[i - 1]);
        _ = new Box(createUserBox.MakeParent, new Pos(createUserBox.MakeParent.width - 25 - table.X, i * 3), 25, 3);
    }

    _ = new Label(createUserBox.MakeParent, new Pos(2, 3 * inputLabels.Length + 1), (int)Padding.None, "Titel");
    ComboBox cb = new(createUserBox.MakeParent, new Pos(createUserBox.MakeParent.width - 25 - table.X, 3 * inputLabels.Length), 25, 3);

    Input.Run(createUserBox.MakeParent, new Pos(createUserBox.MakeParent.width - 25 - table.X, 3), edit, edit ? table.Active + 1 : 0);
    cb.Run();

    string[] res = Input.Get(cb.Chosen);

    Render.Remove(new Pos(table.X + table.Width / 2 - 20, table.Y + table.Height / 2), 40, 25);

    table.Update(table.Active, res, edit);
    _ = new Button(InnerMargin.MakeParent, new Pos(0, 1), (int)Padding.Small, "Create User", ConsoleColor.White);
}


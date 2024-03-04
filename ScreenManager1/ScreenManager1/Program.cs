using ScreenManager1;

Parent head = new Parent(0, 0, Global.consoleWidth, Global.consoleHeight);

// Program borders
Box outerMargin = new Box(head, 2, 1, Global.consoleWidth, Global.consoleHeight);
Box InnerMargin = new Box(outerMargin.MakeParent, 2, 1, outerMargin.GetParent.width, outerMargin.GetParent.height);

// Label
_ = new Label(InnerMargin.MakeParent, 2, 1, 0, "CRUDapp");

// Button
_ = new Button(InnerMargin.MakeParent, 0, 1, 2, "Create User");

// Table


// Set cursor at bottom of console
Render.SetPos(Global.consoleWidth, Global.consoleHeight + 1);
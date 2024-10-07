using Terminal.Gui;

var ponys = LoadPonys("data/ponys.csv");

Application.Init();
var top = new Toplevel()
{
    X = 0,
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()
};
var menu = new MenuBar(new MenuBarItem[] {
    new("_File", new MenuItem[] {
        new("_Quit", "Exists the program", CloseApplication)
        // new("_Quit", "Exists the program", () => Application.RequestStop())
    })
});
var win = new Window("Pony Explorer")
{
    X = 0,
    Y = 1,
    Width = Dim.Fill(),
    Height = Dim.Fill(1)
};

var label = new Label("Pony Name: ") { X = 1, Y = 0 };
win.Add(label);

var nameFilter = new TextField()
{
    X = Pos.Right(label) + 1,
    Y = Pos.Top(label),
    Width = Dim.Fill(11)
};
win.Add(nameFilter);

var searchButton = new Button("Search")
{
    X = Pos.Right(nameFilter) + 1,
    Y = Pos.Top(label),
    Shortcut = Key.Enter
};
win.Add(searchButton);

var ponyList = new ListView(ponys)
{
    X = 1,
    Y = Pos.Bottom(label) + 1,
    Width = Dim.Fill(1),
    Height = Dim.Fill(1)
};
ponyList.OpenSelectedItem += Details;
win.Add(ponyList);

top.Add(menu, win);
Application.Run(top);
Application.Shutdown();

void Details(ListViewItemEventArgs args)
{
    var pony = (Pony)args.Value;
    MessageBox.Query(pony.Name, pony.Image[0], "Ok");
}

void CloseApplication()
{
    Application.RequestStop();
}

Pony[] LoadPonys(string filename)
{
    var lines = File.ReadAllLines(filename);
    var ponys = new Pony[lines.Length];

    for (var i = 0; i < ponys.Length; i++)
    {
        var fields = lines[i]
            .Split(';')
            .Select(field => field.Trim('"'))
            .ToArray();

        ponys[i] = new(
            int.Parse(fields[0]),
            fields[1],
            fields[2],
            fields[3],
            fields[4],
            fields[5],
            fields[6].Split(','),
            fields[7].Split(',')
        );
    }

    return ponys;
}

record Pony(
    int Id,
    string Name,
    string Alias,
    string Url,
    string Residence,
    string Occupation,
    string[] Kind,
    string[] Image
)
{
    public override string ToString() => $"{Id:D3}: {Name}";
}
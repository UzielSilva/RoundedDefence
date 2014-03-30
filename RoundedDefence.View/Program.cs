using System;
using Gtk;
using Pango;

class LayoutSample : DrawingArea
{
	Pango.Layout layout;

	static void Main ()
	{
		Application.Init ();
		new LayoutSample ();
		Application.Run ();
	}

	LayoutSample ()
	{
		Window win = new Window ("Layout sample");
		win.SetDefaultSize (400, 300);
		win.DeleteEvent += OnWinDelete;
		this.Realized += OnRealized;
		this.ExposeEvent += OnExposed;

		win.Add (this);
		win.ShowAll ();
	}

	void OnExposed (object o, ExposeEventArgs args)
	{
		this.GdkWindow.DrawLayout (this.Style.TextGC (StateType.Normal), 100, 150, layout);
	}

	void OnRealized (object o, EventArgs args)
	{
		layout = new Pango.Layout (this.PangoContext);
		layout.Wrap = Pango.WrapMode.Word;
		layout.FontDescription = FontDescription.FromString ("Tahoma 16");
		layout.SetMarkup ("Hello Pango.Layout");
	}

	void OnWinDelete (object o, DeleteEventArgs args)
	{
		Application.Quit ();
	}
}

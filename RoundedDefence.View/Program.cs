using Gtk;
using Cairo;
using System;


class LayoutSample : Window
{

	public LayoutSample() : base("Simple drawing")
	{
		SetDefaultSize(750, 600);
		SetPosition(WindowPosition.Center);
		DeleteEvent += delegate { Application.Quit(); };;

		DrawingArea darea = new DrawingArea();
		darea.ExposeEvent += OnExpose;

		Add(darea);

		ShowAll();
	}

	void OnExpose(object sender, ExposeEventArgs args)
	{
		DrawingArea area = (DrawingArea) sender;
		Cairo.Context cr =  Gdk.CairoHelper.Create(area.GdkWindow);
		//Cairo.Surface image= Cairo.ImageSurface("Resources/mar3.png");
		int width = Allocation.Width;
		int height= Allocation.Height;

		cr.Rectangle (new Rectangle (0,0,width,height));
		cr.StrokePreserve();

		cr.SetSourceRGB(0.3, 0.4, 0.6);
		cr.Fill();

		((IDisposable) cr.Target).Dispose();                                      
		((IDisposable) cr).Dispose();
	}

	public static void Main()
	{
		Application.Init();
		new LayoutSample();
		Application.Run();
	}
}

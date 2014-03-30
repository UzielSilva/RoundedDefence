using System;
using javax.swing;
using java.awt;

namespace RoundedDefence.View
{
	public class Window : JFrame
	{
		JPanel pane = new JPanel();
		Window() : base("My Simple Frame") // the frame constructor method
		{
			setBounds(100,100,300,100);
			setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			Container con = this.getContentPane(); // inherit main frame
			con.add(pane); // add the panel to frame
			// customize panel here
			// pane.add(someWidget);
			setVisible(true); // display this frame
		}
		public static void Main(String[] arg) {new Window();}
	}
}


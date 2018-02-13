using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Warship
{
    public class Window : Form
    {
        private BufferedGraphicsContext context;
        private BufferedGraphics bufferedGraphics;
		//private List<Layer> layers = new List<Layer>();
		private Game game;

        public Window(String name, int width, int height)
        {
            this.Text = name;
            this.Width = width;
            this.Height = height;
			int sizeTile = 21;
			Dimension d1 = new Dimension(20, 40, 209, 209);
			Dimension d2 = new Dimension(270, 40, 209, 209);
			RenderInfo i1 = new RenderInfo(sizeTile, d1);
			RenderInfo i2 = new RenderInfo(sizeTile, d2);
			int[] len = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

			game = new Game("Player", i1, "Bot ", i2, len);
			InitializeComponent();
			Start();
        }

        #region Init
        private void InitializeComponent()
        {
//            this.SetVisibleCore(true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MouseDown += Window_MouseDown;
            this.MouseUp += Window_MouseUp;
            this.MouseMove += Window_MouseMove;
            this.Resize += Window_Resize;
			//.Icon = new Icon("icon.bmp");

            this.ClientSize = new System.Drawing.Size(this.Width, this.Height);
            this.Name = "Window";
            this.ResumeLayout(false);

            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            if(bufferedGraphics != null)
            {
                bufferedGraphics.Dispose();
            }
            bufferedGraphics = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            this.Refresh();
        }
        #endregion

        private void Start()
        {
			new Thread(() =>
				{
					while(true)
					{
						Render();
					}
				}).Start();
        }

		private void Render()
		{
			bufferedGraphics = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            game.OnRender(bufferedGraphics.Graphics);   
			bufferedGraphics.Render();
			bufferedGraphics.Dispose();
		}
	
        private void OnEvent(Event e)
        {
			game.OnEvent(e);
        }


        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            MouseReleasedEvent me = new MouseReleasedEvent(e.Button, e.X, e.Y);
            OnEvent(me);
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            MousePressedEvent me = new MousePressedEvent(e.Button, e.X, e.Y);
            OnEvent(me);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMotionEvent me = new MouseMotionEvent(e.X, e.Y, false);
            OnEvent(me);
        }
    }
}

/*
private void InitializeComponent()
{
    this.SetVisibleCore(true);
    this.Resize += Window_Resize;
    this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.MouseDown += Window_MouseDown;
    this.MouseUp += Window_MouseUp;

    this.StartButton = new System.Windows.Forms.Button();
    this.SuspendLayout();
    this.StartButton.Location = new System.Drawing.Point(537, 243);
    this.StartButton.Name = "StartButton";
    this.StartButton.Size = new System.Drawing.Size(75, 23);
    this.StartButton.TabIndex = 0;
    this.StartButton.Text = "Start";
    this.StartButton.UseVisualStyleBackColor = true;
    this.StartButton.Click += new System.EventHandler(this.button1_Click);
 
    this.ClientSize = new System.Drawing.Size(624, 481);
    this.Controls.Add(this.StartButton);
    this.Name = "Window";
    this.ResumeLayout(false);

    this.RenderTimer = new System.Windows.Forms.Timer();
    this.RenderTimer.Interval = 1;
    this.RenderTimer.Tick += Render;
    this.RenderTimer.Start();

    context = BufferedGraphicsManager.Current;
    context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
}
*/